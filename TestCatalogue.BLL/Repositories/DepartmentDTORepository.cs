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
    public class DepartmentDTORepository : IDTORepository<DepartmentDTO>
    {
        IUnitOfWork Database { get; set; }

        public DepartmentDTORepository(IUnitOfWork database)
        {
            Database = database;
        }

        public DepartmentDTO Get(int? id)
        {
            if (id == null)
                throw new ArgumentException("Invalid Department ID");

            Department department = Database.Departments.Get((int)id);
            if (department == null)
                throw new ArgumentException("There is no such department");

            return ConvertDepartment(department);
        }

        public IList<DepartmentDTO> GetAll()
        {
            IEnumerable<Department> departments = Database.Departments.GetAll();

            List<DepartmentDTO> result = new List<DepartmentDTO>();
            foreach (Department department in departments)
                result.Add(ConvertDepartment(department));

            return result;
        }

        private DepartmentDTO ConvertDepartment(Department department)
        {
            return new DepartmentDTO()
            {
                Id = department.Id,
                DepartmentName = department.DepartmentName,
                Floor = department.Floor
            };
        }

        public void Add(DepartmentDTO entry)
        {
            Department department = new Department()
            {
                DepartmentName = entry.DepartmentName,
                Floor = entry.Floor
            };
            Database.Departments.Create(department);
        }

        public void Edit(DepartmentDTO entry)
        {
            Department department = Database.Departments.Get(entry.Id);
            if (department == null)
                throw new ArgumentException("There is no such employee");

            department.DepartmentName = entry.DepartmentName;
            department.Floor = entry.Floor;

            Database.Departments.Update(department);
        }

        public void Delete(DepartmentDTO entry)
        {
            Database.Departments.Delete(entry.Id);
        }
    }
}
