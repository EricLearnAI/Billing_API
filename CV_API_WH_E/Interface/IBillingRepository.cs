using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CV_API_WH_E.Interface
{
    public interface IBillingRepository
    {
        Dictionary<string, string> GetGroupingByUnblendedCostByAccountId(string id);
        Dictionary<string, string> GetGroupingByUsageAmountByAccountId(string id);
    }
}
