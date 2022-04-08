using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestCatalogue.BLL.DTO;
using TestCatalogue.BLL.Interfaces;
using TestCatalogue.Models;

namespace TestCatalogue.Pages
{
    public class AddDeptModel : PageModel
    {
        ICatalogueService service;
        public AddDeptModel(ICatalogueService srv)
        {
            this.service = srv;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            DepartmentDTO dept = new DepartmentDTO();
            this.DepartmentModel.AssignTo(dept);
            service.Departments.Add(dept);

            return RedirectToPage("./Departments");
        }

        [BindProperty]
        public DepartmentModel DepartmentModel { get; set; }
    }
}
