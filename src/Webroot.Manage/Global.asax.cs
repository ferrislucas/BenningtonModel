using Bennington.Core.Configuration;
using MvcTurbine.ComponentModel;
using MvcTurbine.Unity;
using MvcTurbine.Web;

namespace SampleCmsWebsite
{
    public class MvcApplication : TurbineApplication
    {
        static MvcApplication()
        {
            ServiceLocatorManager.SetLocatorProvider(() => new UnityServiceLocator());
            Configurer.Configure
            .Content()
                .UseSql("Bennington.ContentTree.Domain.ConnectionString")
                .Run();

        }
    }
}