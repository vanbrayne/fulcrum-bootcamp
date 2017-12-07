using System;
using System.Threading.Tasks;
using Microsoft.Rest;
using Newtonsoft.Json.Linq;

namespace CustomerMaster.Service.FulcrumAdapter.RestClients
{
    /// <summary>
    /// Client for publishing events.
    /// </summary>
    public class PublishClient : BaseClient, IPublishClient
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public PublishClient(string baseUri, ServiceClientCredentials authenticationCredentials) : base(baseUri, authenticationCredentials)
        {
        }

        /// <inheritdoc />
        public async Task PublishAsync(Guid id, JObject eventBody)
        {
            var relativeUrl = $"api/Publish/{id}";
            await RestClient.PostAsync<string, JObject>(relativeUrl, eventBody);
        }
    }
}