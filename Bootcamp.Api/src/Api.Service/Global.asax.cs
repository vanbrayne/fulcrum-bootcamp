using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Xlent.Lever.Libraries2.Core.Application;
using FulcrumApplicationHelper = Xlent.Lever.Libraries2.WebApi.Application.FulcrumApplicationHelper;

namespace Api.Service
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            FulcrumApplicationHelper.WebApiBasicSetup(new ConfigurationManagerAppSettings());

            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configure(SwaggerConfig.Register);
            GlobalConfiguration.Configure(AutofacConfig.Register);

            GlobalConfiguration.Configuration.EnsureInitialized();

        }
    }
}
