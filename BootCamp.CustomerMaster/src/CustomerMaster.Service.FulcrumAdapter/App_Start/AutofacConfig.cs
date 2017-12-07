using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using CustomerMaster.Service.FulcrumAdapter.Contract;
using Xlent.Lever.Libraries2.Core.MultiTenant.Context;
using Xlent.Lever.Libraries2.Core.Storage.Logic;
using Xlent.Lever.Libraries2.Core.Storage.Model;

#pragma warning disable 1591

namespace CustomerMaster.Service.FulcrumAdapter
{
    public static class AutofacConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<MemoryPersistance<User, string>>().As<ICrud<User, string>>().SingleInstance();

            builder.RegisterType<TenantConfigurationValueProvider>().As<ITenantConfigurationValueProvider>().SingleInstance();
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}