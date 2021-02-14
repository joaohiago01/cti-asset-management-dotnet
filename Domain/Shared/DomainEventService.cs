using Microsoft.Extensions.Logging;

namespace CTI.Asset.Management.Domain.Shared
{
    public class DomainEventService : IDomainEventService
    {
        private readonly ILogger<DomainEventService> _logger;

        public DomainEventService(ILogger<DomainEventService> logger)
        {
            _logger = logger;
            //_mediator = mediator;
        }

        public void Publish(DomainEvent domainEvent)
        {
            _logger.LogInformation("Publishing domain event. Event - {event}", domainEvent.GetType().Name);
        }
    }
}