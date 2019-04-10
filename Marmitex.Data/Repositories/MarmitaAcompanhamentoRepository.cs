using Marmitex.Data.Context;
using Marmitex.Domain.Entidades;
using Marmitex.Domain.Interfaces;

namespace Marmitex.Data.Repositories
{
    public class MarmitaAcompanhamentoRepository : RepositoryBase<MarmitaAcompanhamento>, IMarmitaAcompanhamentoRepository
    {
        public MarmitaAcompanhamentoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}