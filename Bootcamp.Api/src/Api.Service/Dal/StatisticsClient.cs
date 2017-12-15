using System;
using System.Threading.Tasks;
using Api.Service.Models;
using Microsoft.Rest;

namespace Api.Service.Dal
{
    public class StatisticsClient : BaseClient, IStatisticsClient
    {
        public StatisticsClient(string baseUri, ServiceClientCredentials authenticationCredentials) : base(baseUri, authenticationCredentials)
        {
        }

        public async Task<Statistics> GetStatistics(string type = null, DateTimeOffset? startInclusive = null, DateTimeOffset? endExclusive = null)
        {
            var relativeUrl = "api/Statistics?";
            if (startInclusive != null)
                relativeUrl += $"&startInclusive={startInclusive}";
            if(endExclusive != null)
                relativeUrl += $"&endExclusive={endExclusive}";
            if (type != null)
                relativeUrl += $"&type={type}";

            return await RestClient.GetAsync<Statistics>(relativeUrl);
        }
    }
}