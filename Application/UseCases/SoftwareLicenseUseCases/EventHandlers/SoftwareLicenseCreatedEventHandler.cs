using System.Threading;
using System.Threading.Tasks;
using CTI.Asset.Management.Domain.Event;
using CTI.Asset.Management.Domain.Shared;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CTI.Asset.Management.Application.UseCases.SoftwareLicenseUseCases.EventHandlers
{
    public class SoftwareLicenseCreatedEventHandler : INotificationHandler<DomainEventNotification<SoftwareLicenseCreatedEvent>>
    {
        private readonly ILogger<SoftwareLicenseCreatedEventHandler> _logger;

        public SoftwareLicenseCreatedEventHandler(ILogger<SoftwareLicenseCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(DomainEventNotification<SoftwareLicenseCreatedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            return Task.CompletedTask;
        }
    }
}