using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marmitex.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;

namespace Marmitex.Domain.Interfaces
{
    public interface IPedidoRepository : IRepositoryBase<Pedido>
    {
        //IQueryable GetPedidoDia();
        IQueryable<dynamic> GetPeidos();
    }
}