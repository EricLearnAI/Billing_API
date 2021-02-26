using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CV_API_WH_E.Interface
{
    public interface IProductsService
    {
        Dictionary<string, string> GroupingByUnblendedCost(string accountId);

        Dictionary<string, string> GroupingByUsageAmount(string accountId);
    }
}
