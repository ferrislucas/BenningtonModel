using System;
using InputModelAggregateRoot.Events;
using SimpleCqrs.Domain;

namespace InputModelAggregateRoot.AggregateRoots
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

        public void Delete(Guid aggregateRootId, string lastModifyBy, Type inputModelType)
        {
            Apply(new DeleteInputModelEvent()
                      {
                          AggregateRootId = aggregateRootId,
                          LastModifyBy = lastModifyBy,
                          InputModelType = inputModelType
                      });
        }
    }
}
