using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestCatalogue.BLL.DTO;
using TestCatalogue.BLL.Interfaces;
using TestCatalogue.Models;

namespace TestCatalogue.Pages
{
    public class DeleteModel : PageModel
    {
        ICatalogueService service;

        public DeleteModel(ICatalogueService srv)
        {
            service = srv;
        }
        public void OnGet(int id)
        {
            Employee = new EmployeeModel();
            Employee.AssignFrom(service.Employees.Get(id));
        }

        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EmployeeDTO emp = service.Employees.Get(id);

            if (emp != null)
                service.Employees.Delete(emp);

            return RedirectToPage("./Index");
        }

        [BindProperty]
        public EmployeeModel Employee { get; set; }
    }
}
