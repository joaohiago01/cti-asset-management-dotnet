using CTI.Asset.Management.Domain.Entities;
using CTI.Asset.Management.Domain.Shared;

namespace CTI.Asset.Management.Domain.Event
{
    public class SoftwareLicenseCreateEvent : DomainEvent
    {
        private SoftwareLicense SoftwareLicense { get; }

        public SoftwareLicenseCreateEvent(SoftwareLicense softwareLicense)
        {
            SoftwareLicense = softwareLicense;
        }
    }
}