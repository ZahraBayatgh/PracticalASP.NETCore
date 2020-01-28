using System;

namespace Microdev.Domain.Entities
{
    public class Employee
    {
        public Employee(string firstName, string lastName, int? bossId, decimal salary)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            BossId = bossId;
            Salary = salary;
        }

        public Employee(string firstName, string lastName, int? bossId, decimal salary, int departmentId) : this(firstName, lastName, bossId, salary)
        {
            DepartmentId = departmentId;
        }

        public Employee(int id, string firstName, string lastName, int? bossId, decimal salary, int departmentId) : this(firstName, lastName, bossId, salary, departmentId)
        {
            Id = id;
        }

        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int? BossId { get; private set; }
        public decimal Salary { get; private set; }
        public int DepartmentId { get; private set; }
    }

}
