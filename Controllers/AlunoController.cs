using Escola.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Escola.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoController(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public IActionResult Index()
        {
            var turma = _alunoRepository.GetTurmaByUsername(User.Identity.Name);

            if (turma == null)
                return NotFound();

            return View(turma);
        }

        public IActionResult Boletim(int turmaId)
        {
            var notas = _alunoRepository.GetNotasDoAluno(User.Identity.Name, turmaId);

            if (notas == null)
                return NotFound();

            return View(notas);
        }
    }
}
