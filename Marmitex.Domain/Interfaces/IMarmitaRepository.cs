using System.Collections.Generic;
using System.Threading.Tasks;
using Marmitex.Domain.Entidades;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Marmitex.Domain.Interfaces
{
    public interface IMarmitaRepository : IRepositoryBase<Marmita>
    {
        Task FinalizandoPedido(List<Marmita> marmitas, Cliente cliente, Pedido pedido);        
    }
}