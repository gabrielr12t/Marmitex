using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Marmitex.Domain.BaseEntity;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Marmitex.Domain.Interfaces
{
    public interface IRepositoryBase<TEntity>
    {
        Task Add(TEntity obj);
        Task<TEntity> GetById(long id);
        Task<IEnumerable<TEntity>> GetByIds(int[] id);
        TEntity Procurar(params object[] key);
        Task<IEnumerable<TEntity>> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Deletar(Func<TEntity, bool> predicate);
        Task Save();
        Task RemoveProdutoAntigo<T>() where T : Cardapio;
        Task Desativar<T>(TEntity obj) where T : Cardapio;
        Task<IEnumerable<T>> Ativos<T>() where T : Cardapio;
        Task<TEntity> GetOneWithPredicate(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);

    }
}