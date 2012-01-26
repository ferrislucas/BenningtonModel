using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleCqrs.Commanding;

namespace InputModelAggregateRoot
{
    public class UpdateInputModelCommandHandler<T> : AggregateRootCommandHandler<UpdateInputModelCommand<T>, InputModelAggregateRoot<T>>
    {
        public override void Handle(UpdateInputModelCommand<T> command, InputModelAggregateRoot<T> aggregateRoot)
        {
            aggregateRoot.InputModelId = command.AggregateRootId;
            aggregateRoot.SubmitInputModel(command.InputModel, command.SecurityInformation);
        }
    }

    public class UpdateInputModelCommand<T> : CommandWithAggregateRootId
    {
        public T InputModel { get; set; }

        public string SecurityInformation { get; set; }
    }
}
