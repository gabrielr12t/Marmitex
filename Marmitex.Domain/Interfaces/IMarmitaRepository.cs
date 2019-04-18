using System.Collections.Generic;
using System.Threading.Tasks;
using Marmitex.Domain.Entidades;

namespace Marmitex.Domain.Interfaces
{
    public interface IMarmitaRepository : IRepositoryBase<Marmita>
    {
        List<Marmita> Itens();
        Task AddMarmita(Marmita obj, IEnumerable<Acompanhamento> Acompanhamentos);
    }
}