using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleCqrs.Domain;
using SimpleCqrs.Eventing;

namespace InputModelAggregateRoot
{
    public class InputModelAggregateRoot<T> : AggregateRoot
    {
        public InputModelAggregateRoot(Guid aggregateRootId)
		{
			Id = aggregateRootId;
			Apply(new InputModelAggregateRootCreatedEvent(){ AggregateRootId = aggregateRootId });
		}

        public InputModelAggregateRoot()
		{
		}

        protected void OnInputModelAggregateRootCreated(InputModelAggregateRootCreatedEvent inputModelAggregateRootCreatedEvent)
        {
            Id = inputModelAggregateRootCreatedEvent.AggregateRootId;
        }

        public void SubmitInputModel(T inputModel, string securityInformation)
        {
            Apply(new InputModelSubmittedEvent<T>()
                      {
                          InputModelType = inputModel.GetType(),
                          SecurityInformation = securityInformation,
                          InputModel = inputModel,
                      });
        }

    }

    public class InputModelSubmittedEvent<T> : DomainEvent
    {
        public T InputModel { get; set; }

        public Type InputModelType { get; set; }

        public string SecurityInformation { get; set; }
    }

    public class InputModelAggregateRootCreatedEvent : DomainEvent
    {
    }
}
