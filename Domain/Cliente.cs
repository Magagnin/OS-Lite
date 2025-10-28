using System;
using System.Collections.Generic;
using OSLite.Domain.ValueObjects;

namespace OSLite.Domain
{
    public class Cliente
    {
        public Guid Id { get; }
        public string Nome { get; private set; }
        public Email Email { get; private set; }

        private readonly List<OrdemDeServico> _ordens = new();
        public IReadOnlyCollection<OrdemDeServico> Ordens => _ordens.AsReadOnly();

        public Cliente(string nome, Email email)
        {
            Id = Guid.NewGuid();
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Email = email;
        }

        public void AdicionarOrdem(OrdemDeServico ordem)
        {
            if (ordem == null)
                throw new ArgumentNullException(nameof(ordem));

            _ordens.Add(ordem);
            ordem.AtribuirCliente(this);
        }
    }
}

