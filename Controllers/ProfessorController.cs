using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Escola.Controllers
{
    [Authorize(Roles = "Professor, Admin")]
    public class ProfessorController : Controller
    {
        public IActionResult Turmas()
        {
            return View();
        }
    }
}
