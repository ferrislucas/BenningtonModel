using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleCqrs.Commanding;

namespace InputModelAggregateRoot
{
    public class UpdateInputModelCommandHandler : AggregateRootCommandHandler<UpdateInputModelCommand, InputModelAggregateRoot>
    {
        public override void Handle(UpdateInputModelCommand command, InputModelAggregateRoot aggregateRoot)
        {
            aggregateRoot.InputModelId = command.AggregateRootId;
            aggregateRoot.SubmitInputModel(command.InputModel, command.SecurityInformation);
        }
    }

    public class UpdateInputModelCommand : CommandWithAggregateRootId
    {
        public object InputModel { get; set; }

        public string SecurityInformation { get; set; }
    }
}
