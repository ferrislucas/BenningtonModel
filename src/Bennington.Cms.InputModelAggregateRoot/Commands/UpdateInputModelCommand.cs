using SimpleCqrs.Commanding;

namespace Bennington.Cms.InputModelAggregateRoot.Commands
{
    public class UpdateInputModelCommandHandler : AggregateRootCommandHandler<UpdateInputModelCommand, AggregateRoots.InputModelAggregateRoot>
    {
        public override void Handle(UpdateInputModelCommand command, AggregateRoots.InputModelAggregateRoot aggregateRoot)
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
