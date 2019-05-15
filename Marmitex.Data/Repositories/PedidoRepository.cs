using System;
using System.Collections.Generic;
using System.Linq;
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
        public IQueryable<dynamic> GetPeidos()
        {

            //var marm = _context.Marmitas.Include(a => a.MarmitaAcompanhamentos).ToList();


            var query = _context.Pedidos
                .Include(cliente => cliente.Cliente)
                .Include(marmitas => marmitas.Marmitas)
                    .ThenInclude(mistura => mistura.Mistura)
                .Include(marmita => marmita.Marmitas)
                    .ThenInclude(mistura => mistura.Salada);
            return query;
        }
    }
}