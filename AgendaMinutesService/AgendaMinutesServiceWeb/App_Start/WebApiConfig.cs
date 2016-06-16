using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AgendaMinutesServiceWeb
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Formatters.Clear();
            config.Formatters.Add(new CustomJSONFormatter());

            config.Routes.MapHttpRoute(
                name: "GetByID",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { Action = "Get" }
            );

            config.Routes.MapHttpRoute(
                name: "GetList",
                routeTemplate: "api/{controller}",
                defaults: new { Action = "Get" });

            
        }
    }
}
