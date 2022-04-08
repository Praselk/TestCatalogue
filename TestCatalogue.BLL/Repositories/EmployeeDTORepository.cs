using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCatalogue.BLL.DTO;
using TestCatalogue.BLL.Interfaces;
using TestCatalogue.DAL.Entities;
using TestCatalogue.DAL.Interfaces;

namespace TestCatalogue.BLL.Repositories
{
    public class EmployeeDTORepository : IDTORepository<EmployeeDTO>
    {
        IUnitOfWork Database { get; set; }

        public EmployeeDTORepository(IUnitOfWork database)
        {
            Database = database;
        }

        public EmployeeDTO Get(int? id)
        {
            if (id == null)
                throw new ArgumentException("Invalid Employee ID");

            Employee employee = Database.Employees.Get((int)id);
            if (employee == null)
                throw new ArgumentException("There is no such employee");

            return ConvertEmployee(employee);
        }

        public IList<EmployeeDTO> GetAll()
        {
            IEnumerable<Employee> employees = Database.Employees.GetAll();

            List<EmployeeDTO> result = new List<EmployeeDTO>();
            foreach (Employee employee in employees)
                result.Add(ConvertEmployee(employee));

            return result;
        }

        private EmployeeDTO ConvertEmployee(Employee employee)
        {
            return new EmployeeDTO()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Age = employee.Age,
                DepartmentId = employee.DepartmentId,
                LanguageId = employee.LanguageId
            };
        }

        public void Add(EmployeeDTO entry)
        {
            Employee employee = new Employee()
            {
                FirstName = entry.FirstName,
                LastName = entry.LastName,
                Age = entry.Age,
                DepartmentId = entry.DepartmentId,
                LanguageId = entry.LanguageId
            };
            Database.Employees.Create(employee);
        }

        public void Edit(EmployeeDTO entry)
        {
            Employee employee = Database.Employees.Get(entry.Id);
            if (employee == null)
                throw new ArgumentException("There is no such employee");

            employee.FirstName = entry.FirstName;
            employee.LastName = entry.LastName;
            employee.Age = entry.Age;
            employee.DepartmentId = entry.DepartmentId;
            employee.LanguageId = entry.LanguageId;

            Database.Employees.Update(employee);
        }

        public void Delete(EmployeeDTO entry)
        {
            Database.Employees.Delete(entry.Id);
        }
    }
}
