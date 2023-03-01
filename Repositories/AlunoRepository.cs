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

        public NotasDoAlunoVM GetNotasDoAluno(string userName, int turmaId)
        {
            var aluno = _db.Users.FirstOrDefault(u => u.UserName == userName);

            var portugues = _db.Notas.Where(x => x.AlunoFK == aluno.Id && x.MateriaFK == 1 && x.TurmaFK == turmaId).ToList();
            var matematica = _db.Notas.Where(x => x.AlunoFK == aluno.Id && x.MateriaFK == 2 && x.TurmaFK == turmaId).ToList();
            var historia = _db.Notas.Where(x => x.AlunoFK == aluno.Id && x.MateriaFK == 3 && x.TurmaFK == turmaId).ToList();
            var geografia = _db.Notas.Where(x => x.AlunoFK == aluno.Id && x.MateriaFK == 4 && x.TurmaFK == turmaId).ToList();
            var ciencias = _db.Notas.Where(x => x.AlunoFK == aluno.Id && x.MateriaFK == 5 && x.TurmaFK == turmaId).ToList();

            var notasDoAluno = new NotasDoAlunoVM();

            notasDoAluno.Aluno = aluno;
            notasDoAluno.Portugues = portugues;
            notasDoAluno.Matematica = matematica;
            notasDoAluno.Historia = historia;
            notasDoAluno.Geografia = geografia;
            notasDoAluno.Ciencias = ciencias;

            return notasDoAluno;
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
