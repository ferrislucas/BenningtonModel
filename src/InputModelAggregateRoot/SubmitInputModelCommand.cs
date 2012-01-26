using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleCqrs.Commanding;
using SimpleCqrs.Domain;

namespace InputModelAggregateRoot
{
    public class SubmitInputModelCommand<T> : CommandWithAggregateRootId
    {
        public T InputModel { get; set; }

        public string SecurityInformation { get; set; }
    }

    public class SubmitInputModelCommandHandler<T> : CommandHandler<SubmitInputModelCommand<T>>
    {
        private readonly IDomainRepository domainRepository;

        public SubmitInputModelCommandHandler(IDomainRepository domainRepository)
        {
            this.domainRepository = domainRepository;
        }

        public override void Handle(SubmitInputModelCommand<T> command)
        {
            var inputModelAggregateRoot = new InputModelAggregateRoot<T>(Guid.NewGuid());
            inputModelAggregateRoot.SubmitInputModel(command.InputModel, command.SecurityInformation);
            domainRepository.Save(inputModelAggregateRoot);
        }
    }
}
