using Escola.Models;
using Escola.Models.ViewModels;
using Escola.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Escola.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardRepository _repo;

        public DashboardController(IDashboardRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var vm = new IndexDashboardVM();
            vm.UltimasNotas = _repo.GetUltimasNotas();
            vm.Materias = _repo.GetMaterias();
            vm.AlunosNota = _repo.GetAlunosNota();
            vm.QtyTurmas = _repo.GetQtyTurmas();
            vm.QtyProfessores = _repo.GetQtyProfessores();
            vm.QtyAlunos = _repo.GetQtyAlunos();

            return View(vm);
        }

        public IActionResult Turmas()
        {
            List<TurmasDashboardVM> turmas = _repo.GetAllTurmas();
            return View(turmas);
        }

        public IActionResult CreateTurma()
        {
            return View();
        }

        public IActionResult EditTurma()
        {
            return View();
        }

        public IActionResult RemoveTurma()
        {
            return View();
        }
    }
}
