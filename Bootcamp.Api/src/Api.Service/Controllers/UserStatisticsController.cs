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

namespace Api.Service.Controllers
{
    [RoutePrefix("UserStatistics")]
    public class UserStatisticsController : ApiController
    {
        private readonly IUserStatisticsClient _userStatisticsClient;

        public UserStatisticsController(IUserStatisticsClient userStatisticsClient)
        {
            _userStatisticsClient = userStatisticsClient;
        }

        [Route("")]
        [HttpGet]
        public async Task<UserStatistics> Get(string type = null, DateTimeOffset? startInclusive = null, DateTimeOffset? endExclusive = null)
        {
            return await _userStatisticsClient.GetStatistics(type, startInclusive, endExclusive);
        }
    }
}
