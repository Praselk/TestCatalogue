using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCatalogue.BLL.DTO;

namespace TestCatalogue.BLL.Interfaces
{
    public interface ICatalogueService
    {     
        void Dispose();

        IDTORepository<EmployeeDTO> Employees { get; }
        IDTORepository<DepartmentDTO> Departments { get; }
        IDTORepository<LanguageDTO> Languages { get; }
    }
}
