using Marmitex.Data.Context;
using Marmitex.Domain.Entidades;
using Marmitex.Domain.Interfaces;

namespace Marmitex.Data.Repositories
{
    public class MisturaRepository : RepositoryBase<Mistura>, IMisturaRepository
    {
        public MisturaRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}