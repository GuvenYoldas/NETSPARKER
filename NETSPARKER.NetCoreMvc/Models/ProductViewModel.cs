using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using NETSPARKER.Common.Helpers;

namespace NETSPARKER.NetCoreMvc.Models
{
    public class ProductViewModel
    {
        public int? id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Url { get; set; }
        public int Interval { get; set; }
        public DateTime? LastMonitorTime { get; set; }
        public DateTime NextMonitorTime { get; set; }
        public List<NotificationTypes> NotificationTypes { get; set; }
    }
}
