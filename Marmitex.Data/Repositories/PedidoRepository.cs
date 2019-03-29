using System;
using System.Linq;
using Marmitex.Data.Context;
using Marmitex.Domain.Entidades;
using Marmitex.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Marmitex.Data.Repositories
{
    public class PedidoRepository : RepositoryBase<Pedido>, IPedidoRepository
    {
        public PedidoRepository(ApplicationDbContext context) : base(context) { }
        public IQueryable<Pedido> GetPedidoDia()
        {
            var query = _context.Set<Pedido>().Where(p => p.Data.ToShortDateString().Equals(DateTime.Now.ToShortDateString()));
            return query.Any() ? query.AsQueryable() : null;
        }
    }
}