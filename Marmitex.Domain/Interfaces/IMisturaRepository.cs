using System.Threading.Tasks;
using Marmitex.Domain.Entidades;

namespace Marmitex.Domain.Interfaces
{
    public interface IMisturaRepository : IRepositoryBase<Mistura>
    {
        void RemoveMisturaAntiga();
    }
}