using Microsoft.AspNetCore.Mvc;

namespace Marmitex.Web.Controllers
{
    public class TesteController : Controller
    {
        public IActionResult Teste()
        {
            return View();
        }
    }
}