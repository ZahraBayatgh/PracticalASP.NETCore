using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microdev.API.Application.Queries
{
    public interface IDepartmentQueries
    {
        Task<IEnumerable<DepartmentWithSalaryDTO>> GetAllDepartmentsWithSalaryAsync();
        Task<IEnumerable<string>> GetExpensiveEmployeesAsync();
        //ToDo: Implement these queries at home
        //Task<IEnumerable<EmployeeDTO>> GetMostExpensiveEmployeesAsync();
        //Task<IEnumerable<DepartmentDTO>> GetThinDepartmentsAsync();
        //Task<IEnumerable<>> GetOutsiderEmployeesAsync();
        //Task<IEnumerable<DepartmentWithCountDTO>> GetAllDepartmentsWithCountAsync();
    }
}
