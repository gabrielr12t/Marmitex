
using System.Threading.Tasks;
using Marmitex.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Marmitex.Web.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoController(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        [HttpGet]
        public IActionResult PedidosDoDia()
        {
            var pedidos = _pedidoRepository.GetPeidos();
            return View();
        }
    }
}