using PontoSysStore.Core.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PontoSysStore.Vendas.Application.Events
{
    public class PedidoFinalizadoEvent : Event
    {
        public Guid PedidoId { get; private set; }
        public PedidoFinalizadoEvent(Guid pedidoId)
        {
            PedidoId = pedidoId;
            AggregateId = pedidoId;
        }
    }
}
