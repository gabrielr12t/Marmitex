using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marmitex.Data.Context;
using Marmitex.Domain.BaseEntity;
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
        }
        public virtual void Add(TEntity obj)
        {
            if (obj.Id == 0)
            {
                //create
                _context.Set<TEntity>().Add(obj);
                return;
            }
            //update
            _context.Entry(obj).State = EntityState.Modified;
        }
        public virtual IQueryable<TEntity> GetAll()
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            return query.AsQueryable().AsNoTracking();
        }
        public virtual TEntity GetById(long id)
        {
            return id > 0 ? _context.Set<TEntity>().FirstOrDefault(e => e.Id == id) : null;
        }
        public virtual void Remove(TEntity obj)
        {
            // var query = _context.Set<TEntity>().Where(e => e.Id == obj.Id);
            // if (query.Any()) _context.Set<TEntity>().Remove(obj);
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
            var itens = await _context.Set<T>().Where(x => x.Data.ToShortDateString() != DateTime.Now.ToShortDateString()).ToListAsync();
            _context.Set<T>().RemoveRange(itens);
            // await Save();
        }
        public virtual void Desativar<T>(TEntity obj) where T : Cardapio
        {
            var item = obj.Id > 0 ? _context.Set<T>().FirstOrDefault(e => e.Id == obj.Id) : null;
            item.StatusCardapio = StatusCardapio.INATIVO;
        }
        IQueryable<T> IRepositoryBase<TEntity>.Ativos<T>()
        {
            var query = _context.Set<T>().Where(x => x.StatusCardapio.Equals(StatusCardapio.ATIVO) && x.Data.ToShortDateString().Equals(DateTime.Now.ToShortDateString()));
            return query.AsQueryable().AsNoTracking();
        }

        public IQueryable<TEntity> GetByIds(int[] ids)
        {
            List<TEntity> lista = new List<TEntity>();
            foreach (var item in ids) lista.Add(GetById(item));
            return lista.AsQueryable().AsNoTracking();
        }
    }
}