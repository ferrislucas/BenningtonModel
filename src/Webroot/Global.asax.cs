using System;
using System.Web.Mvc;
using Bennington.Core.Caching;
using Bennington.Core.Configuration;
using MvcTurbine.ComponentModel;
using MvcTurbine.Unity;
using MvcTurbine.Web;

namespace SampleContentWebsite
{
    public class MvcApplication : TurbineApplication
    {
        static MvcApplication()
        {
            ServiceLocatorManager.SetLocatorProvider(() => new UnityServiceLocator());
        }

        public override void Startup()
        {
            Configurer.Configure
                        .Content()
                            .UseSql("Bennington.ContentTree.Domain.ConnectionString")
                            .Run();
            
            base.Startup();
        }
    }
}