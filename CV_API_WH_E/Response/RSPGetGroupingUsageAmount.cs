using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CV_API_WH_E.Response
{
    public class RSPGetGroupingUsageAmount
    {
        public string ProductName { get; set; }
        public Dictionary<string, string> DailyUsage { get; set; }
    }
}
