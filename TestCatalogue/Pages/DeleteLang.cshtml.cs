using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestCatalogue.BLL.DTO;
using TestCatalogue.BLL.Interfaces;
using TestCatalogue.Models;

namespace TestCatalogue.Pages
{
    public class DeleteLangModel : PageModel
    {
        ICatalogueService service;

        public DeleteLangModel(ICatalogueService srv)
        {
            service = srv;
        }
        public void OnGet(int id)
        {
            Language = new LanguageModel();
            Language.AssignFrom(service.Languages.Get(id));
        }

        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LanguageDTO lang = service.Languages.Get(id);

            if (lang != null)
                service.Languages.Delete(lang);

            return RedirectToPage("./Languages");
        }

        [BindProperty]
        public LanguageModel Language { get; set; }
    }
}
