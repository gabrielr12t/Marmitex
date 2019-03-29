using Marmitex.Data.Context;
using Marmitex.Domain.Entidades;
using Marmitex.Domain.Interfaces;

namespace Marmitex.Data.Repositories
{
    public class ItensPedidoRepository : RepositoryBase<ItensPedido>, IItensPedidoRepository
    {
        public ItensPedidoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}