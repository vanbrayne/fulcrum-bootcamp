using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Xlent.Lever.Libraries2.Core.Application;
using Xlent.Lever.Libraries2.Core.Logging;
using Xlent.Lever.Libraries2.Core.Platform.Authentication;
using Xlent.Lever.Libraries2.WebApi.RestClientHelper;

namespace PhilipsHue.Service.FulcrumAdapter.RestClients
{
    /// <summary>
    /// Client for publishing events.
    /// </summary>
    public class ApiClient : BaseClient, IApiClient
    {

        private static readonly HttpClient HttpClient = new HttpClient();
        /// <summary>
        /// Constructor
        /// </summary>
        public ApiClient(string baseUri) : base(baseUri, GetToken(baseUri).Result)
        {
        }

        private static async Task<AuthenticationToken> GetToken(string baseUri)
        {
            var credentials = new AuthenticationCredentials()
            {
                ClientId = FulcrumApplication.AppSettings.GetString("Authentication.ClientId", true),
                ClientSecret = FulcrumApplication.AppSettings.GetString("Authentication.ClientSecret", true)
            };

            const string relativeUrl = "api/Authentication/Tokens";
            var restClient = new RestClient(GetUriStart(baseUri));
            return await restClient.PostAsync<AuthenticationToken, AuthenticationCredentials > (relativeUrl, credentials);
        }

        /// <inheritdoc />
        public async Task PublishAsync(Guid id, JObject eventBody)
        {
            var relativeUrl = $"api/BusinessEvents/Publish/{id}";
            await RestClient.PostAsync<string, JObject>(relativeUrl, eventBody);
        }

        /// <inheritdoc />
        public void Log(LogSeverityLevel logSeverityLevel, string message)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public async Task LogAsync(LogInstanceInformation message)
        {
            var relativeUrl = "api/Logs";
            await RestClient.PostNoResponseContentAsync(relativeUrl, message);
        }

        /// <inheritdoc />
        public async Task VisualNotificationSuccessAsync()
        {
            var relativeUrl = $"api/Notifications/Success";
            await RestClient.PostNoResponseContentAsync(relativeUrl);
        }

        /// <inheritdoc />
        public async Task VisualNotificationWarningAsync()
        {
            var relativeUrl = $"api/Notifications/Warning";
            await RestClient.PostNoResponseContentAsync(relativeUrl);
        }

        /// <inheritdoc />
        public async Task VisualNotificationErrorAsync()
        {
            var relativeUrl = $"api/Notifications/Error";
            await RestClient.PostNoResponseContentAsync(relativeUrl);
        }
    }
}