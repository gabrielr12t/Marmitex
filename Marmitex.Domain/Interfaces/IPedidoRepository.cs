using System.Linq;
using Marmitex.Domain.Entidades;

namespace Marmitex.Domain.Interfaces
{
    public interface IPedidoRepository : IRepositoryBase<Pedido>
    {
        IQueryable<Pedido> GetPedidoDia();
    }
}