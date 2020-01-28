using System.Collections.Generic;

namespace Microdev.Domain.Entities
{
    public class Department
    {
        public Department(string name)
        {
            _employees = new List<Employee>();
            Name = name;
        }
        public Department(int id, string name) : this(name)
        {
            Id = id;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        private readonly List<Employee> _employees;
        public IReadOnlyCollection<Employee> Employees => _employees;
        public void UpdateName(string name)
        {
            //Domain rule
            Name = name;
            //Raise domain event
        }
        public void AddEmployee(string firstName, string lastName, int? bossId, decimal salary)
        {
            // Domain rules for adding the Employee to the Department

            var employee = new Employee(firstName, lastName, bossId, salary);

            _employees.Add(employee);
        }
    }
}
