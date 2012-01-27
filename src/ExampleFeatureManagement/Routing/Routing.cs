using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ExampleFeatureManagement.Controllers;
using MvcTurbine.Routing;

namespace SampleCmsWebsite.Routing
{
    public class SomeControllerRouting : IRouteRegistrator
    {
        public void Register(RouteCollection routes)
        {
            routes.MapRoute(typeof(ExampleFeatureManagementController).Name, typeof(ExampleFeatureManagementController).Name.Replace("Controller", string.Empty) + "/{action}", new { controller = typeof(ExampleFeatureManagementController).Name.Replace("Controller", string.Empty), action = "Index" });
        }
    }
}