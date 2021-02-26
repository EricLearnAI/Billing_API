using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CV_API_WH_E.Model
{
    public class Billing
    {
        public string LineItemId { get; set; }
        public string PayerAccountId { get; set; }
        public double UnblendedCost { get { return this.UnblendedRate * this.UsageAmount; } }
        public double UnblendedRate { get; set; }
        public string UsageAccountId { get; set; }
        public double UsageAmount { get; set; }
        public DateTime UsageStartDate { get; set; }
        public DateTime UsageEndDate { get; set; }
        public string ProductName { get; set; }
    }
}
