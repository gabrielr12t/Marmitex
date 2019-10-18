using System.Threading.Tasks;

namespace Marmitex.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}