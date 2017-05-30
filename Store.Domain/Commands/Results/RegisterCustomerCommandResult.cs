using System;
using Store.Shared.Commands;

namespace Store.Domain.Commands.Inputs
{
    public class RegisterCustomerCommandResult : ICommandResult
    {
        public string Name { get; set; }
        public string Email { get; set; }        
    }
}