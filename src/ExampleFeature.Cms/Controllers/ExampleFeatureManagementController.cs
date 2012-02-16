using System.Web.Mvc;
using Bennington.Cms.InputModelAggregateRoot.Controllers;
using Bennington.Cms.InputModelAggregateRoot.Repositories;
using ExampleFeature.Cms.Models;
using SimpleCqrs.Commanding;

namespace ExampleFeature.Cms.Controllers
{
    public class ExampleFeatureManagementController : InputModelAggregateRootManagementControllerBase<ExampleFeatureListViewModel, ExampleFeatureInputModel>
    {
        public ExampleFeatureManagementController(ICommandBus commandBus, IRepository<ExampleFeatureInputModel> repository) : base(commandBus, repository)
        {
        }
    }
}
