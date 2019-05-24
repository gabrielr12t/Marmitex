using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Marmitex.Data.Context;
using Marmitex.Domain.Entidades;
using Marmitex.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;

namespace Marmitex.Data.Repositories
{
    public class PedidoRepository : RepositoryBase<Pedido>, IPedidoRepository
    {
        public PedidoRepository(ApplicationDbContext context) : base(context) { }
        public async Task<List<Pedido>> GetPedidos(Expression<Func<Pedido, bool>> predicate = null)
        {
            var query = _context.Pedidos
                .Include(c => c.Cliente)
                .Include(m => m.Marmitas)
                    .ThenInclude(mi => mi.Mistura)
                .Include(m => m.Marmitas)
                    .ThenInclude(sa => sa.Salada)
                .Include(m => m.Marmitas)
                    .ThenInclude(a => a.MarmitaAcompanhamentos)
                        .ThenInclude(c => c.Acompanhamento)
                .OrderBy(x => x.Data);

            if (predicate != null) return await query.Where(predicate).ToListAsync();

            return await query.ToListAsync();
        }
    }
}