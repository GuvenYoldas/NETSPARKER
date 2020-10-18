using System;
using System.Collections.Generic;
using System.Text;

namespace NETSPARKER.Core.Interfaces.Base
{
    public interface IBaseAuditable
    {
        int IDCompany { get; set; }

        string IsActive { get; set; }
        int? Sequence { get; set; }
        DateTimeOffset? CreatedDateOffsetUtc { get; set; }

        string CreatedBy { get; set; }

        DateTimeOffset? UpdatedDateOffsetUtc { get; set; }

        string UpdatedBy { get; set; }

  


    }
}
