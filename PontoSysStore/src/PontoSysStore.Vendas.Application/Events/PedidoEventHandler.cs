using MediatR;
using PontoSysStore.Core.Comunications.Mediator;
using PontoSysStore.Core.Messages.CommonMessages.IntegrationEvents;
using PontoSysStore.Vendas.Application.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PontoSysStore.Vendas.Application.Events
{
    public class PedidoEventHandler : 
        INotificationHandler<PedidoRascunhoIniciadoEvent>, 
        INotificationHandler<PedidoAtualizadoEvent>, 
        INotificationHandler<PedidoItemAdicionadoEvent>,
        INotificationHandler<PedidoEstoqueRejeitadoEvent>,
        INotificationHandler<PagamentoRealizadoEvent>,
        INotificationHandler<PagamentoRecusadoEvent>
    {
        private readonly IMediatrHandler _mediatrHandler;

        public PedidoEventHandler(IMediatrHandler mediatrHandler)
        {
            _mediatrHandler = mediatrHandler;
        }

        public Task Handle(PedidoAtualizadoEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine(notification);
            return Task.CompletedTask;
        }

        public Task Handle(PedidoItemAdicionadoEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine(notification);
            return Task.CompletedTask;
        }

        public Task Handle(PedidoRascunhoIniciadoEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine(notification);
            return Task.CompletedTask;
        }

        public async Task Handle(PedidoEstoqueRejeitadoEvent message, CancellationToken cancellationToken)
        {
            await _mediatrHandler.EnviarComando(new CancelProcessamentoPedidoCommand(message.PedidoId, message.ClienteId));
        }

        public async Task Handle(PagamentoRealizadoEvent message, CancellationToken cancellationToken)
        {
            await _mediatrHandler.EnviarComando(new FinalizarPedidoCommand(message.PedidoId, message.ClienteId));
        }

        public async Task Handle(PagamentoRecusadoEvent message, CancellationToken cancellationToken)
        {
            // avisar Cliente
            await _mediatrHandler.EnviarComando(new CancelarProcessamentoPedidoEstornarEstoqueCommand(message.PedidoId, message.ClienteId));
        }
    }
}
