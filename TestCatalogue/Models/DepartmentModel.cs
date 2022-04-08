using System.ComponentModel.DataAnnotations;
using TestCatalogue.BLL.DTO;
using TestCatalogue.Interfaces;

namespace TestCatalogue.Models
{
    public class DepartmentModel : IAssignable<DepartmentDTO>
    {
        public void AssignFrom(DepartmentDTO source)
        {
            this.Id = source.Id;
            this.DepartmentName = source.DepartmentName;
            this.Floor = source.Floor;
        }

        public void AssignTo(DepartmentDTO target)
        {
            if (target != null)
            {
                target.DepartmentName = this.DepartmentName;
                target.Floor = this.Floor;
            }
        }

        public int Id { get; set; }
        [Display(Name = "Название отдела")]
        public string DepartmentName { get; set; }
        [Display(Name = "Этаж")]
        public int Floor { get; set; }
    }
}
