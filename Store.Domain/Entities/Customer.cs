using System;
using FluentValidator;
using Store.Domain.ValueObjects;
using Store.Shared.Entities;

namespace Store.Domain.Entities
{
    public class Customer : Entity
    {
        public Customer(Name name, DateTime birthdate, Email email, Document document, string phone)
        {
            Name = name;
            Birthdate = birthdate;
            Email = email;
            Document = document;
            Phone = phone;

            new ValidationContract<Customer>(this)
                .IsRequired(x => x.Phone, "O telefone é obrigatório")
                .HasMaxLenght(x => x.Phone, 11, "O telefone deve possuir até 11 caracteres")
                .HasMinLenght(x => x.Phone, 10, "O telefone deve possuir pelo menos 10 caracteres");
        }
        
        public Name Name { get; private set; }
        public DateTime Birthdate { get; private set; }
        public Email Email { get; private set; }
        public Document Document { get; private set; }
        public string Phone { get; private set; }
    }
}