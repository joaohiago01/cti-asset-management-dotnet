using System.Threading.Tasks;

namespace CTI.Asset.Management.Domain.Shared
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}