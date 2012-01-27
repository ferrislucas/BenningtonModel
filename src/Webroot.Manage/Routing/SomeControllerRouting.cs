using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MvcTurbine.Routing;

namespace SampleCmsWebsite.Routing
{
    public class SomeControllerRouting : IRouteRegistrator
    {
        public void Register(RouteCollection routes)
        {
            routes.MapRoute("SomeControllerRouting", "ExampleFeatureManagement/{action}", new { controller = "ExampleFeatureManagement", action = "Index" });
        }
    }
}