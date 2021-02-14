using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CTI.Asset.Management.Domain.Shared;
using CTI.Asset.Management.Infrastructure.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace CTI.Asset.Management.Infrastructure
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
        private readonly IDomainEventService _domainEventService;

        public ApplicationContext(
            DbContextOptions<ApplicationContext> options,
            IDomainEventService domainEventService)
            : base(options)
        {
            _domainEventService = domainEventService;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.Entity<SoftwareLicenseModel>();
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }

        public DbSet<SoftwareLicenseModel> SoftwareLicenses { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.Now;
                        entry.Entity.CreatedBy = ContextId.ToString();
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = DateTime.Now;
                        entry.Entity.UpdateBy = ContextId.ToString();
                        break;
                    case EntityState.Deleted:
                        entry.Entity.DeletedAt = DateTime.Now;
                        entry.Entity.DeletedBy = ContextId.ToString();
                        break;
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            var result = base.SaveChangesAsync(cancellationToken);

            DispatchEvents();

            return result;
        }
        
        private void DispatchEvents()
        {
            while (true)
            {
                var domainEventEntity = ChangeTracker
                    .Entries<IHasDomainEvent>()
                    .Select(x => x.Entity.DomainEvents)
                    .SelectMany(x => x)
                    .FirstOrDefault(domainEvent => !domainEvent.IsPublished);
                if (domainEventEntity == null) break;

                domainEventEntity.IsPublished = true;
                _domainEventService.Publish(domainEventEntity);
            }
        }
    }
}