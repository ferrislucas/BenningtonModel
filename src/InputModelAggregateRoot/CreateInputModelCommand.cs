using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleCqrs.Commanding;
using SimpleCqrs.Domain;

namespace InputModelAggregateRoot
{
    public class CreateInputModelCommand<T> : CommandWithAggregateRootId
    {
        public T InputModel { get; set; }

        public string SecurityInformation { get; set; }
    }

    public class CreateInputModelCommandHandler<T> : CommandHandler<CreateInputModelCommand<T>>
    {
        private readonly IDomainRepository domainRepository;

        public CreateInputModelCommandHandler(IDomainRepository domainRepository)
        {
            this.domainRepository = domainRepository;
        }

        public override void Handle(CreateInputModelCommand<T> command)
        {
            var inputModelAggregateRoot = new InputModelAggregateRoot<T>(command.AggregateRootId);
            inputModelAggregateRoot.SubmitInputModel(command.InputModel, command.SecurityInformation);
            domainRepository.Save(inputModelAggregateRoot);
        }
    }
}
