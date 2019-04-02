using System;
using System.Linq;
using Marmitex.Data.Context;
using Marmitex.Domain.Entidades;
using Marmitex.Domain.Interfaces;

namespace Marmitex.Data.Repositories
{
    public class MisturaRepository : RepositoryBase<Mistura>, IMisturaRepository
    {
        public MisturaRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override void Add(Mistura obj)
        {
            var mistura = obj.Id > 0 ? _context.Misturas.FirstOrDefault(x => x.Id == obj.Id) : null;
            if (mistura == null)
            {
                //create
                mistura = new Mistura(obj.Nome, obj.AcrescimoValor, obj.Data);
                _context.Add(mistura);
                return;
            }
            //update
            mistura.Update(obj.Nome, obj.AcrescimoValor, mistura.Data);

        }
        public override IQueryable<Mistura> GetAll()
        {
            //get mistura do dia
            return _context.Misturas.Where(c => c.Data.ToShortDateString().Equals(DateTime.Now.ToShortDateString()));
        }
    }
}