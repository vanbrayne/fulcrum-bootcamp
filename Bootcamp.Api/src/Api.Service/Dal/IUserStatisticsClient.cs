using System;
using System.Threading.Tasks;
using Api.Service.Models;

namespace Api.Service.Dal
{
    public interface IUserStatisticsClient : IBaseClient
    {
        Task<UserStatistics> GetStatistics(string type, DateTimeOffset? startInclusive, DateTimeOffset? endExclusive);
    }
}