using System.Configuration;
using Bennington.Cms.InputModelAggregateRoot;
using Bennington.Core.Configuration;
using Microsoft.Practices.Unity;
using MvcTurbine.ComponentModel;
using MvcTurbine.Web;
using SimpleCqrs.Commanding;
using SimpleCqrs.Eventing;
using SimpleCqrs.EventStore.SqlServer;
using SimpleCqrs.EventStore.SqlServer.Serializers;
using UnityServiceLocator = MvcTurbine.Unity.UnityServiceLocator;

namespace SampleCmsWebsite
{
    public class MvcApplication : TurbineApplication
    {
        static MvcApplication()
        {
            DatabaseFactory.SetConnectionName("Mongo");

            var container = new UnityContainer();
            ServiceLocatorManager.SetLocatorProvider(() => new UnityServiceLocator(container));

            var simpleCqrsRuntime = new SimpleCqrsRuntime(container);
            simpleCqrsRuntime.Start();

            simpleCqrsRuntime.ServiceLocator.Register<IEventStore>(
                new SqlServerEventStore(
                    new SqlServerConfiguration(ConfigurationManager.ConnectionStrings["Bennington.ContentTree.Domain.ConnectionString"].ToString()),
                    new JsonDomainEventSerializer()));

            container.RegisterInstance(simpleCqrsRuntime.ServiceLocator.Resolve<ICommandBus>());
            container.RegisterInstance<SimpleCqrs.IServiceLocator>(simpleCqrsRuntime.ServiceLocator);

            Configurer.Configure
            .Content()
                .UseSql("Bennington.ContentTree.Domain.ConnectionString")
                .Run();

        }
    }
}