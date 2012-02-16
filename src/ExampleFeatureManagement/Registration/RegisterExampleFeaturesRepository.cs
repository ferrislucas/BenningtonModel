using Bennington.Cms.InputModelAggregateRoot.Repositories;
using ExampleFeatureManagement.Controllers;
using ExampleFeatureManagement.Models;
using ExampleFeatureManagement.Repositories;
using MvcTurbine.ComponentModel;

namespace ExampleFeatureManagement.Registration
{
    public class Registrations : IServiceRegistration
    {
        public void Register(IServiceLocator locator)
        {
            locator.Register<IRepository<ExampleFeatureInputModel>, ExampleFeaturesRepository>();
        }
    }
}