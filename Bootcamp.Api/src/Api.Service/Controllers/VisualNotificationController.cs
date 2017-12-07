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
    [RoutePrefix("api/VisualNotification")]
    public class VisualNotificationController : ApiController
    {
        private readonly IVisualNotificationClient _client;
        public VisualNotificationController(IVisualNotificationClient client)
        {
            _client = client;
        }

        [HttpPost]
        [Route("Success")]
        public async Task SuccessAsync()
        {
            await _client.VisualNotificationSuccessAsync();
        }

        /// <inheritdoc />
        [HttpPost]
        [Route("Warning")]
        public async Task WarningAsync()
        {
            await _client.VisualNotificationWarningAsync();
        }

        /// <inheritdoc />
        [HttpPost]
        [Route("Error")]
        public async Task ErrorAsync()
        {
            await _client.VisualNotificationErrorAsync();
        }
    }
}
