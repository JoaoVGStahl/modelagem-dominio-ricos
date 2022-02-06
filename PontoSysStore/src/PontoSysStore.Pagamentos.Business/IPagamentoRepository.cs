using PontoSysStore.Core.Data;

namespace PontoSysStore.Pagamentos.Business
{
    public interface IPagamentoRepository : IRepository<Pagamento>
    {
        void Adicionar(Pagamento pagamento);

        void AdicionarTransacao(Transacao transacao);
    }
}