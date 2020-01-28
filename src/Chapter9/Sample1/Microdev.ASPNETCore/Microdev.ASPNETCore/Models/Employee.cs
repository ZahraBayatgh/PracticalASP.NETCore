using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Microdev.ASPNETCore.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required]
        [MaxLength(64)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(64)]
        public string LastName { get; set; }
        [Required]
        public decimal Salary { get; set; }
        public int? BossId { get; set; }
        public Employee Boss { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        public Department Department { get; set; }

    }
}
