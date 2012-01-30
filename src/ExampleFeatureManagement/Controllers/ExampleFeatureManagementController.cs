using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Bennington.Cms.Controllers;
using ExampleFeatureManagement.Models;
using InputModelAggregateRoot;
using InputModelAggregateRoot.Commands;
using InputModelAggregateRoot.Controllers;
using InputModelAggregateRoot.Repositories;
using Omu.ValueInjecter;
using SimpleCqrs.Commanding;

namespace ExampleFeatureManagement.Controllers
{
    public class ExampleFeatureManagementController : InputModelAggregateRootManagementControllerBase<ExampleFeatureListViewModel, ExampleFeatureInputModel>
    {
        public ExampleFeatureManagementController(ICommandBus commandBus, IRepository<ExampleFeatureInputModel> repository) : base(commandBus, repository)
        {
        }
    }
}
