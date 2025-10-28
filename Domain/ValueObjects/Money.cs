using OSLite.Exceptions;

namespace OSLite.Domain.ValueObjects
{
    public readonly record struct Money
    {
        public decimal Valor { get; }

        public Money(decimal valor)
        {
            if (valor < 0)
                throw new ValorInvalidoException(valor);

            Valor = valor;
        }

        public static Money operator +(Money a, Money b) => new(a.Valor + b.Valor);
        public override string ToString() => Valor.ToString("C2");
    }
}

