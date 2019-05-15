using System.Threading.Tasks;
using Marmitex.Data.Context;
using Marmitex.Domain.Entidades;
using Marmitex.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Marmitex.Data.Repositories
{
    public class SaladaRepository : RepositoryBase<Salada>, ISaladaRepository
    {
        public SaladaRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task Add(Salada obj)
        {
            var salada = obj.Id > 0 ? await _context.Saladas.FirstOrDefaultAsync(x => x.Id == obj.Id) : null;
            if (salada == null)
            {
                //create
                salada = new Salada(obj.Nome, obj.Data);
                _context.Add(salada);
                return;
            }
            //update
            salada.Update(obj.Nome, salada.Data);
            //_context.Saladas.Update(salada);
        }
    }
}