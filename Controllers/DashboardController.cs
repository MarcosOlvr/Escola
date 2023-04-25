using Microsoft.AspNetCore.Mvc;

namespace Escola.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
