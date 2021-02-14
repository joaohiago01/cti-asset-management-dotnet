using System.Collections.Generic;
using CTI.Asset.Management.Domain.Shared;
using CTI.Asset.Management.Domain.ValueObjects;

namespace CTI.Asset.Management.Domain.Entities
{
    public class SoftwareLicense : AuditableEntity, IHasDomainEvent
    {
        public SoftwareLicenseId SoftwareLicenseId { get; }
        public SoftwareLicenseActivationKey SoftwareLicenseActivationKey { get; }

        public SoftwareLicense(SoftwareLicenseId softwareLicenseId, SoftwareLicenseActivationKey softwareLicenseActivationKey)
        {
            SoftwareLicenseId = softwareLicenseId;
            SoftwareLicenseActivationKey = softwareLicenseActivationKey;
        }

        public List<DomainEvent> DomainEvents { get; set; }
    }
}