using Escola.Models.ViewModels;
using Escola.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Escola.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly INotaRepository _notaRepo;

        public AlunoController(IAlunoRepository alunoRepository, INotaRepository notaRepo)
        {
            _alunoRepository = alunoRepository;
            _notaRepo = notaRepo;
        }

        public IActionResult Index()
        {
            var turma = _alunoRepository.GetTurmaByUsername(User.Identity.Name);
            var aluno = _alunoRepository.GetAluno(User.Identity.Name);

            var vm = new AlunoVerTurmaVM();

            if (turma == null || aluno == null)
                return NotFound();

            vm.Turma = turma;
            vm.Aluno = aluno;

            return View(vm);
        }

        [Route("Aluno/Boletim/{alunoId}")]
        public IActionResult Boletim(string alunoId)
        {
            var notas = _notaRepo.GetNotasDoAluno(alunoId);

            if (notas == null)
                return NotFound();

            return View(notas);
        }
    }
}
