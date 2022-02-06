using PontoSysStore.Core.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PontoSysStore.Vendas.Application.Commands
{
    public class CancelarProcessamentoPedidoEstornarEstoqueCommand : Command
    {
        public Guid PedidoId { get; private set; }
        public Guid MyProperty { get; private set; }
        public CancelarProcessamentoPedidoEstornarEstoqueCommand(Guid pedidoId, Guid myProperty)
        {
            PedidoId = pedidoId;
            MyProperty = myProperty;
        }
    }
}
