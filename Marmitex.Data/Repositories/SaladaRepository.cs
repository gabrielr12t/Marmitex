using Marmitex.Data.Context;
using Marmitex.Domain.Entidades;
using Marmitex.Domain.Interfaces;

namespace Marmitex.Data.Repositories
{
    public class SaladaRepository : RepositoryBase<Salada>, ISaladaRepository
    {
        public SaladaRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}