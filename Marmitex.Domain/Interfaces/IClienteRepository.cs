using System.Linq;
using Marmitex.Domain.Entidades;

namespace Marmitex.Domain.Interfaces
{
    public interface IClienteRepository : IRepositoryBase<Cliente>
    {
        Cliente GetClienteByTelefone(string telefone);
        IQueryable<Pedido> ClientePedidos(int id);        
    }
}