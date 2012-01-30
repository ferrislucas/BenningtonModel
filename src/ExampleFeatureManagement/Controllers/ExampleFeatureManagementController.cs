using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Bennington.Cms.Controllers;
using ExampleFeatureManagement.Denormalizers;
using ExampleFeatureManagement.Models;
using ExampleFeatureManagement.Repositories;
using InputModelAggregateRoot;
using InputModelAggregateRoot.Commands;
using InputModelAggregateRoot.Events;
using MvcTurbine.ComponentModel;
using Omu.ValueInjecter;
using SimpleCqrs.Commanding;
using SimpleCqrs.Eventing;

namespace ExampleFeatureManagement.Controllers
{
    public class ExampleFeatureManagementController : InputModelAggregateRootManagementControllerBase<ExampleFeatureListViewModel, ExampleFeatureInputModel>
    {
        public ExampleFeatureManagementController(ICommandBus commandBus, IRepository<ExampleFeatureInputModel> repository) : base(commandBus, repository)
        {
        }
    }

    public class ExampleFeaturesRepository : MongoRepository<ExampleFeatureInputModel>
    {
    }

    public class ExampleFeaturesDenormalizer : InputModelDenormalizerBase<ExampleFeatureInputModel>,
                                               IHandleDomainEvents<InputModelSubmittedEvent>,
                                               IHandleDomainEvents<DeleteInputModelEvent>
    {
        public ExampleFeaturesDenormalizer(IRepository<ExampleFeatureInputModel> repository) : base(repository)
        {
        }
    }

    public class Registrations : IServiceRegistration
    {
        public void Register(IServiceLocator locator)
        {
            locator.Register<IRepository<ExampleFeatureInputModel>, ExampleFeaturesRepository>();
        }
    }
}
