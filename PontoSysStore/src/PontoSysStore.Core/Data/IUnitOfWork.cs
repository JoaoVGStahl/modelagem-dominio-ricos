using System.Threading.Tasks;

namespace PontoSysStore.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}