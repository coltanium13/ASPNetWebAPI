using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApiSampleProject
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //All employees or employee by Id.
            config.Routes.MapHttpRoute(
                name: "EmployeeDefault",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //Specific employee by name
            //config.Routes.MapHttpRoute(
            //    name: "EmployeeByName",
            //    routeTemplate: "api/{controller}/{action}/{name}",
            //    defaults: new { name = RouteParameter.Optional }
            //);
        }
    }
}
