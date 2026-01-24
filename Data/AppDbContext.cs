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
       
        public DbSet<Brand> Brands { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Brand>().HasData(
                new Brand
                {
                    BrandId = 1,
                    Name = "X-Force",
                    Description = "Havasız Boya Makinaları",
                    IsActive = true,
                    CreatedDate = new DateTime(2026, 1, 1)
                },
                new Brand
                {
                    BrandId = 2,
                    Name = "Teknobar",
                    Description = "Havalı Makinalar",
                    IsActive = true,
                    CreatedDate = new DateTime(2026, 1, 1)
                }

            ); 
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }

    }

    }