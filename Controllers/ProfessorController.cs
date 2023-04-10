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

        public ProfessorController(IProfessorRepository professorRepository, IAlunoRepository alunoRepo)
        {
            _professorRepository = professorRepository;
            _alunoRepo = alunoRepo;
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

        [Route("Professor/Aluno/{alunoId}")]
        public IActionResult Aluno(string alunoId)
        {
            if (alunoId == null)
                return NotFound();

            var aluno = _professorRepository.GetAluno(alunoId);

            if (aluno == null)
                return NotFound();

            var alunoNotas = _professorRepository.GetAlunoNota(alunoId);

            return View(alunoNotas);
        }

        [HttpGet]
        [Route("Professor/AddNota/{id}")]
        public IActionResult AddNota(string alunoId)
        {
            var vm = new AddNotaVM();
            var turma = _alunoRepo.GetTurmaByUsername(alunoId);

            vm.Aluno = _professorRepository.GetAluno(alunoId);
            vm.MateriasProfessor = _professorRepository.GetMateriasProfessor(User.Identity.Name, turma.Id);

            return View(vm);
        }
    }
}
