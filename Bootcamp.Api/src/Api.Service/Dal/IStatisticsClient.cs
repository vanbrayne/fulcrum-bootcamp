using System;
using System.Threading.Tasks;
using Api.Service.Models;

namespace Api.Service.Dal
{
    public interface IStatisticsClient : IBaseClient
    {
        Task<Statistics> GetStatistics(string type, DateTimeOffset? startInclusive, DateTimeOffset? endExclusive);
    }
}