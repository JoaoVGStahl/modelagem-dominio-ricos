using PontoSysStore.Core.DomainObjects.DTOs;
using System.Threading.Tasks;

namespace PontoSysStore.Pagamentos.Business
{
    public interface IPagamentoService
    {
        Task<Transacao> RealizarPagamentoPedido(PagamentoPedido pagamentoPedido);
    }
}