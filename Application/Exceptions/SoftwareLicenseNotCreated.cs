using System;

namespace CTI.Asset.Management.Application.Exceptions
{
    public class SoftwareLicenseNotCreated : Exception
    {
        public SoftwareLicenseNotCreated() 
            : base("Software License not be created")
        {
            
        }
    }
}