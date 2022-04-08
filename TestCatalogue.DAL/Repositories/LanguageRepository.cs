using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCatalogue.DAL.EF;
using TestCatalogue.DAL.Entities;
using TestCatalogue.DAL.Interfaces;

namespace TestCatalogue.DAL.Repositories
{
    public class LanguageRepository : IRepository<Language>
    {
        private CatalogueContext db;

        public LanguageRepository(CatalogueContext context)
        {
            this.db = context;
        }

        public IEnumerable<Language> GetAll()
        {
            return db.Languages;
        }

        public Language Get(int id)
        {
            return db.Languages.Find(id);
        }

        public void Create(Language lang)
        {
            db.Languages.Add(lang);
            db.SaveChanges();
        }

        public void Update(Language lang)
        {
            db.Entry(lang).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Language lang = db.Languages.Find(id);
            if (lang != null)
            {
                db.Languages.Remove(lang);
                db.SaveChanges();
            }
        }
    }
}
