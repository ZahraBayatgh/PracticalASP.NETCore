using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Microdev.API.Application.Queries
{
    public class DepartmentQueries : IDepartmentQueries
    {
        private readonly string _connectionString;

        public DepartmentQueries(string connectionString)
        {
            _connectionString = connectionString;
        }
        /// <summary>
        /// List all departments along with the total salary there
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DepartmentWithSalaryDTO>> GetAllDepartmentsWithSalaryAsync()
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return (await connection.QueryAsync<DepartmentWithSalaryDTO>
                                (@"SELECT  d.Name ,
                    ISNULL(g.Sum, 0) AS Sum
            FROM    Department AS d
                    LEFT OUTER JOIN ( SELECT    e.DepartmentId ,
                                                SUM(e.Salary) AS Sum
                                        FROM      Employees AS e
                                        GROUP BY  e.DepartmentId
                                    ) AS g ON d.id = g.DepartmentId
            ORDER BY Sum DESC")).ToList();
            }
        }
        /// <summary>
        /// List employees (names) who have a bigger salary than their boss
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<string>> GetExpensiveEmployeesAsync()
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return (await connection.QueryAsync<string>
                (@"SELECT  e.FirstName+' '+e.LastName
                    FROM    Employees AS e
                            JOIN Employees AS b ON e.BossId = b.Id
                    WHERE   e.Salary < b.Salary")).ToList();
            }
        }

    }
}
