using ExampleFeatureManagement.Models;
using InputModelAggregateRoot.Denormalizers;
using InputModelAggregateRoot.Events;
using InputModelAggregateRoot.Repositories;
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