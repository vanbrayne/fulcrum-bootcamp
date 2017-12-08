using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Xlent.Lever.Libraries2.Core.Logging;

namespace UserStatistics.Service.FulcrumAdapter.RestClients
{
    /// <summary>
    /// Publish business events
    /// </summary>
    public interface IApiClient : IFulcrumFullLogger
    {
        /// <summary>
        /// Publish an event
        /// </summary>
        /// <param name="id">The publication id</param>
        /// <param name="eventBody">The event body</param>
        Task PublishAsync(Guid id, JObject eventBody);

        /// <summary>
        /// Make a visual notification for "success"
        /// </summary>
        Task VisualNotificationSuccessAsync();

        /// <summary>
        /// Make a visual notification for "warning"
        /// </summary>
        Task VisualNotificationWarningAsync();

        /// <summary>
        /// Make a visual notification for "error"
        /// </summary>
        Task VisualNotificationErrorAsync();
    }
}