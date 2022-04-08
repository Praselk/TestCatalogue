using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestCatalogue.BLL.DTO;
using TestCatalogue.BLL.Interfaces;
using TestCatalogue.Helpers;
using TestCatalogue.Models;

namespace TestCatalogue.Pages
{
    public class DepartmentsModel : PageModel
    {
        ICatalogueService service;

        public DepartmentsModel(ICatalogueService srv)
        {
            this.service = srv;
        }

        public void OnGet()
        {
            Departments = CollectionHelper.PopulateModels<DepartmentDTO, DepartmentModel>(service.Departments);
        }

        public IList<DepartmentModel> Departments { get; set; }
    }
}
