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

        public async Task VisualNotification(string color)
        {
            var relativeUrl = "api/Users";
            await RestClient.PostNoResponseContentAsync(relativeUrl, color);
        }
    }
}