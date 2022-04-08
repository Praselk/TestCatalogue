using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCatalogue.BLL.DTO;
using TestCatalogue.BLL.Interfaces;
using TestCatalogue.DAL.Interfaces;
using TestCatalogue.DAL.Entities;

namespace TestCatalogue.BLL.Repositories
{
    public class LanguageDTORepository : IDTORepository<LanguageDTO>
    {
        IUnitOfWork Database { get; set; }

        public LanguageDTORepository(IUnitOfWork database)
        {
            Database = database;
        }

        public LanguageDTO Get(int? id)
        {
            if (id == null)
                throw new ArgumentException("Invalid Language ID");

            Language language = Database.Languages.Get((int)id);
            if (language == null)
                throw new ArgumentException("There is no such Language");

            return ConvertLanguage(language);
        }

        public IList<LanguageDTO> GetAll()
        {
            IEnumerable<Language> languages = Database.Languages.GetAll();

            List<LanguageDTO> result = new List<LanguageDTO>();
            foreach (Language language in languages)
                result.Add(ConvertLanguage(language));

            return result;
        }

        private LanguageDTO ConvertLanguage(Language language)
        {
            return new LanguageDTO()
            {
                Id = language.Id,
                LanguageName = language.LanguageName,
            };
        }

        public void Add(LanguageDTO entry)
        {
            Language language = new Language()
            {
                LanguageName = entry.LanguageName
            };
            Database.Languages.Create(language);
        }

        public void Edit(LanguageDTO entry)
        {
            Language language = Database.Languages.Get(entry.Id);
            if (language == null)
                throw new ArgumentException("There is no such employee");

            language.LanguageName = entry.LanguageName;            

            Database.Languages.Update(language);
        }

        public void Delete(LanguageDTO entry)
        {
            Database.Languages.Delete(entry.Id);
        }
    }
}
