using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Xlent.Lever.Libraries2.Core.Application;
using Xlent.Lever.Libraries2.Core.Assert;
using Xlent.Lever.Libraries2.Core.Logging;
using Xlent.Lever.Libraries2.Core.Platform.Authentication;
using Xlent.Lever.Libraries2.WebApi.RestClientHelper;

namespace CustomerMaster.Service.FulcrumAdapter.RestClients
{
    /// <summary>
    /// Client for publishing events.
    /// </summary>
    public class ApiClient : BaseClient, IApiClient
    {
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
            return await restClient.PostAsync<AuthenticationToken, AuthenticationCredentials> (relativeUrl, credentials);
        }

        /// <inheritdoc />
        public async Task PublishAsync(Guid id, JObject eventBody)
        {
            var relativeUrl = $"api/BusinessEvents/Publish/{id}";
            await RestClient.PostNoResponseContentAsync(relativeUrl, eventBody);
        }

        /// <inheritdoc />
        public async Task PublishAsync(string entityName, string eventName, int majorVersion, int minorVersion, JObject eventBody)
        {
            InternalContract.RequireNotNullOrWhitespace(entityName, nameof(entityName));
            InternalContract.RequireNotNullOrWhitespace(eventName, nameof(eventName));
            InternalContract.RequireGreaterThanOrEqualTo(1, majorVersion, nameof(majorVersion));
            InternalContract.RequireGreaterThanOrEqualTo(0, minorVersion, nameof(minorVersion));

            FulcrumAssert.IsTrue(FulcrumApplication.IsInDevelopment, $"This method can only be called in run time level Development. The run time level was {FulcrumApplication.Setup.RunTimeLevel}");
            var relativeUrl = $"api/BusinessEvents/{entityName}/{eventName}/{majorVersion}/{minorVersion}";
            await RestClient.PostNoResponseContentAsync(relativeUrl, eventBody);
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
            var relativeUrl = $"api/VisualNotifications/Success";
            await RestClient.PostNoResponseContentAsync(relativeUrl);
        }

        /// <inheritdoc />
        public async Task VisualNotificationWarningAsync()
        {
            var relativeUrl = $"api/VisualNotifications/Warning";
            await RestClient.PostNoResponseContentAsync(relativeUrl);
        }

        /// <inheritdoc />
        public async Task VisualNotificationErrorAsync()
        {
            var relativeUrl = $"api/VisualNotifications/Error";
            await RestClient.PostNoResponseContentAsync(relativeUrl);
        }
    }
}