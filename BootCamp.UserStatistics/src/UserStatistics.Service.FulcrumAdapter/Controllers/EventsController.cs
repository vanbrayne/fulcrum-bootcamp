﻿using System.Threading.Tasks;
using System.Web.Http;
using UserStatistics.Service.FulcrumAdapter.Contract;
using Xlent.Lever.Authentication.Sdk.Attributes;
using Xlent.Lever.Libraries2.Core.Assert;
using Xlent.Lever.Libraries2.Core.Error.Logic;
using Xlent.Lever.Libraries2.Core.Platform.Authentication;

namespace UserStatistics.Service.FulcrumAdapter.Controllers
{
    /// <summary>
    /// Receive events
    /// </summary>
    [FulcrumAuthorize(AuthenticationRoleEnum.InternalSystemUser)]
    [RoutePrefix("api/Events")]
    public class EventsController : ApiController
    {
        /// <summary>
        /// Subscription for the User.Created event.
        /// </summary>
        /// <param name="eventBody">The event body.</param>
        /// <returns></returns>
        /// <exception cref="FulcrumNotImplementedException"></exception>
        [HttpPost]
        [Route("User/Created/1")]
        public async Task UserCreatedAsync(UserCreatedEvent eventBody)
        {
            ServiceContract.RequireNotNull(eventBody, nameof(eventBody));

            // TODO: implement

            await Task.Yield();
        }

        /// <summary>
        /// Subscription for the User.Created event.
        /// </summary>
        /// <param name="entityName">The name of the entity for the event.</param>
        /// <param name="eventName">The name of the event type of the event</param>
        /// <param name="majorVersion">The major version of the event</param>
        /// <param name="eventBody">The event body.</param>
        /// <returns></returns>
        /// <exception cref="FulcrumNotImplementedException"></exception>
        [HttpPost]
        [Route("{entityName}/{eventName}/{majorVersion}")]
        public Task CatchAllEventsAsync(string entityName, string eventName, int majorVersion, dynamic eventBody)
        {
            ServiceContract.RequireNotNullOrWhitespace(entityName, nameof(entityName));
            ServiceContract.RequireNotNullOrWhitespace(eventName, nameof(eventName));
            ServiceContract.RequireGreaterThanOrEqualTo(1, majorVersion, nameof(majorVersion));
            ServiceContract.RequireNotNull(eventBody, nameof(eventBody));


            throw new FulcrumNotImplementedException($"The event {entityName}.{eventName} version {majorVersion} is not yet supported.");
        }
    }
}
