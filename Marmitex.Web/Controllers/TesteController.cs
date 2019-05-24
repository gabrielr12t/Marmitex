using Microsoft.AspNetCore.Mvc;

namespace Marmitex.Web.Controllers
{
    public class TesteController : Controller
    {
        [HttpGet]
        public IActionResult TesteAPI()
        {
            return View();
        }
    }
}