using System;
using System.Threading.Tasks;
using System.Web.Http;
using Api.Service.Dal;
using Xlent.Lever.KeyTranslator.RestClients.Facade.Clients;
using Xlent.Lever.KeyTranslator.Sdk;
using Xlent.Lever.Libraries2.Core.Assert;
using Xlent.Lever.Libraries2.Core.Health.Logic;
using Xlent.Lever.Libraries2.Core.Health.Model;
using Xlent.Lever.Libraries2.Core.Logging;
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
        private readonly IVisualNotificationClient _visualNotificationClient;
        private readonly ICustomerMasterClient _customerMasterClient;
        private readonly IStatisticsClient _StatisticsClient;

        public ServiceMetasController(ITenant tenant, ITranslateClient translateClient, ITokenRefresherWithServiceClient tokenRefresher, IVisualNotificationClient visualNotificationClient, ICustomerMasterClient customerMasterClient, IStatisticsClient StatisticsClient)
        {
            _tenant = tenant;
            _translateClient = translateClient;
            _tokenRefresher = tokenRefresher;
            _visualNotificationClient = visualNotificationClient;
            _customerMasterClient = customerMasterClient;
            _StatisticsClient = StatisticsClient;
        }

        [Route("ServiceHealth")]
        [HttpGet]
        public async Task<HealthResponse> ServiceHealthAsync()
        {
            ServiceContract.RequireNotNull(_tenant, nameof(_tenant));
            ServiceContract.RequireValidated(_tenant, nameof(_tenant));

            var aggregator = new ResourceHealthAggregator(_tenant, "Api");
            aggregator.AddHealthResponse(await CheckAuthentication());
            aggregator.AddHealthResponse(await CheckLogging());
            aggregator.AddHealthResponse(await CheckValueTranslation());
            aggregator.AddHealthResponse(await CheckVisualNotificationCapability());
            aggregator.AddHealthResponse(await CheckCustomerMasterCapability());
            aggregator.AddHealthResponse(await CheckStatisticsCapability());
            return aggregator.GetAggregatedHealthResponse();
        }

        private async Task<HealthResponse> CheckWithBaseClient(string resourceName, IBaseClient baseClient)
        {
            try
            {
                var response = await baseClient.GetServiceHealthAsync();
                return response;
            }
            catch (Exception e)
            {
                return new HealthResponse
                {
                    Resource = resourceName,
                    Status = HealthResponse.StatusEnum.Error,
                    Message = $"{baseClient.BaseUri} {e.ToLogString(true)}"
                };
            }
        }
        private async Task<HealthResponse> CheckStatisticsCapability()
        {
            return await CheckWithBaseClient("User Statistics Capability", _StatisticsClient);
        }

        private async Task<HealthResponse> CheckCustomerMasterCapability()
        {
            return await CheckWithBaseClient("Customer Master Capability", _customerMasterClient);
        }

        private async Task<HealthResponse> CheckVisualNotificationCapability()
        {
            return await CheckWithBaseClient("Visual Notification Capability", _visualNotificationClient);
        }

        private async Task<HealthResponse> CheckLogging()
        {
            return await ChackAction("Logging", () =>
            {
                Log.LogInformation("Api Service Health Check");
                return Task.CompletedTask;
            });
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
