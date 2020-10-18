using System;
using System.Collections.Generic;
using System.Text;

namespace NETSPARKER.Common.Helpers
{
    public class CommonGeneral
    {
        public static DateTime GetNextIntervalMonitoringTime(IntervalMonitoring intervalType)
        {
            switch (intervalType)
            {
                case IntervalMonitoring.Hourly:
                    return DateTime.Now.AddHours(1);
                case IntervalMonitoring.Daily:
                    return DateTime.Now.AddDays(1);
                case IntervalMonitoring.Weekly:
                    return DateTime.Now.AddDays(7);
                case IntervalMonitoring.Monthly:
                    return DateTime.Now.AddMonths(1);
                default:
                    return DateTime.Now.AddHours(1);
            }
        }
    }
}
