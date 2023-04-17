using Escola.Data;
using Escola.Models;
using Escola.Models.ViewModels;
using Escola.Repositories.Contracts;

namespace Escola.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly ApplicationDbContext _db;

        public AlunoRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public ApplicationUser GetAluno(string userName)
        {
            return _db.Users.FirstOrDefault(u => u.UserName == userName);
        }

        public Turma GetTurmaById(string alunoId)
        {
            var turmaDoAluno = _db.TurmaUser.FirstOrDefault(x => x.UserFK ==  alunoId);
            var turma = _db.Turmas.FirstOrDefault(x => x.Id == turmaDoAluno.TurmaFK);

            return turma;
        }

        public Turma GetTurmaByUsername(string userName)
        {
            var aluno = _db.Users.FirstOrDefault(u => u.UserName == userName);

            var turmaDoAluno = _db.TurmaUser.FirstOrDefault(x => x.UserFK == aluno.Id);

            var turma = _db.Turmas.FirstOrDefault(x => x.Id == turmaDoAluno.TurmaFK);

            return turma;
        }
    }
}
