using System;
using System.Collections.Generic;
using System.Text;

namespace NETSPARKER.Core.Interfaces.Base
{
    public interface IBase
    {

    }

    public interface IBase<TKey>
    {
        TKey ID { get; set; }
    }
}
