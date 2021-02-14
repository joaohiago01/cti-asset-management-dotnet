using System.Collections.Generic;
using CTI.Asset.Management.Domain.Exceptions;
using CTI.Asset.Management.Domain.Shared;

namespace CTI.Asset.Management.Domain.ValueObjects
{
    public class SoftwareLicenseActivationKey : ValueObject
    {
        public string ActivationKey { get; }
        
        public SoftwareLicenseActivationKey(string activationKey)
        {
            if (string.IsNullOrEmpty(activationKey))
            {
                throw new ActivationKeyIsEmpty();
            }
            ActivationKey = activationKey;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return ActivationKey;
        }
    }
}