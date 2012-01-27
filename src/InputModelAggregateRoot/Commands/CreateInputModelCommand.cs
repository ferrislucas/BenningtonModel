using SimpleCqrs.Commanding;
using SimpleCqrs.Domain;

namespace InputModelAggregateRoot.Commands
{
    public class CreateInputModelCommand : CommandWithAggregateRootId
    {
        public object InputModel { get; set; }

        public string SecurityInformation { get; set; }
    }

    public class CreateInputModelCommandHandler : CommandHandler<CreateInputModelCommand>
    {
        private readonly IDomainRepository domainRepository;

        public CreateInputModelCommandHandler(IDomainRepository domainRepository)
        {
            this.domainRepository = domainRepository;
        }

        public override void Handle(CreateInputModelCommand command)
        {
            var inputModelAggregateRoot = new InputModelAggregateRoot(command.AggregateRootId);
            inputModelAggregateRoot.SubmitInputModel(command.InputModel, command.SecurityInformation);
            domainRepository.Save(inputModelAggregateRoot);
        }
    }
}
