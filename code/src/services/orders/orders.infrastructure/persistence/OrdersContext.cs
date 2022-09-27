using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using orders.domain.common;
using orders.domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orders.infrastructure.persistence
{
    public class OrdersContext : DbContext
    {
        private readonly IConfiguration configuration;

        public OrdersContext(IConfiguration configuration):base()
        {
            this.configuration = configuration;
        }

        public DbSet<Order> orders { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    case EntityState.Deleted:
                        break;
                    case EntityState.Modified:
                        entry.Entity.modifed = DateTime.Now;
                        entry.Entity.modified_by = "client";
                        break;
                    case EntityState.Added:
                        entry.Entity.created = DateTime.Now;
                        entry.Entity.created_by = "client";
                        break;
                    default:
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                if(string.IsNullOrEmpty(entry.Entity.created_by))
                    entry.State = EntityState.Added;
                switch (entry.State)
                {
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    case EntityState.Deleted:
                        break;
                    case EntityState.Modified:
                        entry.Entity.modifed = DateTime.Now;
                        entry.Entity.modified_by = "client";
                        break;
                    case EntityState.Added:
                        entry.Entity.created = DateTime.Now;
                        entry.Entity.created_by = "client";
                        break;
                    default:
                        break;
                }
            }

            return base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = configuration.GetConnectionString("OrdersConnectionString");

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString, x => {
                    x.EnableRetryOnFailure();
                });
            }
        }
    }
}
