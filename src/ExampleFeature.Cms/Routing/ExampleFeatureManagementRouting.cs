using System.Web.Mvc;
using System.Web.Routing;
using ExampleFeature.Cms.Controllers;
using MvcTurbine.Routing;

namespace ExampleFeature.Cms.Routing
{
    public class ExampleFeatureManagementRouting : IRouteRegistrator
    {
        public void Register(RouteCollection routes)
        {
            RegisterARouteForTheManagementController(routes);
        }

        private static void RegisterARouteForTheManagementController(RouteCollection routes)
        {
            routes.MapRoute(typeof(ExampleFeatureManagementController).Name, typeof(ExampleFeatureManagementController).Name.Replace("Controller", string.Empty) + "/{action}", new { controller = typeof(ExampleFeatureManagementController).Name.Replace("Controller", string.Empty), action = "Index" });
        }
    }
}