using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marmitex.Domain.BaseEntity;

namespace Marmitex.Domain.Interfaces
{
    public interface IRepositoryBase<TEntity>
    {
        void Add(TEntity obj);
        TEntity GetById(long id);
        IQueryable<TEntity> GetByIds(int[] id);
        IQueryable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        Task Save();
        Task RemoveProdutoAntigo<T>() where T : Cardapio;
        void Desativar<T>(TEntity obj) where T : Cardapio;
        IQueryable<T> Ativos<T>() where T : Cardapio; 

    }
}