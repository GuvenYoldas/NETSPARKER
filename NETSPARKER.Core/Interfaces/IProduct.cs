using NETSPARKER.Core.Interfaces.Base;
using System;

namespace NETSPARKER.Core.Interfaces
{
    public interface IProduct : IBase<int>
    {

        string Name { get; set; }
        string Url { get; set; }
        int Interval { get; set; }
        DateTime? LastMonitorTime { get; set; }
        DateTime NextMonitorTime { get; set; }
    }
}
