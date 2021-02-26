using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using CV_API_WH_E.Interface;
using CV_API_WH_E.Implement;
using CV_API_WH_E.Response;

namespace CV_API_WH_E.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class Productscontroller : ControllerBase
    {
        private readonly IProductsService _service;

        public Productscontroller(IProductsService service)
        {
            _service = service;
        }

        // GET: api/Products/Grouping/UnblendedCost/610810069647
        [HttpGet("Grouping/UnblendedCost/{accountid}")]
        public ActionResult<Dictionary<string, string>> GetGroupingUnblendedCost(string accountid)
        {
            var result = _service.GroupingByUnblendedCost(accountid);
            if (result == null || result.Count <= 0)
            {
                return NotFound();
            }

            return result;
        }

        // GET: api/Products/Grouping/UsageAmount/610810069647
        [HttpGet("Grouping/UsageAmount/{accountid}")]
        public ActionResult<List<RSPGetGroupingUsageAmount>> GetGroupingUsageAmount(string accountid)
        {
            var result = _service.GroupingByUsageAmount(accountid);
            if (result == null || result.Count <= 0)
            {
                return NotFound();
            }

            List<RSPGetGroupingUsageAmount> resp = new List<RSPGetGroupingUsageAmount>();

            foreach (var dailyusage in result)
            {
                Dictionary<DateTime, string> daysUsage = new Dictionary<DateTime, string>();
                var ts = dailyusage.UsageEndDate.Subtract(dailyusage.UsageStartDate);
                for(int day = 0; day<=ts.Days;day++)
                {
                    var dayusage = dailyusage.UsageStartDate.AddDays(day);
                    var usage = dailyusage.UsageAmount;

                    daysUsage.Add(dayusage, $"sum({usage})");
                }
                RSPGetGroupingUsageAmount usageAmount = new RSPGetGroupingUsageAmount();
                usageAmount.ProductName = dailyusage.ProductName;
                usageAmount.DailyUsage = daysUsage;

                resp.Add(usageAmount);
            }

            return resp;
        }
    }
}
