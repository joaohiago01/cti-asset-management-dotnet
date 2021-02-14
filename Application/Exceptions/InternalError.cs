using System;

namespace CTI.Asset.Management.Application.Exceptions
{
    public class InternalError : Exception
    {
        public InternalError() 
            : base("Internal error in server")
        {
            
        }
    }
}