using System.Web.Mvc;
using System.Web.Routing;
using ExampleFeatureManagement.Controllers;
using MvcTurbine.Routing;

namespace ExampleFeatureManagement.Routing
{
    public class SomeControllerRouting : IRouteRegistrator
    {
        public void Register(RouteCollection routes)
        {
            routes.MapRoute(typeof(ExampleFeatureManagementController).Name, typeof(ExampleFeatureManagementController).Name.Replace("Controller", string.Empty) + "/{action}", new { controller = typeof(ExampleFeatureManagementController).Name.Replace("Controller", string.Empty), action = "Index" });
        }
    }
}