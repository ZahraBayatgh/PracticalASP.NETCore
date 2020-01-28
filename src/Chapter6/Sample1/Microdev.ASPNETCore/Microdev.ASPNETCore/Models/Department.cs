using System.ComponentModel.DataAnnotations;

namespace Microdev.ASPNETCore.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        [Required]
        [Display(Name = "CompanyName")]
        public string Name { get; set; }

    }
}
