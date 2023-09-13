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
            vm.UltimasNotas = _repo.UltimasNotas();
            vm.Materias = _repo.GetMaterias();
            vm.AlunosNota = _repo.NotasDoAluno();
            vm.QtyTurmas = _repo.QtyTurmas();
            vm.QtyProfessores = _repo.QtyProfessores();
            vm.QtyAlunos = _repo.QtyAlunos();
            vm.QtyUsuarios = _repo.QtyUsuarios();

            return View(vm);
        }

        public IActionResult Turmas()
        {
            List<TurmasDashboardVM> turmas = _repo.GetTurmas();
            return View(turmas);
        }

        [HttpGet]
        [Route("Dashboard/ViewTurma/{turmaId:int}")]
        public IActionResult ViewTurma(int turmaId)
        {
            if (turmaId == 0)
                return NotFound();

            var usuariosNaTurma = _professorRepo.UsuariosNaTurma(turmaId);

            if (usuariosNaTurma == null)
                return NotFound();

            return View(usuariosNaTurma);
        }

        [HttpGet]
        public IActionResult CriarTurma()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CriarTurma(Turma obj)
        {
            if (ModelState.IsValid)
            {
                _turmaRepo.Add(obj);

                return RedirectToAction("Turmas");
            }

            return View(obj);
        }

        [HttpGet]
        [Route("Dashboard/EditarTurma/{turmaId:int}")]
        public IActionResult EditarTurma(int turmaId)
        {
            var turma = _turmaRepo.Get(turmaId);

            if (turma == null)
                return NotFound();

            return View(turma);
        }

        [HttpPost]
        [Route("Dashboard/EditarTurma/{turmaId:int}")]
        public IActionResult EditarTurma(Turma obj)
        {
            if (ModelState.IsValid)
            {
                _turmaRepo.Update(obj);

                return RedirectToAction("Turmas");
            }

            return View(obj);
        }

        [HttpGet]
        [Route("Dashboard/RemoverTurma/{turmaId:int}")]
        public IActionResult RemoverTurma(int turmaId)
        {
            var turma = _turmaRepo.Get(turmaId);

            if (turma == null)
                return NotFound();

            return View(turma);
        }

        [HttpPost]
        public IActionResult RemoverTurmaPost(Turma obj)
        {
            _turmaRepo.Delete(obj.Id);

            return RedirectToAction("Turmas");
        }

        [HttpGet]
        [Route("Dashboard/AddProfessorNaTurma/{turmaId:int}")]
        public IActionResult AddProfessorNaTurma(int turmaId)
        {
            var vm = new AddUserTurmaVM();
            vm.TurmaFK = turmaId;
            vm.UserList = _repo.GetProfessores(turmaId);

            return View(vm);
        }

        [HttpGet("Dashboard/AddAlunoTurma/{turmaId:int}")]
        public IActionResult AddAlunoNaTurma(int turmaId)
        {
            var vm = new AddUserTurmaVM();
            vm.UserList = _repo.AlunosSemTurma();
            vm.TurmaFK = turmaId;

            return View(vm);
        }

        [HttpPost]
        public IActionResult AddUserNaTurma(AddUserTurmaVM vm)
        {
            if (ModelState.IsValid)
            {
                _turmaRepo.AddUserNaTurma(vm);
                return RedirectToAction("ViewTurma", new { turmaID = vm.TurmaFK });
            }
            
            return View(vm);
        }


        [HttpGet("Dashboard/RemoverUserDaTurma/{turmaId:int}/{userId}")]
        public IActionResult RemoverUserDaTurma(string userId, int turmaId)
        {
            var vm = new AddUserTurmaVM();
            var turmaUser = _turmaRepo.GetTurmaDoUser(turmaId, userId);
            var userList = new List<ApplicationUser>();
            userList.Add(_repo.GetUser(userId));

            vm.UserFK = turmaUser.UserFK;
            vm.TurmaFK = turmaUser.TurmaFK;
            vm.UserList = userList;
            
            return View(vm);
        }

        [HttpPost]
        public IActionResult RemoverUserDaTurmaPost(AddUserTurmaVM vm)
        {
            if (ModelState.IsValid)
            {
                _turmaRepo.RemoverUserDaTurma(vm.TurmaFK, vm.UserFK);

                return RedirectToAction("ViewTurma", new { turmaID = vm.TurmaFK });
            }

            return View(vm);
        }

        [HttpGet("Dashboard/Professor/{turmaId:int}/{userId}")]
        public IActionResult EditarProfessorNaTurma(string userId, int turmaId)
        {   
            var turmaUser = _turmaRepo.GetTurmaDoUser(turmaId, userId);
            var userList = new List<ApplicationUser>();
            userList.Add(_repo.GetUser(userId));
            var todasMaterias = _materiaRepo.GetAll();

            var materiasDoProfessorNaTurma = _professorRepo.MateriasDoProfessorNaTurma(_repo.GetUser(userId).UserName, turmaId);

            foreach (var materia in materiasDoProfessorNaTurma)
            {
                if (todasMaterias.Contains(materia))
                {
                    todasMaterias.Remove(materia);
                }
            }

            var vm = new MateriaTurmaProfessorVM
            {
                ProfessorId = turmaUser.UserFK,
                TurmaId = turmaUser.TurmaFK,
                UserList = userList,
                Materias = todasMaterias
            };

            return View(vm);
        }

        [HttpPost("Dashboard/Professor/{turmaId:int}/{userId}")]
        public IActionResult EditarProfessorNaTurma(MateriaTurmaProfessorVM vm)
        {
            if (ModelState.IsValid)
            {
                _turmaRepo.AddTurmaMateriaProfessor(vm);
                return RedirectToAction("ViewTurma", new { turmaID = vm.TurmaId });
            }

            return View(vm);
        }

        [HttpGet("Dashboard/Professor/RemoverMateria/{turmaId:int}/{userId}")]
        public IActionResult RemoverMateriaDoProfessor(int turmaId, string userId)
        {
            var turmaUser = _turmaRepo.GetTurmaDoUser(turmaId, userId);
            var userList = new List<ApplicationUser>();
            userList.Add(_repo.GetUser(userId));

            var materiasDoProfessorNaTurma = _professorRepo.MateriasDoProfessorNaTurma(_repo.GetUser(userId).UserName, turmaId);

            var vm = new MateriaTurmaProfessorVM
            {
                ProfessorId = turmaUser.UserFK,
                TurmaId = turmaUser.TurmaFK,
                UserList = userList,
                Materias = materiasDoProfessorNaTurma
            };

            return View(vm);    
        }

        [HttpPost]
        public IActionResult RemoverMateriaDoProfessorPost(MateriaTurmaProfessorVM vm)
        {
            if (ModelState.IsValid)
            {
                _materiaRepo.RemoverMateriaDeUmProfessor(vm);
                return RedirectToAction("ViewTurma", new { turmaID = vm.TurmaId });
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

        [HttpGet("Dashboard/Materia/Info/{materiaId:int}")]
        public IActionResult InfoMateria(int materiaId)
        {
            var vm = new MateriaNaTurmaDTO();
                
            vm.Turmas = _materiaRepo.TurmasComMateria(materiaId);
            vm.Materia = _materiaRepo.Get(materiaId);

            return View(vm);
        }

        [HttpGet]
        public IActionResult CriarMateria()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CriarMateria(Materia obj)
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
        public IActionResult EditarMateria(int materiaId)
        {
            var materia = _materiaRepo.Get(materiaId);

            if (materia == null)
                return NotFound();

            return View(materia);
        }

        [HttpPost]
        [Route("Dashboard/EditMateria/{materiaId:int}")]
        public IActionResult EditarMateria(Materia obj)
        {
            if (ModelState.IsValid)
            {
                _materiaRepo.Update(obj);

                return RedirectToAction("Materias");
            }

            return View(obj);
        }

        [HttpGet]
        [Route("Dashboard/RemoverMateria/{materiaId:int}")]
        public IActionResult RemoverMateria(int materiaId)
        {
            var materia = _materiaRepo.Get(materiaId);

            if (materia == null)
                return NotFound();

            return View(materia);
        }

        [HttpPost]
        public IActionResult RemoverMateriaPost(Turma obj)
        {
            _materiaRepo.Delete(obj.Id);

            return RedirectToAction("Materias");
        }
    }
}
