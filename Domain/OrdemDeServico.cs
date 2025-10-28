using System;
using System.Collections.Generic;
using System.Linq;
using OSLite.Domain.Enums;
using OSLite.Domain.ValueObjects;
using OSLite.Exceptions;

namespace OSLite.Domain
{
    public class OrdemDeServico
    {
        public Guid Id { get; }
        public Cliente Cliente { get; private set; }
        public StatusOS Status { get; private set; }

        private readonly List<ItemDeServico> _itens = new();
        public IReadOnlyCollection<ItemDeServico> Itens => _itens.AsReadOnly();

        public Money Total => new(_itens.Sum(i => i.Preco.Valor));

        public OrdemDeServico()
        {
            Id = Guid.NewGuid();
            Status = StatusOS.Aberta;
        }

        internal void AtribuirCliente(Cliente cliente)
        {
            Cliente = cliente ?? throw new ArgumentNullException(nameof(cliente));
        }

        public void AdicionarItem(ItemDeServico item)
        {
            if (Status != StatusOS.Aberta)
                throw new StatusInvalidoException("Não é possível adicionar itens após iniciar ou concluir a OS.");

            _itens.Add(item ?? throw new ArgumentNullException(nameof(item)));
        }

        public void Iniciar()
        {
            if (Status != StatusOS.Aberta)
                throw new StatusInvalidoException("A OS só pode ser iniciada se estiver aberta.");
            Status = StatusOS.EmAndamento;
        }

        public void Concluir()
        {
            if (Status != StatusOS.EmAndamento)
                throw new StatusInvalidoException("A OS só pode ser concluída se estiver em andamento.");
            Status = StatusOS.Concluida;
        }

        public void Cancelar()
        {
            if (Status == StatusOS.Concluida)
                throw new StatusInvalidoException("Não é possível cancelar uma OS concluída.");
            Status = StatusOS.Cancelada;
        }
    }
}

