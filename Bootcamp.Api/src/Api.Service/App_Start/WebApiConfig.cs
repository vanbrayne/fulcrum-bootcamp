using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Swashbuckle.Application;
using Xlent.Lever.Authentication.Sdk.Handlers;
using Xlent.Lever.Libraries2.WebApi.Pipe.Inbound;

namespace Api.Service
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            //Declare the project to return JSON instead of XML
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            //Replace ExceptionHandler with a custom handler
            config.Services.Replace(typeof(IExceptionHandler), new ConvertExceptionToFulcrumResponse());
            config.MessageHandlers.Add(new SaveCorrelationId());
            config.MessageHandlers.Add(new TokenValidationHandler());

            // Web API routes
            config.MapHttpAttributeRoutes();

            // Redirect root to Swagger UI
            config.Routes.MapHttpRoute(
                name: "Swagger UI",
                routeTemplate: "",
                defaults: null,
                constraints: null,
                handler: new RedirectHandler(SwaggerDocsConfig.DefaultRootUrlResolver, "swagger/ui/index"));

        }
    }
}
