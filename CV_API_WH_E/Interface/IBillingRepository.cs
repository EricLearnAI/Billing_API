using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CV_API_WH_E.Interface
{
    public interface IBillingRepository
    {
        Dictionary<string, double> GetGroupingByUnblendedCostByAccountId(string id);
        Dictionary<string, double> GetGroupingByUsageAmountByAccountId(string id);
    }
}
