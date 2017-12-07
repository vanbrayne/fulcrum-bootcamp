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

        public async Task VisualNotificationSuccessAsync(double seconds)
        {
            var relativeUrl = $"api/Notifications/Success?seconds={seconds}";
            await RestClient.PostNoResponseContentAsync(relativeUrl);
        }

        public async Task VisualNotificationWarningAsync(double seconds)
        {
            var relativeUrl = $"api/Notifications/Warning?seconds={seconds}";
            await RestClient.PostNoResponseContentAsync(relativeUrl);
        }

        public async Task VisualNotificationErrorAsync(double seconds)
        {
            var relativeUrl = $"api/Notifications/Error?seconds={seconds}";
            await RestClient.PostNoResponseContentAsync(relativeUrl);
        }
    }
}