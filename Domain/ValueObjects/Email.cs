using System.Text.RegularExpressions;
using OSLite.Exceptions;

namespace OSLite.Domain.ValueObjects
{
    public readonly record struct Email
    {
        public string Endereco { get; }

        public Email(string endereco)
        {
            if (string.IsNullOrWhiteSpace(endereco) ||
                !Regex.IsMatch(endereco, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new EmailInvalidoException(endereco);

            Endereco = endereco;
        }

        public override string ToString() => Endereco;
    }
}


