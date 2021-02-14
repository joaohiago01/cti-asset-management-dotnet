using System;

namespace CTI.Asset.Management.Domain.Exceptions
{
    public class ActivationKeyIsEmpty : Exception
    {
        public ActivationKeyIsEmpty() 
            : base("The software license activation key cannot be empty")
        {
            
        }
    }
}