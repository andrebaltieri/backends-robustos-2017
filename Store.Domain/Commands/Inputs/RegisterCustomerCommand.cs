using System;
using Store.Shared.Commands;

namespace Store.Domain.Commands.Inputs
{
    public class RegisterCustomerCommand : ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public string Phone { get; set; }
        public string Document { get; set; }
    }
}