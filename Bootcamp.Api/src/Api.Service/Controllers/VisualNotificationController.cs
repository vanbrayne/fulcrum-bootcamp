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
        [Route("")]
        [HttpPost]
        public async Task Post(string color)
        {
            ServiceContract.RequireNotNullOrWhitespace(color, nameof(color));

            await _client.VisualNotification(color);
        }
    }
}
