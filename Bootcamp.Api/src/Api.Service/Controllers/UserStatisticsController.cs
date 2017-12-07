using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web.Http;
using Api.Service.Dal;
using Api.Service.Models;
using Xlent.Lever.Libraries2.Core.Assert;

namespace Api.Service.Controllers
{
    [RoutePrefix("UserStatistics")]
    public class UserStatisticsController : ApiController
    {
        private readonly ICustomerMasterClient _customerMasterClient;

        public UserStatisticsController(ICustomerMasterClient customerMasterClient)
        {
            _customerMasterClient = customerMasterClient;
        }

        [Route("")]
        [HttpGet]
        public async Task<UserStatistics> Get(string type = null, DateTimeOffset? startInclusive = null, DateTimeOffset? endExclusive = null)
        {
            return await _customerMasterClient.GetStatistics(type, startInclusive, endExclusive);
        }
    }
}
