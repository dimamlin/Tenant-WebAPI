using Microsoft.EntityFrameworkCore;
using TestTask.Data.Models;

namespace TestTask.Data
{
    public class AppDBContent : DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options) { }

        public DbSet<Tenant> Tenant { get; set; }

        public DbSet<Apartments> Apartments { get; set; }
    }
}
