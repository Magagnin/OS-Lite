namespace OSLite.Exceptions
{
    public class EmailInvalidoException : DomainException
    {
        public EmailInvalidoException(string email)
            : base($"Email inválido: {email}") { }
    }
}

