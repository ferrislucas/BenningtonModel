using Bennington.Cms.InputModelAggregateRoot.Denormalizers;
using Bennington.Cms.InputModelAggregateRoot.Events;
using Bennington.Cms.InputModelAggregateRoot.Repositories;
using ExampleFeature.Cms.Models;
using SimpleCqrs.Eventing;

namespace ExampleFeature.Cms.Denormalizers
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