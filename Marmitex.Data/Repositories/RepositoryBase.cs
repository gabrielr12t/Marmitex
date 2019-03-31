using System;
using System.Collections.Generic;
using System.Linq;
using Marmitex.Data.Context;
using Marmitex.Domain.BaseEntity;
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
            query = query.AsNoTracking();
            return query;
        }

        public virtual TEntity GetById(long id)
        {
            return id > 0 ? _context.Set<TEntity>().FirstOrDefault(e => e.Id == id) : null;
        }

        public virtual void Remove(TEntity obj)
        {
            var query = _context.Set<TEntity>().Where(e => e.Id == obj.Id);

            if (query.Any())
                _context.Set<TEntity>().Remove(obj);
        }

        public virtual void Update(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
        }
    }
}