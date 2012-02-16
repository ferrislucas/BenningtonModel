using Bennington.Cms.InputModelAggregateRoot.Repositories;
using ExampleFeature.Cms.Models;
using ExampleFeature.Cms.Repositories;
using MvcTurbine.ComponentModel;

namespace ExampleFeature.Cms.Registration
{
    public class Registrations : IServiceRegistration
    {
        public void Register(IServiceLocator locator)
        {
            locator.Register<IRepository<ExampleFeatureInputModel>, ExampleFeaturesRepository>();
        }
    }
}