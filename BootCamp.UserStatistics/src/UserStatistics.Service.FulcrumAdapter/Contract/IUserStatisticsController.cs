using System;
using System.Threading.Tasks;

namespace UserStatistics.Service.FulcrumAdapter.Contract
{
    /// <summary>
    /// Methods for a <see cref="UserStatistics"/> resource.
    /// </summary>
    public interface IUserStatisticsController
    {
        /// <summary>
        /// Read number of created users of optional type.
        /// </summary>
        /// <returns>UserStatistics </returns>
        Task<UserStatistics> Read(string type, DateTimeOffset? startInclusive, DateTimeOffset? endExclusive);
    }
}
