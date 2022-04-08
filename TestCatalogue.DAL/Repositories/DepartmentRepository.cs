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
    public class DepartmentRepository : IRepository<Department>
    {
        private CatalogueContext db;

        public DepartmentRepository(CatalogueContext context)
        {
            this.db = context;
        }

        public IEnumerable<Department> GetAll()
        {
            return db.Departments;
        }

        public Department Get(int id)
        {
            return db.Departments.Find(id);
        }

        public void Create(Department dept)
        {
            db.Departments.Add(dept);
            db.SaveChanges();
        }

        public void Update(Department dept)
        {
            db.Entry(dept).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Department dept = db.Departments.Find(id);
            if (dept != null)
            {
                db.Departments.Remove(dept);
                db.SaveChanges();
            }
        }
    }
}
