using System;
using System.Collections.Generic;
using CTI.Asset.Management.Domain.Shared;

namespace CTI.Asset.Management.Domain.ValueObjects
{
    public class SoftwareLicenseId : ValueObject
    {
        public Guid Id { get; }

        public SoftwareLicenseId(Guid id)
        {
            Id = id;
        }

        public SoftwareLicenseId()
        {
            
        }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }
    }
}