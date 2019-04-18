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


        public async Task AddMarmita(Marmita obj, IEnumerable<Acompanhamento> Acompanhamentos)
        {
            try
            {
                await _context.Marmitas.AddAsync(new Marmita(obj.Salada, obj.Mistura, obj.Valor, obj.Tamanho, (List<Acompanhamento>)obj.Acompanhamentos));
                await _context.MarmitaAcompanhamentos.AddRangeAsync(new List<MarmitaAcompanhamento>().Select(m => m));
            }
            catch (System.Exception)
            {
                throw;
            }
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