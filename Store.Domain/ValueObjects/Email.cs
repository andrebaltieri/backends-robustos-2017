using System;
using FluentValidator;

namespace Store.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        public Email(string address)
        {
            Address = address;

            new ValidationContract<Email>(this)
                .IsRequired(x => x.Address, "O E-mail é obrigatório")
                .IsEmail(x => x.Address, "E-mail inválido");
        }

        public string Address { get; private set; }

        public override string ToString()
        {
            return Address;
        }
    }
}