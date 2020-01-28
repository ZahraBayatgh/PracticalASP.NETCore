using Microdev.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Microdev.Infrastructure.Data
{
    public class MicrodevAppDbContext : DbContext
    {
        public MicrodevAppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>().ToTable("Department");

            modelBuilder.Entity<Department>().HasData(
                new Department(id: 1, name: "Programming"),
                new Department(id: 2, name: "Fasico"),
                new Department(id: 3, name: "IT"),
                new Department(id: 4, name: "BFC")
                );
            modelBuilder.Entity<Employee>()
                 .Property(p => p.Salary).HasColumnType("Decimal(10,2)");


            modelBuilder.Entity<Employee>().HasData(
                 new Employee(id: 1, firstName: "Zahra", lastName: "Bayat", bossId: 2, salary: 2000, departmentId: 1),
                 new Employee(id: 2, firstName: "Ali", lastName: "Bayat", bossId: 1, salary: 3000, departmentId: 1),
                 new Employee(id: 3, firstName: "Sara", lastName: "Masoodi", bossId: 1, salary: 3000, departmentId: 1),
                 new Employee(id: 4, firstName: "Mehdi", lastName: "Mohamadi", bossId: 1, salary: 3000, departmentId: 1),
                 new Employee(id: 5, firstName: "Amin", lastName: "Sadeghi", bossId: 1, salary: 1000, departmentId: 1),
                 new Employee(id: 6, firstName: "Shadi", lastName: "Sohbati", bossId: 2, salary: 1000, departmentId: 1),
                 new Employee(id: 7, firstName: "Somaye", lastName: "Mahdavi", bossId: 2, salary: 1000, departmentId: 2),
                 new Employee(id: 8, firstName: "Maryam", lastName: "Zahedi", bossId: 2, salary: 1000, departmentId: 2),
                 new Employee(id: 9, firstName: "Mary", lastName: "Zibayee", bossId: 2, salary: 1000, departmentId: 2)
                );
        }

    }

}
