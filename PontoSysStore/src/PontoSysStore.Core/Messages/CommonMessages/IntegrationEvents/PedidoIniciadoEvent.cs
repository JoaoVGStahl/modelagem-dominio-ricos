using PontoSysStore.Core.DomainObjects.DTOs;
using PontoSysStore.Core.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PontoSysStore.Core.Messages.CommonMessages.IntegrationEvents
{
    public class PedidoIniciadoEvent : IntegrationEvent
    {
        public Guid PedidoId { get; set; }
        public Guid ClienteId { get; set; }
        public decimal Total { get; set; }
        public ListaProdutoPedido ProdutosPedido { get; set; }
        public string NomeCartao { get; set; }
        public string NumeroCartao { get; set; }
        public string ExpiracaoCartao { get; set; }
        public string CvvCartao { get; set; }

        public PedidoIniciadoEvent(Guid pedidoId, Guid clienteId, decimal total, ListaProdutoPedido produtosPedido, string nomeCartao, string numeroCartao, string expiracaoCartao, string cvvCartao)
        {
            AggregateId = pedidoId;
            PedidoId = pedidoId;
            ClienteId = clienteId;
            Total = total;
            ProdutosPedido = produtosPedido;
            NomeCartao = nomeCartao;
            NumeroCartao = numeroCartao;
            ExpiracaoCartao = expiracaoCartao;
            CvvCartao = cvvCartao;
        }
    }
}
