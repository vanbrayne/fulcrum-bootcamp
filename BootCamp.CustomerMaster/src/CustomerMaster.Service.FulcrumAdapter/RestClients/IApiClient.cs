using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Xlent.Lever.Libraries2.Core.Logging;

namespace CustomerMaster.Service.FulcrumAdapter.RestClients
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
        /// Publish an event
        /// </summary>
        Task PublishAsync(string entityName, string eventName, int majorVersion, int minorVersion, JObject eventBody);

        /// <summary>
        /// Make a visual notification with status Success
        /// </summary>
        Task VisualNotificationSuccessAsync();

        /// <summary>
        /// Make a visual notification with status Warning
        /// </summary>
        Task VisualNotificationWarningAsync();

        /// <summary>
        /// Make a visual notification with status Error
        /// </summary>

        Task VisualNotificationErrorAsync();
    }
}