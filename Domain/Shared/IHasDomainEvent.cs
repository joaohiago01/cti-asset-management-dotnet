using System.Collections.Generic;

namespace CTI.Asset.Management.Domain.Shared
{
    public interface IHasDomainEvent
    {
        public List<DomainEvent> DomainEvents { get; set; }
    }
}