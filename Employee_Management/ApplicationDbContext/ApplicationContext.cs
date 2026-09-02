using Microsoft.EntityFrameworkCore;

namespace Employee_Management.ApplicationDbContext
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
    }
}
