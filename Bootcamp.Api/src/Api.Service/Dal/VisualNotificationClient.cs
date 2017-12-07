using System;
using System.Threading.Tasks;
using Api.Service.Models;
using Microsoft.Rest;
using System.Collections.Generic;

namespace Api.Service.Dal
{
    public class VisualNotificationClient : BaseClient, IVisualNotificationClient
    {
        public VisualNotificationClient(string baseUri, ServiceClientCredentials authenticationCredentials) : base(baseUri, authenticationCredentials)
        {
        }

        public async Task VisualNotificationSuccessAsync()
        {
            var relativeUrl = $"api/Notifications/Success";
            await RestClient.PostNoResponseContentAsync(relativeUrl);
        }

        public async Task VisualNotificationWarningAsync()
        {
            var relativeUrl = $"api/Notifications/Warning";
            await RestClient.PostNoResponseContentAsync(relativeUrl);
        }

        public async Task VisualNotificationErrorAsync()
        {
            var relativeUrl = $"api/Notifications/Error";
            await RestClient.PostNoResponseContentAsync(relativeUrl);
        }
    }
}