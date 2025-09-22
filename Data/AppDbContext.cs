using Employee_Management_System.Model;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management_System.Data
{
    public class AppDbContext : DbContext
    {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {
            }

            public DbSet<Employee> Employee_Management_System { get; set; }
        
    }
}
