using Microsoft.EntityFrameworkCore;

namespace Rizz.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // İleride tablolar buraya gelecek
        // public DbSet<User> Users { get; set; }
    }
}