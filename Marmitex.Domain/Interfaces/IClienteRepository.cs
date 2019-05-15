using System.Linq;
using System.Threading.Tasks;
using Marmitex.Domain.Entidades;

namespace Marmitex.Domain.Interfaces
{
    public interface IClienteRepository : IRepositoryBase<Cliente>
    {
        Task<Cliente> GetClienteByTelefone(string telefone);
        IQueryable<Pedido> ClientePedidos(int id);

        
    }
}