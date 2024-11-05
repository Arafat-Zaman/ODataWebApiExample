using Microsoft.EntityFrameworkCore;
using ODataWebApiExample.Models;

namespace ODataWebApiExample.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics" },
                new Category { Id = 2, Name = "Books" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Price = 999.99M, CategoryId = 1 },
                new Product { Id = 2, Name = "Novel", Price = 19.99M, CategoryId = 2 }
            );
        }
    }
}
