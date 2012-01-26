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
            routes.MapRoute("SomeControllerRouting", "SomeController/{action}", new { controller = "Some", action = "Index" });
        }
    }
}