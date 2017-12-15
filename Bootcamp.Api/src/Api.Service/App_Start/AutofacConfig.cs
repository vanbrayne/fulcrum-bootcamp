using System.Configuration;
using System.Reflection;
using System.Web.Http;
using Api.Service.Dal;
using Autofac;
using Autofac.Integration.WebApi;
using Xlent.Lever.Authentication.Sdk;
using Xlent.Lever.KeyTranslator.RestClients.Facade.Clients;
using Xlent.Lever.Libraries2.Core.Application;
using Xlent.Lever.Libraries2.Core.MultiTenant.Model;
using Xlent.Lever.Libraries2.Core.Platform.Authentication;
using Xlent.Lever.Libraries2.WebApi.Platform.Authentication;
using Xlent.Lever.Logger.Sdk;
using Xlent.Lever.Logger.Sdk.RestClients;

namespace Api.Service
{
    public class AutofacConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            //Register components in BLL and DAL
            RegisterDataAccessLayer(builder);

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //Register a IDependencyResolver used by WebApi 
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        #region RegistrationMethods

        private static void RegisterDataAccessLayer(ContainerBuilder builder)
        {
            var organization = ConfigurationManager.AppSettings["Organization"];
            var environment = ConfigurationManager.AppSettings["Environment"];
            var tenant = new Tenant(organization, environment);
            builder.RegisterInstance(tenant).As<ITenant>();

            var authServiceCredentials = new AuthenticationCredentials { ClientId = "user", ClientSecret = "pwd" };

            var tokenRefresher = RegisterAuthentication(builder, tenant, authServiceCredentials);

            RegisterLogging(tokenRefresher);


            var authenticationService = new AuthenticationService(ConfigurationManager.AppSettings["Authentication.Url"], tenant,
                authServiceCredentials);
            builder.RegisterInstance(authenticationService).As<IAuthenticationService>();

            var translateClient = new TranslateClient(ConfigurationManager.AppSettings["KeyTranslator.Url"], tenant,
                tokenRefresher.GetServiceClient());
            builder.RegisterInstance(translateClient).As<ITranslateClient>();

            var customerMasterClient = new CustomerMasterClient(ConfigurationManager.AppSettings["CustomerMaster.Url"],
                tokenRefresher.GetServiceClient());
            builder.RegisterInstance(customerMasterClient).As<ICustomerMasterClient>();

            var StatisticsClient = new StatisticsClient(ConfigurationManager.AppSettings["Statistics.Url"],
                tokenRefresher.GetServiceClient());
            builder.RegisterInstance(StatisticsClient).As<IStatisticsClient>();

            var visualNotificationClient = new VisualNotificationClient(ConfigurationManager.AppSettings["VisualNotification.Url"],
                tokenRefresher.GetServiceClient());
            builder.RegisterInstance(visualNotificationClient).As<IVisualNotificationClient>();
        }

        private static void RegisterLogging(ITokenRefresherWithServiceClient tokenRefresher)
        {
            // Logging
            var loggerBaseUrl = FulcrumApplication.AppSettings.GetString("Logger.Url", true);
            var logClient = new LogClient(loggerBaseUrl, tokenRefresher.GetServiceClient());
            FulcrumApplication.Setup.FullLogger = new FulcrumLogger(logClient);
        }

        private static ITokenRefresherWithServiceClient RegisterAuthentication(ContainerBuilder builder, Tenant tenant, AuthenticationCredentials authServiceCredentials)
        {
            var authenticationUrl = ConfigurationManager.AppSettings["Authentication.Url"];
            var authenticationClientId = ConfigurationManager.AppSettings["Authentication.ClientId"];
            var authenticationClientSecret = ConfigurationManager.AppSettings["Authentication.ClientSecret"];

            IAuthenticationCredentials authTokenCredentials =
                new AuthenticationCredentials
                {
                    ClientId = authenticationClientId,
                    ClientSecret = authenticationClientSecret
                };

            var tokenRefresher = AuthenticationManager.CreateTokenRefresher(tenant, authenticationUrl,
                authServiceCredentials, authTokenCredentials);
            builder.RegisterInstance(tokenRefresher).As<ITokenRefresherWithServiceClient>();
            return tokenRefresher;
        }

        #endregion
    }
}