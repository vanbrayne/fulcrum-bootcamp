using System.Threading.Tasks;
using Microsoft.Rest;
#pragma warning disable 1591

namespace UserStatistics.Service.FulcrumAdapter.RestClient
{
    public class VisualNotificationClient : BaseClient, IVisualNotificationClient
    {
        public VisualNotificationClient(string baseUri, ServiceClientCredentials authenticationCredentials) : base(baseUri, authenticationCredentials)
        {
        }

        public async Task VisualNotificationSuccessAsync(double? seconds = null)
        {
            var relativeUrl = $"api/Notifications/Success?seconds={seconds}";
            await RestClient.PostNoResponseContentAsync(relativeUrl);
        }

        public async Task VisualNotificationWarningAsync(double? seconds = null)
        {
            var relativeUrl = $"api/Notifications/Warning?seconds={seconds}";
            await RestClient.PostNoResponseContentAsync(relativeUrl);
        }

        public async Task VisualNotificationErrorAsync(double? seconds = null)
        {
            var relativeUrl = $"api/Notifications/Error?seconds={seconds}";
            await RestClient.PostNoResponseContentAsync(relativeUrl);
        }
    }
}