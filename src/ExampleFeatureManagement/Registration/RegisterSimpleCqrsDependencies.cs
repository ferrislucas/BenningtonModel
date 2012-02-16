using ExampleFeature.Cms.Denormalizers;
using ExampleFeature.Cms.Repositories;
using MvcTurbine;
using MvcTurbine.Blades;
using SimpleCqrs;

namespace ExampleFeature.Cms.Registration
{
    public class RegisterSimpleCqrsDependencies : Blade
    {
        private readonly IServiceLocator simpleCqrsServiceLocator;

        public RegisterSimpleCqrsDependencies(SimpleCqrs.IServiceLocator simpleCqrsServiceLocator)
        {
            this.simpleCqrsServiceLocator = simpleCqrsServiceLocator;
        }

        public override void Spin(IRotorContext context)
        {
            simpleCqrsServiceLocator.Register(context.ServiceLocator.Resolve<ExampleFeaturesRepository>());
            simpleCqrsServiceLocator.Register(context.ServiceLocator.Resolve<ExampleFeaturesDenormalizer>());
        }
    }
}
