using Microsoft.AspNetCore.Identity;   
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

            var hasher = new PasswordHasher<AdminUser>();

            modelBuilder.Entity<AdminUser>().HasData(
                new AdminUser
                {
                    Id = 1,
                    Username = "teknoforce",
                    Password = hasher.HashPassword(null!, "Tf@2026TEKNOFORCE."),
                    FailedLoginCount = 0
                }
            );

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

            modelBuilder.Entity<Product>()
                 .HasOne(p => p.Category)
                 .WithMany()
                 .HasForeignKey(p => p.CategoryId)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Brand)
                .WithMany()
                .HasForeignKey(p => p.BrandId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Specification)
                .WithOne(s => s.Product)
                .HasForeignKey<ProductSpecification>(s => s.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ContactPhone>()
                .HasOne(cp => cp.ContactBranch)
                .WithMany(cb => cb.ContactPhones)
                .HasForeignKey(cp => cp.ContactBranchId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<OrderItem>()
                .Property(o => o.UnitPrice)
                .HasPrecision(18, 2);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSpecification> ProductSpecifications { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<AboutContent> AboutContents { get; set; }
        public  DbSet<ContactContent> ContactContents { get; set; }
        public DbSet<ContactBranch> ContactBranches { get; set; }
        public DbSet<ContactPhone> ContactPhones { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<ProductMedia> ProductMedias { get; set; }
    }

}