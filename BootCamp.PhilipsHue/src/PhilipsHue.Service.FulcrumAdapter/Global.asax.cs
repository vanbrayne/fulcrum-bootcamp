using System.Web.Http;
using Xlent.Lever.Libraries2.Core.Application;
using FulcrumApplicationHelper = Xlent.Lever.Libraries2.WebApi.Application.FulcrumApplicationHelper;
#pragma warning disable 1591

namespace PhilipsHue.Service.FulcrumAdapter
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            FulcrumApplicationHelper.WebApiBasicSetup(new ConfigurationManagerAppSettings());

            GlobalConfiguration.Configure(config =>
            {
                AutofacConfig.Register(config);
                WebApiConfig.Register(config);
            });
        }
    }
}
