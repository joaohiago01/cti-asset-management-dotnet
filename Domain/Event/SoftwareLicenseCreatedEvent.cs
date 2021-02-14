using CTI.Asset.Management.Domain.Entities;
using CTI.Asset.Management.Domain.Shared;

namespace CTI.Asset.Management.Domain.Event
{
    public class SoftwareLicenseCreatedEvent : DomainEvent
    {
        private SoftwareLicense SoftwareLicense { get; }

        public SoftwareLicenseCreatedEvent(SoftwareLicense softwareLicense)
        {
            SoftwareLicense = softwareLicense;
        }
    }
}