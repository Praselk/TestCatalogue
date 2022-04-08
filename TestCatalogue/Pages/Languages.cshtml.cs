using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestCatalogue.BLL.DTO;
using TestCatalogue.BLL.Interfaces;
using TestCatalogue.Helpers;
using TestCatalogue.Models;

namespace TestCatalogue.Pages
{
    public class LanguagesModel : PageModel
    {
        ICatalogueService service;

        public LanguagesModel(ICatalogueService srv)
        {
            this.service = srv;
        }

        public void OnGet()
        {
            Languages = CollectionHelper.PopulateModels<LanguageDTO, LanguageModel>(service.Languages);
        }

        public IList<LanguageModel> Languages { get; set; }
    }
}
