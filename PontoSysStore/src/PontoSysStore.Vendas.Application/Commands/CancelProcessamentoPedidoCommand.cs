using PontoSysStore.Core.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PontoSysStore.Vendas.Application.Commands
{
    public class CancelProcessamentoPedidoCommand : Command
    {
        public Guid PedidoId { get; private set; }
        public Guid ClienteId { get; private set; }
        public CancelProcessamentoPedidoCommand(Guid pedidoId, Guid clienteId)
        {
            AggregateId = pedidoId;
            PedidoId = pedidoId;
            ClienteId = clienteId;
        }
    }
}
