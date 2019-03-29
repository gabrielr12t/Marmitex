using Marmitex.Data.Context;
using Marmitex.Domain.Entidades;
using Marmitex.Domain.Interfaces;

namespace Marmitex.Data.Repositories
{
    public class AcompanhamentoRepository : RepositoryBase<Acompanhamento>, IAcompanhamentoRepository
    {
        public AcompanhamentoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}