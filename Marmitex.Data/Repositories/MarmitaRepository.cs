using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marmitex.Data.Context;
using Marmitex.Domain.Entidades;
using Marmitex.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Marmitex.Data.Repositories
{
    public class MarmitaRepository : RepositoryBase<Marmita>, IMarmitaRepository
    {
        public MarmitaRepository(ApplicationDbContext context) : base(context)
        {
        }


        public override void Add(Marmita obj)
        {
            var marmita = new Marmita(obj.Salada, obj.Mistura, obj.Valor, obj.Tamanho, (List<Acompanhamento>)obj.Acompanhamentos);
             _context.Marmitas.Add(marmita);
        }
        public List<Marmita> Itens()
        {
            var itens = _context.Marmitas
                .Include(f => f.Acompanhamentos)
                .Include(x => x.Misturas)
                .Include(y => y.Saladas)
                .AsNoTracking();
            return itens.ToList();
        }
    }
}