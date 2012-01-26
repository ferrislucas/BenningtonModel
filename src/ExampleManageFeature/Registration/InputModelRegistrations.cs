using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExampleManageFeature.Models;
using InputModelAggregateRoot;
using MvcTurbine;
using MvcTurbine.Blades;
using MvcTurbine.ComponentModel;
using IServiceLocator = SimpleCqrs.IServiceLocator;

namespace ExampleManageFeature.Registration
{
    public class InputModelRegistrations : Blade
    {
        private readonly IServiceLocator simpleSqcrsServiceLocator;

        public InputModelRegistrations(SimpleCqrs.IServiceLocator simpleSqcrsServiceLocator)
        {
            this.simpleSqcrsServiceLocator = simpleSqcrsServiceLocator;
        }

        public override void Spin(IRotorContext context)
        {
            simpleSqcrsServiceLocator.Register(context.ServiceLocator.Resolve<CreateInputModelCommand<SomeForm>>());
            simpleSqcrsServiceLocator.Register(context.ServiceLocator.Resolve<UpdateInputModelCommand<SomeForm>>());
        }
    }
}
