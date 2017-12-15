using System;
using System.Threading.Tasks;
using System.Web.Http;
using Api.Service.Dal;
using Api.Service.Models;
using Xlent.Lever.KeyTranslator.RestClients.Facade.Clients;
using Xlent.Lever.KeyTranslator.Sdk;

namespace Api.Service.Controllers
{
    [RoutePrefix("Statistics")]
    public class StatisticsController : ApiController
    {
        private readonly ITranslateClient _translateClient;
        private readonly IStatisticsClient _StatisticsClient;

        public StatisticsController(IStatisticsClient StatisticsClient, ITranslateClient translateClient)
        {
            _StatisticsClient = StatisticsClient;
            _translateClient = translateClient;
        }

        [Route("")]
        [HttpGet]
        public async Task<Statistics> Get(string type = null, DateTimeOffset? startInclusive = null, DateTimeOffset? endExclusive = null)
        {
            if (!string.IsNullOrWhiteSpace(type))
            {
                await new BatchTranslate(_translateClient, "mobile-app", "user-statistics")
                    .Add("user.type", type, translatedValue => type = translatedValue)
                    .ExecuteAsync();
            }

            return await _StatisticsClient.GetStatistics(type, startInclusive, endExclusive);
        }
    }
}
