using System;
using OSLite.Domain.ValueObjects;

namespace OSLite.Domain
{
    public class ItemDeServico
    {
        public Guid Id { get; }
        public string Descricao { get; private set; }
        public Money Preco { get; private set; }

        public ItemDeServico(string descricao, Money preco)
        {
            Id = Guid.NewGuid();
            Descricao = descricao ?? throw new ArgumentNullException(nameof(descricao));
            Preco = preco;
        }
    }
}

