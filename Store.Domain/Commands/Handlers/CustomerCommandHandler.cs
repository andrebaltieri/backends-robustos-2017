using FluentValidator;
using Store.Shared.Commands;
using Store.Domain.Commands.Inputs;
using System;
using Store.Domain.Repositories;
using Store.Domain.ValueObjects;
using Store.Domain.Entities;

namespace Store.Domain.Commands.Handlers
{
    public class CustomerCommandHandler : Notifiable,
        ICommandHandler<RegisterCustomerCommand>
    {
        private readonly ICustomerRepository _repository;

        public CustomerCommandHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(RegisterCustomerCommand command)
        {
            // Cria os VOs necessários
            var name = new Name(command.FirstName, command.LastName);
            var email = new Email(command.Email);
            var document = new Document(command.Document);

            // Cria a entidade
            var customer = new Customer(name, command.Birthdate, email, document, command.Phone);

            // Consolida as validações
            AddNotifications(name.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(customer.Notifications);

            // Se estiver tudo OK
            if (!IsValid())
                return null;

            // Persiste os dados
            _repository.Save(customer);

            // Retorna o resultado
            return new RegisterCustomerCommandResult
            {
                Name = customer.Name.ToString(),
                Email = customer.Email.ToString()
            };
        }
    }
}