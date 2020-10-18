using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using NETSPARKER.Core.Interfaces.Base;

namespace NETSPARKER.Core.Entities.Base
{
    public abstract class BaseAuditableEntity : IBaseAuditable
    {
        private DateTimeOffset? _createdDateOffsetUtc;

        public int IDCompany { get; set; }

        [ScaffoldColumn(false)]
        public string IsActive { get; set; }


        [ScaffoldColumn(false)]
        public int? Sequence { get; set; }

        [ScaffoldColumn(false)]
        public DateTimeOffset? CreatedDateOffsetUtc { get => _createdDateOffsetUtc ?? DateTimeOffset.UtcNow; set => _createdDateOffsetUtc = value; }

        [ScaffoldColumn(false)]
        public string CreatedBy { get; set; }

        [ScaffoldColumn(false)]
        public string CreatedIp { get; set; }

    
        public DateTimeOffset? UpdatedDateOffsetUtc { get; set; }

        public string UpdatedBy { get; set; }


        public string UpdatedIp { get; set; }


    }
}
