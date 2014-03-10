using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;

namespace Monsterbutikken
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Order",
                routeTemplate: "service/{controller}/{id}",
                defaults: new { action = "Get" },
                constraints: new { controller = "Orders", httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            config.Routes.MapHttpRoute(
                name: "basket",
                routeTemplate: "service/{controller}/{action}/{name}",
                defaults: new { navn = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "service/{controller}/{action}",
                defaults: new { action = "Get" }
            );
        }
    }
}
