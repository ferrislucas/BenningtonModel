using System;
using SimpleCqrs.Eventing;

namespace InputModelAggregateRoot.Events
{
    public class DeleteInputModelEvent : DomainEvent
    {
        public string LastModifyBy { get; set; }
        public Type InputModelType { get; set; }
    }
}