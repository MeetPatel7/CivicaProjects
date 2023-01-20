using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Models
{
    public class DepartmentContext : DbContext
    {
        public DepartmentContext(DbContextOptions<DepartmentContext> options) : base(options)
        { }
        public DbSet<Department> Department { get; set; }
    }
}
