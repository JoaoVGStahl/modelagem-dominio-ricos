using PontoSysStore.Core.Messages.CommonMessages.DomainEvents;
using System;

namespace PontoSysStore.Catalogo.Domain.Events
{
    public class ProdutoAbaixoEstoqueEvent : DomainEvent
    {
        public int QuantidadeRestante { get;private set; }
        public ProdutoAbaixoEstoqueEvent(Guid aggreateId, int quantidadeRestante) : base(aggreateId)
        {
            QuantidadeRestante = quantidadeRestante;
        }
    }
}
