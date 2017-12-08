using System.Configuration;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using PhilipsHue.Service.FulcrumAdapter.Logic;
using PhilipsHue.Service.FulcrumAdapter.RestClients;
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
           // var client = ClientHelper.GetClient();
            //builder.RegisterInstance(client).As<IHueClient>().SingleInstance();
            var hueClient = new MockHueClient();

            builder.RegisterInstance(hueClient).As<IHueClient>();

            builder.RegisterType<TenantConfigurationValueProvider>().As<ITenantConfigurationValueProvider>().SingleInstance();

            var organization = ConfigurationManager.AppSettings["Organization"];
            var environment = ConfigurationManager.AppSettings["Environment"];
            var tenant = new Tenant(organization, environment);
            builder.RegisterInstance(tenant).As<ITenant>();

            var apiClient = new ApiClient(ConfigurationManager.AppSettings["Api.Url"]);
            FulcrumApplication.Setup.FullLogger = apiClient;
            builder.RegisterInstance(apiClient).As<IApiClient>().SingleInstance();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}