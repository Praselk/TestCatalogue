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
    public class EmployeeRepository : IRepository<Employee>
    {
        private CatalogueContext db;

        public EmployeeRepository(CatalogueContext context)
        {
            this.db = context;
        }

        public IEnumerable<Employee> GetAll()
        {
            return db.Employees;
        }

        public Employee Get(int id)
        {
            return db.Employees.Find(id);
        }

        public void Create(Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
        }

        public void Update(Employee employee)
        {
            db.Entry(employee).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Employee employee = db.Employees.Find(id);
            if (employee != null)
            {
                db.Employees.Remove(employee);
                db.SaveChanges();
            }
        }
    }
}
