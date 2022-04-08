using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestCatalogue.BLL.DTO;
using TestCatalogue.BLL.Interfaces;
using TestCatalogue.Models;

namespace TestCatalogue.Pages
{
    public class EditDeptModel : PageModel
    {
        ICatalogueService service;
        public EditDeptModel(ICatalogueService srv)
        {
            this.service = srv;
        }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
                return NotFound();

            this.DepartmentModel = new DepartmentModel();
            this.DepartmentModel.AssignFrom(service.Departments.Get(id));

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
            DepartmentDTO dept = service.Departments.Get(id);
            this.DepartmentModel.AssignTo(dept);
            service.Departments.Edit(dept);

            return RedirectToPage("./Departments");
        }

        [BindProperty]
        public DepartmentModel DepartmentModel { get; set; }
    }
}
