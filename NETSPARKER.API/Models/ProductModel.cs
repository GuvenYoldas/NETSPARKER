using NETSPARKER.Core.Interfaces;
using NETSPARKER.API.Models.Base;
using System;
using System.Collections.Generic;

namespace NETSPARKER.API.Models
{
    public class ProductModel : BaseModel<int>, IProduct
    {

        public string Name { get; set; }
        public string Url { get; set; }
        public int Interval { get; set; }
        public DateTime? LastMonitorTime { get; set; }
        public DateTime NextMonitorTime { get; set; }
        public virtual ICollection<ProductNotificationModel> ProductNotification{ get; set; }
    }
}
