using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PontoSysStore.Catalogo.Application.Services;
using PontoSysStore.Catalogo.Data;
using PontoSysStore.Catalogo.Data.Repository;
using PontoSysStore.Catalogo.Domain;
using PontoSysStore.Catalogo.Domain.Events;
using PontoSysStore.Core.Comunications.Mediator;
using PontoSysStore.Core.Messages.CommonMessages.IntegrationEvents;
using PontoSysStore.Core.Messages.CommonMessages.Notifications;
using PontoSysStore.Pagamentos.AntiCorruption;
using PontoSysStore.Pagamentos.Business;
using PontoSysStore.Pagamentos.Business.Events;
using PontoSysStore.Pagamentos.Data;
using PontoSysStore.Pagamentos.Data.Repository;
using PontoSysStore.Vendas.Application.Commands;
using PontoSysStore.Vendas.Application.Events;
using PontoSysStore.Vendas.Application.Queries;
using PontoSysStore.Vendas.Data;
using PontoSysStore.Vendas.Data.Repository;
using PontoSysStore.Vendas.Domain;

namespace PontoSysStore.WebApp.Mvc.Setup
{
    public static class DependencyInjection
    {
        public static void ResgiterServices(this IServiceCollection services)
        {
            // Mediator
            services.AddScoped<IMediatrHandler, MediatrHandler>();

            // Notifications
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Catalogo
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IEstoqueService, EstoqueService>();
            services.AddScoped<CatalogoContext>();

            services.AddScoped<INotificationHandler<ProdutoAbaixoEstoqueEvent>, ProdutoEventHandler>();
            services.AddScoped<INotificationHandler<PedidoIniciadoEvent>, ProdutoEventHandler>();
            services.AddScoped<INotificationHandler<PedidoProcessamentoCanceladoEvent>, ProdutoEventHandler>();

            //Vendas
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IPedidoQueries, PedidoQueries>();
            services.AddScoped<VendasContext>();

            services.AddScoped<IRequestHandler<AdicionarItemPedidoCommand, bool>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarItemPedidoCommand, bool>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverItemPedidoCommand, bool>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<AplicarVoucherPedidoCommand, bool>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<IniciarPedidoCommand, bool>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<FinalizarPedidoCommand, bool>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<CancelProcessamentoPedidoCommand, bool>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<CancelarProcessamentoPedidoEstornarEstoqueCommand, bool>, PedidoCommandHandler>();

            services.AddScoped<INotificationHandler<PedidoRascunhoIniciadoEvent>, PedidoEventHandler>();
            services.AddScoped<INotificationHandler<PedidoAtualizadoEvent>, PedidoEventHandler>();
            services.AddScoped<INotificationHandler<PedidoItemAdicionadoEvent>, PedidoEventHandler>();
            services.AddScoped<INotificationHandler<PagamentoRealizadoEvent>, PedidoEventHandler>();
            services.AddScoped<INotificationHandler<PagamentoRecusadoEvent>, PedidoEventHandler>();

            //Pagamento 
            services.AddScoped<IPagamentoRepository, PagamentoRepository>();
            services.AddScoped<IPagamentoService, PagamentoService>();
            services.AddScoped<IPagamentoCartaoCreditoFacade, PagamentoCartaoCreditoFacade>();
            services.AddScoped<IPayPalGateway, PayPalGateway>();
            services.AddScoped<IConfigurationManager, ConfigurationManager>();
            services.AddScoped<PagamentoContext>();

            services.AddScoped<INotificationHandler<PedidoEstoqueConfirmadoEvent>,PagamentoEventHandler>();



        }
    }
}
