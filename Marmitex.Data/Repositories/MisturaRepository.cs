using System;
using System.Linq;
using System.Threading.Tasks;
using Marmitex.Data.Context;
using Marmitex.Domain.Entidades;
using Marmitex.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Marmitex.Data.Repositories
{
    public class MisturaRepository : RepositoryBase<Mistura>, IMisturaRepository
    {
        public MisturaRepository(ApplicationDbContext context) : base(context) { }
        public override async Task Add(Mistura obj)
        {
            var mistura = obj.Id > 0 ? await _context.Misturas.FirstOrDefaultAsync(x => x.Id == obj.Id) : null;
            if (mistura == null)
            {
                //create
                mistura = new Mistura(obj.Nome, obj.AcrescimoValor, obj.Data);
                _context.Add(mistura);
                return;
            }
            //update
            mistura.Update(obj.Nome, obj.AcrescimoValor, mistura.Data);
            _context.Misturas.Update(mistura);
        }
    }
}