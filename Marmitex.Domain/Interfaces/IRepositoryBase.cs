using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marmitex.Domain.BaseEntity;

namespace Marmitex.Domain.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : Entity
    {
        void Add(TEntity obj);
        TEntity GetById(long id);
        IQueryable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        Task Save();
    }
}