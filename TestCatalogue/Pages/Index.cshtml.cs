using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestCatalogue.BLL.DTO;
using TestCatalogue.BLL.Interfaces;
using TestCatalogue.Models;
using System.Linq;
using TestCatalogue.Interfaces;
using TestCatalogue.Helpers;

namespace TestCatalogue.Pages
{
    public class IndexModel : PageModel
    {
        ICatalogueService service;

        public IndexModel(ICatalogueService srv)
        {
            this.service = srv;
        }

        public void OnGet()
        {                               
            Employees = CollectionHelper.PopulateModels<EmployeeDTO, EmployeeModel>(service.Employees);            
        }

        public LanguageModel GetLanguage(int id)
        {            

            return GetEntry<LanguageDTO, LanguageModel>(service.Languages, id);
        }

        public DepartmentModel GetDepartment(int id)
        {
            return GetEntry<DepartmentDTO, DepartmentModel>(service.Departments, id);
        }

        private TTarget GetEntry<TSource, TTarget>(IDTORepository<TSource> source, int id)
            where TSource : class
            where TTarget : IAssignable<TSource>, new()
        {
            TSource dto = source.Get(id);
            if (dto != null)
            {
                TTarget target = new TTarget();
                target.AssignFrom(dto);
                return target;
            }

            return default(TTarget);
        }        

        public IList<EmployeeModel> Employees { get; set; }
    }
}