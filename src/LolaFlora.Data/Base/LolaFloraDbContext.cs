using LolaFlora.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace LolaFlora.Data.Base
{
    public class LolaFloraDbContext : DbContext
    {
        public static readonly User Test = new User { Id = 1, Name = "test", Username = "test", Password = "test", CreatedDateTime = DateTime.UtcNow };
        public static readonly Category Tech = new Category { Id = 1, Name = "Tech", CreatedDateTime = DateTime.UtcNow };
        public static readonly Product AsusLaptop = new Product { Id = 1, Name = "PC", Price = "5000", Quantity = 10, CategoryId = 1, CreatedDateTime = DateTime.UtcNow };

        public LolaFloraDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Cart> Cart { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public override int SaveChanges()
        {
            SetBaseFields();
            return base.SaveChanges();
        }

        protected virtual void SetBaseFields()
        {
            var entries = ChangeTracker.Entries().Where(e =>
            {
                return e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified);
            });
            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdatedDateTime = DateTime.UtcNow;
            }
        }
    }
}
