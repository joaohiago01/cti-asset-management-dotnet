using System;

namespace CTI.Asset.Management.Domain.Shared
{
    public abstract class DomainEvent
    {
        protected DomainEvent()
        {
            DateOccurred = DateTimeOffset.UtcNow;
        }
        public bool IsPublished { get; set; }
        private DateTimeOffset DateOccurred { get; set; }
    }
}