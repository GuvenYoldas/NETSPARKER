using NETSPARKER.Core.Entities.Base;
using NETSPARKER.Core.Interfaces;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System;
using System.Collections.Generic;

namespace NETSPARKER.Core.Entities
{
    public class ProductEntity : BaseEntity<int>, IProduct
    {
        public ProductEntity()
        {
            ProductNotification = new List<ProductNotificationEntity>();
        }

       public string Name { get; set; }
       public string Url { get; set; }
       public int Interval { get; set; }
       public DateTime? LastMonitorTime { get; set; }
       public DateTime NextMonitorTime { get; set; }

        [JsonIgnore, IgnoreDataMember]
        public virtual ICollection<ProductNotificationEntity> ProductNotification { get; set; }
    }
}
