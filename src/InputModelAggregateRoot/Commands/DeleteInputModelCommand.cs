using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleCqrs.Commanding;

namespace InputModelAggregateRoot.Commands
{
    public class DeleteInputModelCommand : CommandWithAggregateRootId
    {
        public string SecurityInformation { get; set; }

        public Type InputModelType { get; set; }
    }

    public class DeleteInputModelCommandHandler : AggregateRootCommandHandler<DeleteInputModelCommand, InputModelAggregateRoot>
    {
        public override void Handle(DeleteInputModelCommand command, InputModelAggregateRoot aggregateRoot)
        {
            aggregateRoot.Delete(command.AggregateRootId, command.SecurityInformation, command.InputModelType);
        }
    }
}
