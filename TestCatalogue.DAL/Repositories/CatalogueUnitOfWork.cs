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
    public class CatalogueUnitOfWork : IUnitOfWork
    {
        CatalogueContext db;
        private EmployeeRepository employeeRepository;
        private DepartmentRepository departmentRepository;
        private LanguageRepository languageRepository;        
        private bool disposed = false;

        public CatalogueUnitOfWork(DbContextOptions<CatalogueContext> options)
        {
            this.db = new CatalogueContext(options);
            InitializeDb();
        }

        protected virtual void InitializeDb()
        {
            if (db != null && db.Database.EnsureCreated())
            {
                Department[] departments = new Department[]
                {
                    new Department() { Floor = 1, DepartmentName = "Отдел 1" },
                    new Department() { Floor = 2, DepartmentName = "Отдел 2" },
                    new Department() { Floor = 3, DepartmentName = "Отдел 3" },
                };
                db.Departments.AddRange(departments);

                Language[] languages = new Language[]
                {
                    new Language() { LanguageName = "C#" },
                    new Language() { LanguageName = "C++" },
                    new Language() { LanguageName = "Visual Basic" },
                    new Language() { LanguageName = "Python" },
                };

                db.Languages.AddRange(languages);
                db.SaveChanges();
            }
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public IRepository<Employee> Employees 
        { 
            get 
            {
                if (employeeRepository == null)
                    employeeRepository = new EmployeeRepository(db);
                return employeeRepository;
            } 
        }

        public IRepository<Department> Departments
        {
            get
            {
                if (departmentRepository == null)
                    departmentRepository = new DepartmentRepository(db);
                return departmentRepository;
            }
        }

        public IRepository<Language> Languages
        {
            get
            {
                if (languageRepository == null)
                    languageRepository = new LanguageRepository(db);
                return languageRepository;
            }
        }
    }
}
