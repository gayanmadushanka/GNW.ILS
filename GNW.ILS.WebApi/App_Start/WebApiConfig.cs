using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AspnetWebApi2Helpers.Serialization;

namespace GNW.ILS.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Configure Json and Xml formatters to handle cycles
            config.Formatters.JsonPreserveReferences();
            config.Formatters.XmlPreserveReferences();

            //var json = config.Formatters.JsonFormatter;
            //json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            //config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
