using System.Collections.Generic;
using Marmitex.Domain.Entidades;

namespace Marmitex.Domain.Interfaces
{
    public interface IMarmitaRepository : IRepositoryBase<Marmita>
    {
        List<Marmita> Itens();
    }
}