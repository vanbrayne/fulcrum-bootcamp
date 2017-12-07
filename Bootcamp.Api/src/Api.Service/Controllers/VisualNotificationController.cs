using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Api.Service.Dal;
using Xlent.Lever.Libraries2.Core.Assert;

namespace Api.Service.Controllers
{
    [RoutePrefix("VisualNotification")]
    public class VisualNotificationController : ApiController
    {
        private readonly IVisualNotificationClient _client;
        public VisualNotificationController(IVisualNotificationClient client)
        {
            _client = client;
        }

        [HttpPost]
        [Route("Success")]
        public async Task SuccessAsync(double seconds)
        {
            await _client.VisualNotificationSuccessAsync(seconds);
        }

        /// <inheritdoc />
        [HttpPost]
        [Route("Warning")]
        public async Task WarningAsync(double seconds)
        {
            await _client.VisualNotificationWarningAsync(seconds);
        }

        /// <inheritdoc />
        [HttpPost]
        [Route("Error")]
        public async Task ErrorAsync(double seconds)
        {
            await _client.VisualNotificationErrorAsync(seconds);
        }
    }
}
