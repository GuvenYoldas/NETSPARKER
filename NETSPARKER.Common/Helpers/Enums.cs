using System;
using System.Collections.Generic;
using System.Text;

namespace NETSPARKER.Common.Helpers
{
    public enum NotificationStatus
    {
        Success,
        NotSend,
        Fail
    }
    public enum IntervalMonitoring
    {
        Hourly,
        Daily,
        Weekly,
        Monthly
    }

    public enum NotificationTypes
    {
        Email
    }
}
