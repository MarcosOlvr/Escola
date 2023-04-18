using Escola.Models.ViewModels;
using Escola.Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Escola.Controllers
{
    [Authorize(Roles = "Professor, Admin")]
    public class ProfessorController : Controller
    {
        private readonly IProfessorRepository _professorRepository;
        private readonly IAlunoRepository _alunoRepo;
        private readonly INotaRepository _notaRepo;

        public ProfessorController(IProfessorRepository professorRepository, 
            IAlunoRepository alunoRepo,
            INotaRepository notaRepo)
        {
            _professorRepository = professorRepository;
            _alunoRepo = alunoRepo;
            _notaRepo = notaRepo;
        }

        public IActionResult TurmasGeral()
        {
            var turmas = _professorRepository.GetTurmas(User.Identity.Name);
            return View(turmas);
        }

        [Route("Professor/Turma/{turmaId}")]
        public IActionResult Turma([FromRoute]int turmaId)
        {
            if (turmaId == 0)
                return NotFound();

            var usuariosNaTurma = _professorRepository.GetUsuariosNaTurma(turmaId);

            if (usuariosNaTurma == null)
                return NotFound();

            return View(usuariosNaTurma);
        }

        [HttpGet]
        [Route("Professor/AddNota/{alunoId}")]
        public IActionResult AddNota(string alunoId)
        {
            var vm = new AddNotaVM();
            var turma = _alunoRepo.GetTurmaById(alunoId);
            vm.AlunoFK = alunoId;
            vm.ProfessorFK = _professorRepository.GetProfessor(User.Identity.Name).Id;
            vm.TurmaFK = turma.Id;
            vm.MateriasProfessor = _professorRepository.GetMateriasProfessor(User.Identity.Name, turma.Id);

            return View(vm);
        }

        [HttpPost]
        [Route("Professor/AddNota/{alunoId}")]
        public IActionResult AddNota(AddNotaVM vm) 
        {
            if (ModelState.IsValid)
            {
                _notaRepo.AddNota(vm);
                return RedirectToAction("Aluno", new { alunoId = vm.AlunoFK });
            }

            return View(vm);
        }

        [HttpGet]
        [Route("Professor/ViewInfos/{alunoId}")]
        public IActionResult ViewInfos(string alunoId)
        {
            var vm = new NotasDoAlunoVM();

            vm = _notaRepo.GetNotasAddByProf(alunoId, User.Identity.Name);

            return View(vm);
        }

        [HttpGet]
        [Route("Professor/Edit/{notaId:int}")]
        public IActionResult Edit(int notaId)
        {
            return View();
        }

        [HttpPost]
        [Route("Professor/Edit/{notaId:int}")]
        public IActionResult Edit()
        {
            return View();
        }
    }
}
