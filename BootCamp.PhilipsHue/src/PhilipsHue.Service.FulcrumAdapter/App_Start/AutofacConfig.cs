using System.Configuration;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using PhilipsHue.Service.FulcrumAdapter.Logic;
using Q42.HueApi;
using Q42.HueApi.Interfaces;
using Xlent.Lever.Authentication.Sdk;
using Xlent.Lever.Libraries2.Core.Application;
using Xlent.Lever.Libraries2.Core.MultiTenant.Context;
using Xlent.Lever.Libraries2.Core.MultiTenant.Model;
using Xlent.Lever.Libraries2.Core.Platform.Authentication;
using Xlent.Lever.Libraries2.WebApi.Platform.Authentication;
using Xlent.Lever.Logger.Sdk;
using Xlent.Lever.Logger.Sdk.RestClients;

#pragma warning disable 1591

namespace PhilipsHue.Service.FulcrumAdapter
{
    public static class AutofacConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            var client = ClientHelper.GetClient();
            builder.RegisterInstance(client).As<IHueClient>().SingleInstance();

            builder.RegisterType<TenantConfigurationValueProvider>().As<ITenantConfigurationValueProvider>().SingleInstance();
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            var organization = ConfigurationManager.AppSettings["Organization"];
            var environment = ConfigurationManager.AppSettings["Environment"];
            var tenant = new Tenant(organization, environment);
            builder.RegisterInstance(tenant).As<ITenant>();

            var tokenRefresher = RegisterAuthentication(builder, tenant);

            RegisterLogging(tokenRefresher);
        }

        private static void RegisterLogging(ITokenRefresherWithServiceClient tokenRefresher)
        {
            // Logging
            var loggerBaseUrl = FulcrumApplication.AppSettings.GetString("Logger.Url", true);
            var logClient = new LogClient(loggerBaseUrl, tokenRefresher.GetServiceClient());
            FulcrumApplication.Setup.FullLogger = new FulcrumLogger(logClient);
        }

        private static ITokenRefresherWithServiceClient RegisterAuthentication(ContainerBuilder builder, Tenant tenant)
        {
            var authenticationUrl = ConfigurationManager.AppSettings["Authentication.Url"];
            var authenticationClientId = ConfigurationManager.AppSettings["Authentication.ClientId"];
            var authenticationClientSecret = ConfigurationManager.AppSettings["Authentication.ClientSecret"];
            var authServiceCredentials = new AuthenticationCredentials { ClientId = "user", ClientSecret = "pwd" };

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
    }
}