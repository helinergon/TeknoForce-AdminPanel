using Microsoft.EntityFrameworkCore;
using TeknoForce.Data.Models;

namespace TeknoForce.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<AdminUser> AdminUsers { get; set; }
    }
}