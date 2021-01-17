using Microsoft.EntityFrameworkCore;
using PlainDotNetApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlainDotNetApi.Data
{
    public class PGDatabaseContext : DbContext
    {
        public DbSet<CartModel> Carts { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<UserModel> Users { get; set; }

        public PGDatabaseContext(DbContextOptions<PGDatabaseContext> options) : base(options)
        {
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetProperValues();

            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            SetProperValues();

            return base.SaveChanges();
        }

        private void SetProperValues()
        {
            foreach (var entry in ChangeTracker.Entries<AbstractBaseModel>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreateAt = DateTime.Now;
                        entry.Entity.Id = Guid.NewGuid();
                        break;

                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = DateTime.Now;
                        break;
                }
            }
        }

        //protected override OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //}
    }
}
