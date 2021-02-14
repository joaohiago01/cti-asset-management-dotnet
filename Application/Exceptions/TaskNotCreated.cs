using System;

namespace CTI.Asset.Management.Application.Exceptions
{
    public class TaskNotCreated : Exception
    {
        public TaskNotCreated() 
            : base("Task not be created")
        {
            
        }
    }
}