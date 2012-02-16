using Bennington.Cms.InputModelAggregateRoot.Denormalizers;
using Bennington.Cms.InputModelAggregateRoot.Events;
using Bennington.Cms.InputModelAggregateRoot.Repositories;
using ExampleFeatureManagement.Models;
using SimpleCqrs.Eventing;

namespace ExampleFeatureManagement.Denormalizers
{
    public class ExampleFeaturesDenormalizer : InputModelDenormalizerBase<ExampleFeatureInputModel>,
                                               IHandleDomainEvents<InputModelSubmittedEvent>,
                                               IHandleDomainEvents<DeleteInputModelEvent>
    {
        public ExampleFeaturesDenormalizer(IRepository<ExampleFeatureInputModel> repository) : base(repository)
        {
        }
    }
}