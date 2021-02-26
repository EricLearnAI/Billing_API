using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CV_API_WH_E.Model
{
    public class dailyUsage
    {
        public double UsageAmount { get; set; }
        public DateTime UsageStartDate { get; set; }
        public DateTime UsageEndDate { get; set; }
        public string ProductName { get; set; }
}
}
