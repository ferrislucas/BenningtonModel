using Bennington.Core.Configuration;
using Microsoft.Practices.Unity;
using MvcTurbine.ComponentModel;
using MvcTurbine.Web;
using UnityServiceLocator = MvcTurbine.Unity.UnityServiceLocator;

namespace SampleCmsWebsite
{
    public class MvcApplication : TurbineApplication
    {
        static MvcApplication()
        {
            var container = new UnityContainer();
            ServiceLocatorManager.SetLocatorProvider(() => new UnityServiceLocator(container));

            var simpleCqrsRuntime = new SimpleCqrsRuntime(container);
            simpleCqrsRuntime.Start();

            container.RegisterInstance<SimpleCqrs.IServiceLocator>(simpleCqrsRuntime.ServiceLocator);

            Configurer.Configure
            .Content()
                .UseSql("Bennington.ContentTree.Domain.ConnectionString")
                .Run();

        }
    }
}