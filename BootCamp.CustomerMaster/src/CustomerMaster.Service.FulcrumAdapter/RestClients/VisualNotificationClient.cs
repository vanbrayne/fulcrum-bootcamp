using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using CustomerMaster.Service.FulcrumAdapter.Contract;
using Microsoft.Rest;

namespace CustomerMaster.Service.FulcrumAdapter.Dal
{
    /// <summary>
    /// HueClient
    /// </summary>
    public class VisualNotificationClient : BaseClient, IVisualNotificationClient
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseUri"></param>
        /// <param name="authenticationCredentials"></param>
        public VisualNotificationClient(string baseUri, ServiceClientCredentials authenticationCredentials) : base(baseUri, authenticationCredentials)
        {
        }

        /// <inheritdoc />
        public async Task VisualNotificationSuccessAsync(double seconds)
        {
            var relativeUrl = "api/VisualNotification/Success";
            relativeUrl += $"?seconds={seconds}";
            await RestClient.PostNoResponseContentAsync(relativeUrl);
        }

        /// <inheritdoc />
        public async Task VisualNotificationWarningAsync(double seconds)
        {
            var relativeUrl = "api/VisualNotification/Warning";
            relativeUrl += $"?seconds={seconds}";
            await RestClient.PostNoResponseContentAsync(relativeUrl);
        }

        /// <inheritdoc />
        public async Task VisualNotificationErrorAsync(double seconds)
        {
            var relativeUrl = "api/VisualNotification/Error";
            relativeUrl += $"?seconds={seconds}";
            await RestClient.PostNoResponseContentAsync(relativeUrl);
        }
    }
}