using System.Threading.Tasks;
using Marmitex.Domain.BaseEntity;

namespace Marmitex.Domain.Interfaces
{
    public interface ICardapioRepository<T> : IRepositoryBase<T>
    {
        void AddCardapio(T t);
         // Task RemoveProdutoAntigo(T t);
    }
}