using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestCatalogue.BLL.DTO;
using TestCatalogue.BLL.Interfaces;
using TestCatalogue.Models;

namespace TestCatalogue.Pages
{
    public class EditLangModel : PageModel
    {
        ICatalogueService service;
        public EditLangModel(ICatalogueService srv)
        {
            this.service = srv;
        }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
                return NotFound();

            this.LanguageModel = new LanguageModel();
            this.LanguageModel.AssignFrom(service.Languages.Get(id));
            
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
            LanguageDTO lang = service.Languages.Get(id);
            this.LanguageModel.AssignTo(lang);
            service.Languages.Edit(lang);

            return RedirectToPage("./Languages");
        }

        [BindProperty]
        public LanguageModel LanguageModel { get; set; }
    }
}
