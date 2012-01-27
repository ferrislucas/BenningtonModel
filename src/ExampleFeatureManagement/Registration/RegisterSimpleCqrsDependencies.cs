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
        private readonly IServiceLocator serviceLocator;

        public RegisterSimpleCqrsDependencies(SimpleCqrs.IServiceLocator serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }

        public override void Spin(IRotorContext context)
        {
            serviceLocator.Register(context.ServiceLocator.Resolve<IExampleFeatureRepository>());
        }
    }
}
