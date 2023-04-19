using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
