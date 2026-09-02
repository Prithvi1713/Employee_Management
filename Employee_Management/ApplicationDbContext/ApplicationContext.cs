using Employee_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management.ApplicationDbContext
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<DepartmentMaster> departmentMasters { get; set; }
    }
}
