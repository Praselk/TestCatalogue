using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestCatalogue.BLL.DTO;
using TestCatalogue.BLL.Interfaces;
using TestCatalogue.Helpers;
using TestCatalogue.Models;

namespace TestCatalogue.Pages
{
    public class EditModel : PageModel
    {
        ICatalogueService service;
        public EditModel(ICatalogueService srv)
        {
            this.service = srv;
        }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
                return NotFound();

            this.EmployeeModel = new EmployeeModel();
            this.EmployeeModel.AssignFrom(service.Employees.Get(id));

            Languages = CollectionHelper.PopulateModels<LanguageDTO, LanguageModel>(service.Languages);
            Departments = CollectionHelper.PopulateModels<DepartmentDTO, DepartmentModel>(service.Departments);
            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            if (id == null)
                return NotFound();

            if (!ModelState.IsValid)
            {
                return Page();
            }
            EmployeeDTO employee = service.Employees.Get(id);
            this.EmployeeModel.AssignTo(employee);
            service.Employees.Edit(employee);

            return RedirectToPage("./Index");
        }

        [BindProperty]
        public EmployeeModel EmployeeModel { get; set; }

        public IList<DepartmentModel> Departments { get; set; }
        public IList<LanguageModel> Languages { get; set; }
    }
}
