using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using CV_API_WH_E.Interface;
using CV_API_WH_E.Implement;

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
        public ActionResult<Dictionary<string, string>> GetGroupingUsageAmount(string accountid)
        {
            var result = _service.GroupingByUsageAmount(accountid);
            if (result == null || result.Count <= 0)
            {
                return NotFound();
            }

            return result;
        }
    }
}
