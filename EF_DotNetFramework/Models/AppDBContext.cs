using System.Data.Entity;

namespace EF_DotNetFramework.Models
{
    class AppDBContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
