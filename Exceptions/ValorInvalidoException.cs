namespace OSLite.Exceptions
{
    public class ValorInvalidoException : DomainException
    {
        public ValorInvalidoException(decimal valor)
            : base($"Valor inválido: {valor}") { }
    }
}

