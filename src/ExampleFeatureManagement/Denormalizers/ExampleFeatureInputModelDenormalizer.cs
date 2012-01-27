using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExampleFeatureManagement.Models;
using ExampleFeatureManagement.Repositories;
using InputModelAggregateRoot;
using SimpleCqrs.Eventing;

namespace ExampleFeatureManagement.Denormalizers
{
    public class ExampleFeatureInputModelDenormalizer : IHandleDomainEvents<InputModelSubmittedEvent>
    {
        private readonly IExampleFeatureRepository exampleFeatureRepository;

        public ExampleFeatureInputModelDenormalizer(IExampleFeatureRepository exampleFeatureRepository)
        {
            this.exampleFeatureRepository = exampleFeatureRepository;
        }

        public void Handle(InputModelSubmittedEvent domainEvent)
        {
            if (domainEvent.InputModelType != typeof(ExampleFeatureInputModel)) return;

            var item = exampleFeatureRepository.GetById(domainEvent.AggregateRootId.ToString());
            if (item != null)
            {
                exampleFeatureRepository.Update((ExampleFeatureInputModel) domainEvent.InputModel);   
            }
            else
            {
                exampleFeatureRepository.Create((ExampleFeatureInputModel)domainEvent.InputModel);
            }
        }
    }
}
