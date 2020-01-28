using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Microdev.ASPNETCore.Models
{
    public class MicrodevDbContext : IdentityDbContext<User>
    {
        public MicrodevDbContext(DbContextOptions<MicrodevDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>()
            .Property(p => p.Salary).HasColumnType("Decimal(10,2)");
        }

    }

}
