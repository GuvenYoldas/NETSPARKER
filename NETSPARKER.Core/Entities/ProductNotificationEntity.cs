using NETSPARKER.Core.Entities.Base;
using NETSPARKER.Core.Interfaces;

namespace NETSPARKER.Core.Entities
{
    public class ProductNotificationEntity : BaseEntity<int>, IProductNotification
    {
        public int IDProduct { get; set; }
        public int IDNotificationType { get; set; }
        public int IDMonitoringInterval { get; set; }

        public virtual ProductEntity Products { get; set; }
    }
}
