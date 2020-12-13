using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RideShareRestApi.Entity.Models
{
    public class RideShareContext : DbContext
    {
        public RideShareContext(DbContextOptions<RideShareContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<TravelPlan> TravelPlans { get; set; }
        public DbSet<TravelPassenger> TravelPassengers { get; set; }
        public DbSet<City> Cities { get; set; }

        public override int SaveChanges()
        {
            var date = DateTime.Now;

            var addedEntities = ChangeTracker.Entries<BaseEntity>()
                .Where(e => e.State == EntityState.Added)
                .ToList();

            addedEntities.ForEach(e =>
            {
                e.Entity.CreatedAt = date;
                e.Entity.UpdatedAt = date;
            });

            var modifiedEntities = ChangeTracker.Entries<BaseEntity>()
                .Where(e => e.State == EntityState.Modified)
                .ToList();

            modifiedEntities.ForEach(e => { e.Entity.UpdatedAt = date; });

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default
        )
        {
            var date = DateTime.Now;
            var addedEntities = ChangeTracker.Entries<BaseEntity>()
                .Where(e => e.State == EntityState.Added)
                .ToList();

            addedEntities.ForEach(e =>
            {
                e.Entity.CreatedAt = date;
                e.Entity.UpdatedAt = date;
            });

            var modifiedEntities = ChangeTracker.Entries<BaseEntity>()
                .Where(e => e.State == EntityState.Modified)
                .ToList();

            modifiedEntities.ForEach(e => { e.Entity.UpdatedAt = date; });

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
