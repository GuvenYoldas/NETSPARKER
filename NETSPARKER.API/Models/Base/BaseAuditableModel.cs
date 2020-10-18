using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using NETSPARKER.Core.Interfaces.Base;

namespace NETSPARKER.API.Models.Base
{
    public abstract class BaseAuditableModel : IBaseAuditable
    {
        private DateTimeOffset? _createdDateOffsetUtc;

        [ScaffoldColumn(false)]
        public int IDCompany { get; set; }


        [ScaffoldColumn(false)]
        public string IsActive { get; set; }


        [ScaffoldColumn(false)]
        public int? Sequence { get; set; }


        [ScaffoldColumn(false)]
        [JsonIgnore]
        public DateTimeOffset? CreatedDateOffsetUtc { get => _createdDateOffsetUtc ?? DateTimeOffset.UtcNow; set => _createdDateOffsetUtc = value; }


        [ScaffoldColumn(false)]
        [JsonIgnore]
        public string CreatedBy { get; set; }


        [ScaffoldColumn(false)]
        [JsonIgnore]
        public DateTimeOffset? UpdatedDateOffsetUtc { get; set; }


        [ScaffoldColumn(false)]
        [JsonIgnore]
        public string UpdatedBy { get; set; }

    }
}
