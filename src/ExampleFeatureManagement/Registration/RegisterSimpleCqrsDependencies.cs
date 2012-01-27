using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExampleFeatureManagement.Repositories;
using MvcTurbine;
using MvcTurbine.Blades;
using SimpleCqrs;

namespace ExampleFeatureManagement.Registration
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
            simpleCqrsServiceLocator.Register(context.ServiceLocator.Resolve<IExampleFeatureRepository>());
        }
    }
}
