using MediatR;
using Microsoft.AspNetCore.Mvc;
using PontoSysStore.Core.Comunications.Mediator;
using PontoSysStore.Core.Messages.CommonMessages.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PontoSysStore.WebApp.Mvc.Controllers
{
    public abstract class ControllerBase : Controller
    {
        private readonly DomainNotificationHandler _notifications;
        private readonly IMediatrHandler _mediatorHandler;

        protected Guid ClienteId = Guid.Parse("4885e451-b0e4-4490-b959-04fabc806d32"); // Mock Id

        protected ControllerBase(INotificationHandler<DomainNotification> notifications, IMediatrHandler mediatorHandler)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _mediatorHandler = mediatorHandler;
        }
        protected bool OperacaoValida()
        {
            return !_notifications.TemNotificacao();
        }
        protected void NotificarErro(string codigo, string mensagem)
        {
            _mediatorHandler.PublicarNotificacao(new DomainNotification(codigo, mensagem));
        }
        protected IEnumerable<string> ObterMensagensErro()
        {
            return _notifications.ObterNotificacoes().Select(c => c.Value).ToList();
        }
    }
}
