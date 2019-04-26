using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Marmitex.Data.Context;
using Marmitex.Domain.BaseEntity;
using Marmitex.Domain.DomainExceptions;
using Marmitex.Domain.Entidades;
using Marmitex.Domain.Enums;
using Marmitex.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Marmitex.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : Entity
    {
        protected readonly ApplicationDbContext _context;
        public RepositoryBase(ApplicationDbContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public virtual async Task Add(TEntity obj)
        {
            var item = await GetById(obj.Id);
            if (item == null)
            {
                _context.Set<TEntity>().Add(obj);
            }
            _context.Entry(obj).State = EntityState.Modified;
        }
        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
        public virtual async Task<TEntity> GetById(long id)
        {
            var obj = await _context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id);
            if (obj == null && id > 0) throw new Exception("Não encontrado");
            return obj;
        }
        public virtual void Remove(TEntity obj)
        {
            var query = _context.Set<TEntity>().Find(obj.Id);
            if (query != null) _context.Set<TEntity>().Remove(obj);
        }

        public virtual async Task Save()
        {
            await _context.SaveChangesAsync();
        }
        public virtual void Update(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
        }
        public virtual async Task RemoveProdutoAntigo<T>() where T : Cardapio
        {
            var lista = await _context.Set<T>().Where(x => x.Data.ToShortDateString() != DateTime.Now.ToShortDateString()).ToListAsync();
            _context.Set<T>().RemoveRange((IEnumerable<T>)lista);
        }
        public virtual async Task Desativar<T>(TEntity obj) where T : Cardapio
        {
            var item = await _context.Set<T>().FirstOrDefaultAsync(e => e.Id == obj.Id);
            item.StatusCardapio = StatusCardapio.INATIVO;
            _context.Set<T>().Update(item);
        }
        async Task<IEnumerable<T>> IRepositoryBase<TEntity>.Ativos<T>()
        {
            return await _context.Set<T>()
            .Where(x => x.StatusCardapio.Equals(StatusCardapio.ATIVO) && x.Data.ToShortDateString().Equals(DateTime.Now.ToShortDateString()))
            .ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetByIds(int[] ids)
        {
            List<TEntity> lista = new List<TEntity>();
            foreach (var item in ids) lista.Add(await GetById(item));
            return lista.AsQueryable();
        }

        public async Task<TEntity> GetOneWithPredicate(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAnyWithPredicate(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).ToListAsync();
        }
    }
}