namespace CTI.Asset.Management.Domain.Shared
{
    public interface IDomainEventService
    {
        void Publish(DomainEvent domainEvent);
    }
}