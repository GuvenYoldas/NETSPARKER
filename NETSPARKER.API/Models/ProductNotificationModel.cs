using NETSPARKER.Core.Interfaces;
using NETSPARKER.API.Models.Base;

namespace NETSPARKER.API.Models
{
    public class ProductNotificationModel : BaseModel<int>, IProductNotification
    {
        public int IDProduct { get; set; }
        public int IDNotificationType { get; set; }
        public int IDMonitoringInterval { get; set; }
    }
}
