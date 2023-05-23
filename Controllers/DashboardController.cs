using Escola.Models;
using Escola.Models.ViewModels;
using Escola.Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Escola.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly IDashboardRepository _repo;
        private readonly ITurmaRepository _turmaRepo;
        private readonly IProfessorRepository _professorRepo;
        private readonly IMateriaRepository _materiaRepo;

        public DashboardController(IDashboardRepository repo, 
            ITurmaRepository turmaRepo,
            IProfessorRepository professorRepo,
            IMateriaRepository materiaRepo)
        {
            _repo = repo;
            _turmaRepo = turmaRepo;
            _professorRepo = professorRepo;
            _materiaRepo = materiaRepo;
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

        [HttpGet]
        [Route("Dashboard/ViewTurma/{turmaId:int}")]
        public IActionResult ViewTurma(int turmaId)
        {
            if (turmaId == 0)
                return NotFound();

            var usuariosNaTurma = _professorRepo.GetUsuariosNaTurma(turmaId);

            if (usuariosNaTurma == null)
                return NotFound();

            return View(usuariosNaTurma);
        }

        [HttpGet]
        public IActionResult CreateTurma()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTurmaPost(Turma obj)
        {
            if (ModelState.IsValid)
            {
                _turmaRepo.Add(obj);

                return RedirectToAction("Turmas");
            }

            return View(obj);
        }

        [HttpGet]
        [Route("Dashboard/EditTurma/{turmaId:int}")]
        public IActionResult EditTurma(int turmaId)
        {
            var turma = _turmaRepo.Get(turmaId);

            if (turma == null)
                return NotFound();

            return View(turma);
        }

        [HttpPost]
        public IActionResult EditTurmaPost(Turma obj)
        {
            if (ModelState.IsValid)
            {
                _turmaRepo.Update(obj);

                return RedirectToAction("Turmas");
            }

            return View(obj);
        }

        [HttpGet]
        [Route("Dashboard/RemoveTurma/{turmaId:int}")]
        public IActionResult RemoveTurma(int turmaId)
        {
            var turma = _turmaRepo.Get(turmaId);

            if (turma == null)
                return NotFound();

            return View(turma);
        }

        [HttpPost]
        public IActionResult RemoveTurmaPost(Turma obj)
        {
            _turmaRepo.Delete(obj.Id);

            return RedirectToAction("Turmas");
        }

        [HttpGet]
        [Route("Dashboard/AddProfTurma/{turmaId:int}")]
        public IActionResult AddProfTurma(int turmaId)
        {
            var vm = new AddUserTurmaVM();
            vm.UserList = _repo.GetAllProfs();
            vm.TurmaFK = turmaId;

            return View(vm);
        }

        [HttpGet("Dashboard/AddAlunoTurma/{turmaId:int}")]
        public IActionResult AddAlunoTurma(int turmaId)
        {
            var vm = new AddUserTurmaVM();
            vm.UserList = _repo.GetAllAlunosSemTurma();
            vm.TurmaFK = turmaId;

            return View(vm);
        }

        [HttpPost]
        public IActionResult AddUserTurma(AddUserTurmaVM vm)
        {
            if (ModelState.IsValid)
            {
                _turmaRepo.AddUserTurma(vm);
                return RedirectToAction("ViewTurma", new { turmaID = vm.TurmaFK });
            }
            
            return View(vm);
        }


        [HttpGet("Dashboard/RemoverUserTurma/{turmaId:int}/{userId}")]
        public IActionResult RemoverUserTurma(string userId, int turmaId)
        {
            var vm = new AddUserTurmaVM();
            var turmaUser = _turmaRepo.GetTurmaUser(turmaId, userId);
            var userList = new List<ApplicationUser>();
            userList.Add(_repo.GetUser(userId));

            vm.UserFK = turmaUser.UserFK;
            vm.TurmaFK = turmaUser.TurmaFK;
            vm.UserList = userList;
            
            return View(vm);
        }

        [HttpPost]
        public IActionResult RemoverUserTurmaPost(AddUserTurmaVM vm)
        {
            if (ModelState.IsValid)
            {
                _turmaRepo.RemoverUserTurma(vm.TurmaFK, vm.UserFK);

                return RedirectToAction("ViewTurma", new { turmaID = vm.TurmaFK });
            }

            return View(vm);
        }

        [HttpGet]
        public IActionResult Materias()
        {
            var materias = _materiaRepo.GetAll();

            if (materias == null)
                return NotFound();

            return View(materias);
        }

        [HttpGet]
        public IActionResult CreateMateria()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMateria(Materia obj)
        {
            if (ModelState.IsValid)
            {
                _materiaRepo.Add(obj);
                return RedirectToAction("Materias");
            }

            return View(obj);
        }

        [HttpGet]
        [Route("Dashboard/EditMateria/{materiaId:int}")]
        public IActionResult EditMateria(int materiaId)
        {
            var materia = _materiaRepo.Get(materiaId);

            if (materia == null)
                return NotFound();

            return View(materia);
        }

        [HttpPost]
        public IActionResult EditMateria(Materia obj)
        {
            if (ModelState.IsValid)
            {
                _materiaRepo.Update(obj);

                return RedirectToAction("Materias");
            }

            return View(obj);
        }

        [HttpGet]
        [Route("Dashboard/RemoveMateria/{materiaId:int}")]
        public IActionResult RemoveMateria(int materiaId)
        {
            var materia = _materiaRepo.Get(materiaId);

            if (materia == null)
                return NotFound();

            return View(materia);
        }

        [HttpPost]
        public IActionResult RemoveMateriaPost(Turma obj)
        {
            _materiaRepo.Delete(obj.Id);

            return RedirectToAction("Materias");
        }
    }
}
