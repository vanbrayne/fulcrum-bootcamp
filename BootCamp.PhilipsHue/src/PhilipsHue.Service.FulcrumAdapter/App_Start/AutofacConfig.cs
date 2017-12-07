using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using PhilipsHue.Service.FulcrumAdapter.Logic;
using Q42.HueApi;
using Q42.HueApi.Interfaces;
using Xlent.Lever.Libraries2.Core.MultiTenant.Context;

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
        }
    }
}