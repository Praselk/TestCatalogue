using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestCatalogue.BLL.DTO;
using TestCatalogue.BLL.Interfaces;
using TestCatalogue.Models;

namespace TestCatalogue.Pages
{
    public class DeleteDeptModel : PageModel
    {
        ICatalogueService service;

        public DeleteDeptModel(ICatalogueService srv)
        {
            service = srv;
        }
        public void OnGet(int id)
        {
            Department = new DepartmentModel();
            Department.AssignFrom(service.Departments.Get(id));
        }

        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DepartmentDTO dept = service.Departments.Get(id);

            if (dept != null)
                service.Departments.Delete(dept);

            return RedirectToPage("./Departments");
        }

        [BindProperty]
        public DepartmentModel Department { get; set; }
    }
}
