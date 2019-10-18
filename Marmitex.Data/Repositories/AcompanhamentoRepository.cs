using System.Threading.Tasks;
using Marmitex.Data.Context;
using Marmitex.Domain.Entidades;
using Marmitex.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Marmitex.Data.Repositories
{
    public class AcompanhamentoRepository : RepositoryBase<Acompanhamento>, IAcompanhamentoRepository
    {
        public AcompanhamentoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task Add(Acompanhamento obj)
        {
            var acompanhamento = obj.Id > 0 ? await _context.Acompanhamentos.FirstOrDefaultAsync(x => x.Id == obj.Id) : null;
            if (acompanhamento == null)
            {
                acompanhamento = new Acompanhamento(obj.Nome, obj.Data);
                await base.Add(acompanhamento);
                return;
            }
            acompanhamento.Update(obj.Nome, acompanhamento.Data);
        }
    }
}