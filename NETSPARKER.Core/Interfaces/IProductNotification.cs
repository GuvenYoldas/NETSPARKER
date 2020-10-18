using NETSPARKER.Core.Interfaces.Base;
using System;


namespace NETSPARKER.Core.Interfaces
{
    public interface IProductNotification : IBase<int> 
    {
        int IDProduct { get; set; }
        int IDNotificationType { get; set; }
        int IDMonitoringInterval { get; set; }

    }
}
