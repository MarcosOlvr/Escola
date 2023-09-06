using Escola.Models.ViewModels;
using Escola.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Escola.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IDashboardRepository _dashboardRepo;
        private readonly INotaRepository _notaRepo;

        public AlunoController(IAlunoRepository alunoRepository, INotaRepository notaRepo, IDashboardRepository dashboardRepo)
        {
            _alunoRepository = alunoRepository;
            _notaRepo = notaRepo;
            _dashboardRepo = dashboardRepo; 
        }

        public IActionResult Index()
        {
            var turma = _alunoRepository.TurmaByUsername(User.Identity.Name);
            var aluno = _dashboardRepo.GetUser(User.Identity.Name);

            var vm = new AlunoVerTurmaVM();

            if (turma == null || aluno == null)
                return NotFound();

            vm.Turma = turma;
            vm.Aluno = aluno;

            return View(vm);
        }

        [Route("Aluno/Boletim/{turmaId:int}/{alunoId}")]
        public IActionResult Boletim(int turmaId, string alunoId)
        {
            var notas = _notaRepo.NotasDoAluno(alunoId, turmaId);

            if (notas == null)
                return NotFound();

            return View(notas);
        }
    }
}
