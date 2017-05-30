using System;
using FluentValidator;

namespace Store.Domain.ValueObjects
{
    public class Name : Notifiable
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            new ValidationContract<Name>(this)
                .IsRequired(x => x.FirstName, "O nome é obrigatório")
                .IsRequired(x => x.LastName, "O sobrenome é obrigatório")
                .HasMaxLenght(x => x.FirstName, 40, "O nome deve possuir até 40 caracteres")
                .HasMinLenght(x => x.FirstName, 3, "O nome deve possuir pelo menos 3 caracteres")
                .HasMaxLenght(x => x.LastName, 40, "O sobrenome deve possuir até 40 caracteres")
                .HasMinLenght(x => x.LastName, 3, "O sobrenome deve possuir pelo menos 3 caracteres");
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}