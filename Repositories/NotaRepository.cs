using Escola.Data;
using Escola.Models;
using Escola.Models.ViewModels;
using Escola.Repositories.Contracts;
using System.Drawing.Drawing2D;

namespace Escola.Repositories
{
    public class NotaRepository : RepositoryBase<Nota>, INotaRepository
    {
        private readonly ApplicationDbContext _db;

        public NotaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public NotasDoAlunoVM NotasDoAluno(string alunoId, int turmaId)
        {
            var notasDoAluno = new NotasDoAlunoVM();
            List<List<Nota>> todasNotas = new List<List<Nota>>();

            var materiasNaTurma = _db.MateriaTurmaProfessores.Where(x => x.TurmaFK == turmaId).ToList();
            List<Materia> materias = new List<Materia>();

            foreach (var obj in materiasNaTurma)
            {
                todasNotas.Add(_db.Notas.Where(x => x.AlunoFK == alunoId && x.MateriaFK == obj.MateriaFK).ToList());
                materias.Add(_db.Materias.Where(x => x.Id == obj.MateriaFK).FirstOrDefault());
            }

            notasDoAluno.Aluno = _db.Users.Find(alunoId);
            notasDoAluno.Materias = materias;
            notasDoAluno.Notas = todasNotas;
            notasDoAluno.Turma = _db.Turmas.Find(turmaId);

            return notasDoAluno;
        }

        public NotasDoAlunoVM NotasAddPeloProfessor(string alunoId, string profUserName)
        {
            var prof = _db.Users.FirstOrDefault(x => x.UserName == profUserName);

            List<List<Nota>> listaComNotas = new List<List<Nota>>();
            listaComNotas.Add(_db.Notas.Where(x => x.AlunoFK == alunoId && x.ProfessorFK == prof.Id).ToList());

            var matProf = _db.MateriaTurmaProfessores.Where(x => x.Professor == prof.Id).ToList();
            var materias = new List<Materia>();

            foreach (var materia in matProf)
            {
                var materiaObj = _db.Materias.Find(materia.MateriaFK);
                materias.Add(materiaObj);
            }

            var notasDoAluno = new NotasDoAlunoVM();
            notasDoAluno.Aluno = _db.Users.Find(alunoId);
            notasDoAluno.Materias = materias;
            notasDoAluno.Notas = listaComNotas;

            return notasDoAluno;
        }
    }
}
