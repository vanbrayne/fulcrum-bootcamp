﻿using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using PhilipsHue.Service.FulcrumAdapter;
using Swashbuckle.Application;
using WebActivatorEx;
using Xlent.Lever.Authentication.Sdk.Handlers;
using Xlent.Lever.Libraries2.WebApi.Pipe.Inbound;
#pragma warning disable 1591

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace PhilipsHue.Service.FulcrumAdapter
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            config.Services.Replace(typeof(IExceptionHandler), new ConvertExceptionToFulcrumResponse());
            config.MessageHandlers.Add(new TokenValidationHandler());
            config.MessageHandlers.Add(new SaveCorrelationId());
            config.MessageHandlers.Add(new LogRequestAndResponse());

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
