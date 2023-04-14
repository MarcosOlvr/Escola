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

        public NotasDoAlunoVM GetNotasDoAluno(string alunoId)
        {
            var portugues = _db.Notas.Where(x => x.AlunoFK == alunoId && x.MateriaFK == 2).ToList();
            var matematica = _db.Notas.Where(x => x.AlunoFK == alunoId && x.MateriaFK == 1).ToList();
            var historia = _db.Notas.Where(x => x.AlunoFK == alunoId && x.MateriaFK == 3).ToList();
            var geografia = _db.Notas.Where(x => x.AlunoFK == alunoId && x.MateriaFK == 4).ToList();
            var ciencias = _db.Notas.Where(x => x.AlunoFK == alunoId && x.MateriaFK == 5).ToList();

            var notasDoAluno = new NotasDoAlunoVM();
            List<List<Nota>> todasNotas = new List<List<Nota>>();
            todasNotas.Add(portugues);
            todasNotas.Add(matematica);
            todasNotas.Add(historia);
            todasNotas.Add(geografia);
            todasNotas.Add(ciencias);


            notasDoAluno.Aluno = _db.Users.Find(alunoId);
            notasDoAluno.Materias = _db.Materias.ToList();
            notasDoAluno.Notas = todasNotas;

            return notasDoAluno;
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
