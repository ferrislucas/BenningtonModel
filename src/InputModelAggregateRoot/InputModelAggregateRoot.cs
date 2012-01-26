using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleCqrs.Domain;
using SimpleCqrs.Eventing;

namespace InputModelAggregateRoot
{
    public class InputModelAggregateRoot : AggregateRoot
    {
        public InputModelAggregateRoot(Guid aggregateRootId)
		{
			Id = aggregateRootId;
			Apply(new InputModelAggregateRootCreatedEvent(){ AggregateRootId = aggregateRootId });
		}

        public InputModelAggregateRoot()
		{
		}

        public Guid InputModelId 
        {
            get
            {
                return this.Id;
            }
            set
            {
                Id = value;
            }
        }

        protected void OnInputModelAggregateRootCreated(InputModelAggregateRootCreatedEvent inputModelAggregateRootCreatedEvent)
        {
            Id = inputModelAggregateRootCreatedEvent.AggregateRootId;
        }

        public void SubmitInputModel(object inputModel, string securityInformation)
        {
            Apply(new InputModelSubmittedEvent()
                      {
                          InputModelType = inputModel.GetType(),
                          SecurityInformation = securityInformation,
                          InputModel = inputModel,
                      });
        }

    }

    public class InputModelSubmittedEvent : DomainEvent
    {
        public object InputModel { get; set; }

        public Type InputModelType { get; set; }

        public string SecurityInformation { get; set; }
    }

    public class InputModelAggregateRootCreatedEvent : DomainEvent
    {
    }
}
