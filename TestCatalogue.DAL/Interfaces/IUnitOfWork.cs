using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCatalogue.DAL.Entities;

namespace TestCatalogue.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Employee> Employees { get; }
        IRepository<Department> Departments { get; }
        IRepository<Language> Languages { get; }
        void Save();
    }
}
