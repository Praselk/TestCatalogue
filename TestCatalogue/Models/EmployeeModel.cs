using System.ComponentModel.DataAnnotations;
using TestCatalogue.BLL.DTO;
using TestCatalogue.Interfaces;

namespace TestCatalogue.Models
{
    public class EmployeeModel : IAssignable<EmployeeDTO>
    {
        public void AssignFrom(EmployeeDTO source)
        {
            this.Id = source.Id;
            this.FirstName = source.FirstName;
            this.LastName = source.LastName;
            this.Age = source.Age;
            this.DepartmentId = source.DepartmentId;
            this.LanguageId = source.LanguageId;
        }

        public void AssignTo(EmployeeDTO target)
        {
            if (target != null)
            {
                target.FirstName = this.FirstName;
                target.LastName = this.LastName;
                target.Age = this.Age;
                target.DepartmentId = this.DepartmentId;
                target.LanguageId = this.LanguageId;
            }
        }

        public int Id { get; set; }
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        [Display(Name = "Возраст")]
        public int Age { get; set; }
        [Display(Name = "Отдел")]
        public int DepartmentId { get; set; }
        [Display(Name = "Язык программирования")]
        public int LanguageId { get; set; }
    }
}
