using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Bennington.Cms.Controllers;
using Bennington.Cms.InputModelAggregateRoot.Controllers;
using Bennington.Cms.InputModelAggregateRoot.Repositories;
using ExampleFeatureManagement.Models;
using Omu.ValueInjecter;
using SimpleCqrs.Commanding;

namespace ExampleFeatureManagement.Controllers
{
    public class ExampleFeatureManagementController : InputModelAggregateRootManagementControllerBase<ExampleFeatureListViewModel, ExampleFeatureInputModel>
    {
        public ExampleFeatureManagementController(ICommandBus commandBus, IRepository<ExampleFeatureInputModel> repository) : base(commandBus, repository)
        {
        }

        public override ActionResult Create(ExampleFeatureInputModel form)
        {
            return base.Create(form);
        }
    }
}
