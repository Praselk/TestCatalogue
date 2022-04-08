using System.ComponentModel.DataAnnotations;
using TestCatalogue.BLL.DTO;
using TestCatalogue.Interfaces;

namespace TestCatalogue.Models
{
    public class LanguageModel : IAssignable<LanguageDTO>
    {
        public void AssignFrom(LanguageDTO source)
        {
            this.Id = source.Id;
            this.LanguageName = source.LanguageName;
        }

        public void AssignTo(LanguageDTO target)
        {
            if (target != null)
                target.LanguageName = this.LanguageName;
        }

        public int Id { get; set; }
        [Display(Name = "Язык программирования")]
        public string LanguageName { get; set; }
    }
}
