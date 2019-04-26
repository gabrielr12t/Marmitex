using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Marmitex.Domain.BaseEntity;

namespace Marmitex.Domain.Interfaces
{
    public interface IRepositoryBase<TEntity>
    {
        Task Add(TEntity obj);
        Task<TEntity> GetById(long id);
        Task<IEnumerable<TEntity>> GetByIds(int[] id);
        Task<IEnumerable<TEntity>> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        Task Save();
        Task RemoveProdutoAntigo<T>() where T : Cardapio;
        Task Desativar<T>(TEntity obj) where T : Cardapio;
        Task<IEnumerable<T>> Ativos<T>() where T : Cardapio;
        Task<TEntity> GetOneWithPredicate(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAnyWithPredicate(Expression<Func<TEntity, bool>> predicate);

    }
}