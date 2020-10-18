using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NETSPARKER.Core.Interfaces.Base;

namespace NETSPARKER.API.Models.Base
{
    public abstract class BaseModel : BaseAuditableModel, IBase
    {
    }

    public abstract class BaseModel<TKey> : BaseModel, IBase<TKey>
    {
        [Key]
        [Column(name: "ID", Order = 0)]
        [ScaffoldColumn(false)]
        public virtual TKey ID { get; set; }
    }
}
