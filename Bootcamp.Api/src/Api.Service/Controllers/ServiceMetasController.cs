using System;
using System.Threading.Tasks;
using System.Web.Http;
using Xlent.Lever.KeyTranslator.RestClients.Facade.Clients;
using Xlent.Lever.KeyTranslator.Sdk;
using Xlent.Lever.Libraries2.Core.Assert;
using Xlent.Lever.Libraries2.Core.Health.Logic;
using Xlent.Lever.Libraries2.Core.Health.Model;
using Xlent.Lever.Libraries2.Core.MultiTenant.Model;
using Xlent.Lever.Libraries2.WebApi.Platform.Authentication;

namespace Api.Service.Controllers
{
    [RoutePrefix("api/ServiceMetas")]
    [AllowAnonymous]
    public class ServiceMetasController : ApiController
    {

        private readonly ITenant _tenant;
        private readonly ITranslateClient _translateClient;
        private readonly ITokenRefresherWithServiceClient _tokenRefresher;

        public ServiceMetasController(ITenant tenant, ITranslateClient translateClient, ITokenRefresherWithServiceClient tokenRefresher)
        {
            _tenant = tenant;
            _translateClient = translateClient;
            _tokenRefresher = tokenRefresher;
        }

        [Route("ServiceHealth")]
        [HttpGet]
        public async Task<HealthResponse> ServiceHealthAsync()
        {
            ServiceContract.RequireNotNull(_tenant, nameof(_tenant));
            ServiceContract.RequireValidated(_tenant, nameof(_tenant));

            var aggregator = new ResourceHealthAggregator(_tenant, "Api");
            aggregator.AddHealthResponse(await CheckAuthentication());
            //aggregator.AddHealthResponse(await CheckLogging());
            aggregator.AddHealthResponse(await CheckValueTranslation());
            //CheckVisualNotificationCapability();
            //CheckCustomerMasterCapability();
            //CheckUserStatisticsCapability();
            return aggregator.GetAggregatedHealthResponse();
        }

        private async Task<HealthResponse> CheckAuthentication()
        {
            return await ChackAction("Authentication", async () =>
            {
                var jwt = await _tokenRefresher.GetJwtTokenAsync();
                FulcrumAssert.IsNotNull(jwt);
                FulcrumAssert.IsNotNullOrWhiteSpace(jwt.AccessToken);
            });
        }

        private async Task<HealthResponse> CheckValueTranslation()
        {
            return await ChackAction("Value translation", async () =>
            {
                var type = "fail";
                await new BatchTranslate(_translateClient, "mobile-app", "customer-master")
                    .Add("user.type", "External", translatedValue => type = translatedValue)
                    .ExecuteAsync();
                if (type == "fail") throw new Exception("Could not make translation");
            });
        }


        private async Task<HealthResponse> ChackAction(string resourceName, Func<Task> actionThatThrowsOnFailure)
        {
            HealthResponse.StatusEnum status;
            string message;
            try
            {
                await actionThatThrowsOnFailure();

                status = HealthResponse.StatusEnum.Ok;
                message = "Ok";
            }
            catch (Exception e)
            {
                status = HealthResponse.StatusEnum.Error;
                message = e.Message + " " + e.InnerException?.Message;
            }
            return new HealthResponse
            {
                Resource = resourceName,
                Message = message,
                Status = status
            };
        }
    }
}
