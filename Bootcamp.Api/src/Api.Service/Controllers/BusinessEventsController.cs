using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using Xlent.Lever.BusinessEvents.Sdk;
using Xlent.Lever.Libraries2.Core.Application;
using Xlent.Lever.Libraries2.Core.Assert;
using Xlent.Lever.Libraries2.Core.Context;
using Xlent.Lever.Libraries2.Core.MultiTenant.Model;
using Xlent.Lever.Libraries2.WebApi.Platform.Authentication;

namespace Api.Service.Controllers
{
    [RoutePrefix("api/BusinessEvents")]
    // TODO: enable [FulcrumAuthorize(AuthenticationRoleEnum.ExternalSystemUser)]
    public class BusinessEventsController : ApiController
    {
        private readonly ITokenRefresherWithServiceClient _tokenRefresher;
        private readonly ITenant _tenant;


        private static readonly string BusinessEventsBaseUrl = ConfigurationManager.AppSettings["BusinessEvents.Url"];
        private readonly string[] _subscribers = { "http://localhost:51752" };

        public BusinessEventsController(ITenant tenant, ITokenRefresherWithServiceClient tokenRefresher)
        {
            _tenant = tenant;
            _tokenRefresher = tokenRefresher;
        }

        [Route("Publish/{id}")]
        [HttpPost]
        public async Task PublishAsync(Guid id, JObject content)
        {
            ServiceContract.RequireNotNull(id, nameof(id));
            ServiceContract.RequireNotDefaultValue(id, nameof(id));

            await new BusinessEvents(BusinessEventsBaseUrl, _tenant, _tokenRefresher.GetServiceClient()).PublishAsync(id, content);
        }

        [Route("{entityName}/{eventName}/{majorVersion}")]
        [HttpPost]
        public async Task PublishMockAsync(string entityName, string eventName, int majorVersion, int minorVersion, JObject content)
        {
            ServiceContract.RequireNotNullOrWhitespace(entityName, nameof(entityName));
            ServiceContract.RequireNotNullOrWhitespace(eventName, nameof(eventName));
            ServiceContract.RequireGreaterThanOrEqualTo(1, majorVersion, nameof(majorVersion));
            ServiceContract.RequireGreaterThanOrEqualTo(0, minorVersion, nameof(minorVersion));

            var correlationId = new CorrelationIdValueProvider().CorrelationId;

            await new BusinessEvents(_tokenRefresher.GetServiceClient(), _subscribers).PublishAsync(entityName, eventName, majorVersion, minorVersion, content, correlationId);
        }
    }
}
