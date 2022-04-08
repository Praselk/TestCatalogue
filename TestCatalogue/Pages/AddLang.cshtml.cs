using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestCatalogue.BLL.DTO;
using TestCatalogue.BLL.Interfaces;
using TestCatalogue.Models;

namespace TestCatalogue.Pages
{
    public class AddLangModel : PageModel
    {
        ICatalogueService service;
        public AddLangModel(ICatalogueService srv)
        {
            this.service = srv;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            LanguageDTO lang = new LanguageDTO();
            this.LanguageModel.AssignTo(lang);
            service.Languages.Add(lang);

            return RedirectToPage("./Languages");
        }

        [BindProperty]
        public LanguageModel LanguageModel { get; set; }
    }
}
