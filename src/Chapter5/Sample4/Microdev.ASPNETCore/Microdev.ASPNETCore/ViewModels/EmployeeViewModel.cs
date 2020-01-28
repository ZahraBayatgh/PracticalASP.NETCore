using System.Collections.Generic;
using Microdev.ASPNETCore.Models;
using System.ComponentModel.DataAnnotations;

namespace Microdev.ASPNETCore.ViewModels
{
    public class EmployeeViewModel
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
        [Required]
        public string BossName { get; set; }
        [Required]
        [MaxLength(64)]
        public string DepartmentName { get; set; }
    }
}
