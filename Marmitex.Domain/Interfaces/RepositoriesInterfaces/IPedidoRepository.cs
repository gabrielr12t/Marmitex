using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Marmitex.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;

namespace Marmitex.Domain.Interfaces
{
    public interface IPedidoRepository : IRepositoryBase<Pedido>
    {
        Task<List<Pedido>> GetPedidos(Expression<Func<Pedido, bool>> predicate = null);
    }
}