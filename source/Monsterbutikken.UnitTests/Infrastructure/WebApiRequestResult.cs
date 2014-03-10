using System;
using System.Web.Http.Routing;

namespace Monsterbutikken.UnitTests.Infrastructure
{
    public class WebApiRequestResult
    {
        public Type Controller { get; set; }
        public string ActionName { get; set; }
        public IHttpRouteData RouteData { get; set; }
    }
}
