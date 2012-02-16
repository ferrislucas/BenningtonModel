using System;
using SimpleCqrs.Commanding;

namespace Bennington.Cms.InputModelAggregateRoot.Commands
{
    public class DeleteInputModelCommand : CommandWithAggregateRootId
    {
        public string SecurityInformation { get; set; }

        public Type InputModelType { get; set; }
    }

    public class DeleteInputModelCommandHandler : AggregateRootCommandHandler<DeleteInputModelCommand, AggregateRoots.InputModelAggregateRoot>
    {
        public override void Handle(DeleteInputModelCommand command, AggregateRoots.InputModelAggregateRoot aggregateRoot)
        {
            aggregateRoot.Delete(command.AggregateRootId, command.SecurityInformation, command.InputModelType);
        }
    }
}
