using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestCatalogue.BLL.DTO;
using TestCatalogue.BLL.Interfaces;
using TestCatalogue.Helpers;
using TestCatalogue.Models;

namespace TestCatalogue.Pages
{
    public class AddModel : PageModel
    {
        ICatalogueService service;
        public AddModel(ICatalogueService srv)
        {
            this.service = srv;
        }

        public IActionResult OnGet()
        {
            Languages = CollectionHelper.PopulateModels<LanguageDTO, LanguageModel>(service.Languages);
            Departments = CollectionHelper.PopulateModels<DepartmentDTO, DepartmentModel>(service.Departments);
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            EmployeeDTO employee = new EmployeeDTO();
            this.EmployeeModel.AssignTo(employee);
            service.Employees.Add(employee);

            return RedirectToPage("./Index");
        }

        [BindProperty]
        public EmployeeModel EmployeeModel { get; set; }

        public IList<DepartmentModel> Departments { get; set; }
        public IList<LanguageModel> Languages { get; set; }
    }
}
