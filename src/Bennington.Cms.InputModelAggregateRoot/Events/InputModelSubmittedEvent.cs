using System;
using SimpleCqrs.Eventing;

namespace Bennington.Cms.InputModelAggregateRoot.Events
{
    public class InputModelSubmittedEvent : DomainEvent
    {
        public object InputModel { get; set; }

        public Type InputModelType { get; set; }

        public string SecurityInformation { get; set; }
    }
}