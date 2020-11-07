using LolaFlora.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace LolaFlora.Data.Base
{
    public class LolaFloraDbContext : DbContext
    {

        public LolaFloraDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Cart> Cart { get; set; }
        public DbSet<User> Users { get; set; }

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
                //if (entityEntry.State == EntityState.Added)
                //{
                //    ((BaseEntity)entityEntry.Entity).CreatedDateTime = DateTime.UtcNow;
                //}
            }
        }
    }
}
