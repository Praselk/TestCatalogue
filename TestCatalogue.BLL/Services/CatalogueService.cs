using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCatalogue.BLL.DTO;
using TestCatalogue.BLL.Interfaces;
using TestCatalogue.BLL.Repositories;
using TestCatalogue.DAL.Entities;
using TestCatalogue.DAL.Interfaces;

namespace TestCatalogue.BLL.Services
{
    public class CatalogueService : ICatalogueService
    {        
        IDTORepository<EmployeeDTO> employeeRepository;
        IDTORepository<DepartmentDTO> departmentRepository;
        IDTORepository<LanguageDTO> languageRepository;

        public CatalogueService(IUnitOfWork uow)
        {
            Database = uow;
            employeeRepository = new EmployeeDTORepository(uow);
            departmentRepository = new DepartmentDTORepository(uow);
            languageRepository = new LanguageDTORepository(uow);
        }

        public IDTORepository<EmployeeDTO> Employees => employeeRepository;

        public IDTORepository<DepartmentDTO> Departments => departmentRepository;

        public IDTORepository<LanguageDTO> Languages => languageRepository;

        IUnitOfWork Database { get; set; }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
