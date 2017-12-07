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
        /// Read the user with id <paramref name="id"/>.
        /// </summary>
        /// <returns>The </returns>
        Task<UserStatistics> Read(DateTimeOffset? startInclusive, DateTimeOffset? endInclusive);
    }
}
