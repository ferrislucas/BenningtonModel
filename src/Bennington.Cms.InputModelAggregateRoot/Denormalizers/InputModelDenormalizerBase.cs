using InputModelAggregateRoot.Events;
using InputModelAggregateRoot.Repositories;

namespace InputModelAggregateRoot.Denormalizers
{
    public class InputModelDenormalizerBase<T>
    {
        private readonly IRepository<T> repository;

        public InputModelDenormalizerBase(IRepository<T> repository)
        {
            this.repository = repository;
        }

        public virtual void Handle(InputModelSubmittedEvent domainEvent)
        {
            if (domainEvent.InputModelType != typeof(T)) return;

            HandleInputModelSubmitted(domainEvent);
        }

        public virtual void Handle(DeleteInputModelEvent domainEvent)
        {
            if (domainEvent.InputModelType != typeof(T)) return;

            repository.Delete(domainEvent.AggregateRootId.ToString());
        }

        public virtual void HandleInputModelSubmitted(InputModelSubmittedEvent domainEvent)
        {
            var item = repository.GetById(domainEvent.AggregateRootId.ToString());
            if (item != null)
            {
                repository.Update((T)domainEvent.InputModel);
            }
            else
            {
                repository.Create((T)domainEvent.InputModel);
            }
        }
    }
}
