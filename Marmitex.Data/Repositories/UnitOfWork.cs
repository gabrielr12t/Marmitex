using System.Threading.Tasks;
using Marmitex.Data.Context;
using Marmitex.Domain.Interfaces;

namespace Marmitex.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}