﻿using CV_API_WH_E.Interface;
using CV_API_WH_E.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CV_API_WH_E.Implement
{
    public class ProductsService: IProductsService
    {
        private IBillingRepository _impl;
        public ProductsService(IBillingRepository impl)
        {
            _impl = impl;
        }

        public Dictionary<string, string> GroupingByUnblendedCost(string accountId)
        {
            return _impl.GetGroupingByUnblendedCostByAccountId(accountId);
        }

        public List<dailyUsage> GroupingByUsageAmount(string accountId)
        {
            return _impl.GetGroupingByUsageAmountByAccountId(accountId);
        }
    }
}
