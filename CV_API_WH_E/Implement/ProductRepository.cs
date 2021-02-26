using CV_API_WH_E.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CV_API_WH_E.DAL;

namespace CV_API_WH_E.Implement
{
    public class ProductRepository
    {
        private IBillingRepository _repository;
        public ProductRepository(IBillingRepository repository)
        {
            _repository = repository;
        }

        public Dictionary<string, double> GetGroupingByUnblendedCost(string accountid)
        {
            return _repository.GetGroupingByUnblendedCostByAccountId(accountid);
        }
    }
}
