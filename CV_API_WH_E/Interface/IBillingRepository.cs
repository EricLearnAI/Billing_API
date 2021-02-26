using CV_API_WH_E.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CV_API_WH_E.Interface
{
    public interface IBillingRepository
    {
        Dictionary<string, string> GetGroupingByUnblendedCostByAccountId(string id);
        List<dailyUsage> GetGroupingByUsageAmountByAccountId(string id);
    }
}
