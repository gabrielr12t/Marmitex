using Marmitex.Data.Context;
using Marmitex.Domain.Entidades;
using Marmitex.Domain.Interfaces;

namespace Marmitex.Data.Repositories
{
    public class MarmitaRepository : RepositoryBase<Marmita>, IMarmitaRepository
    {
        public MarmitaRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}