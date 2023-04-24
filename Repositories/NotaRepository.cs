using Escola.Data;
using Escola.Models;
using Escola.Models.ViewModels;
using Escola.Repositories.Contracts;
using System.Drawing.Drawing2D;

namespace Escola.Repositories
{
    public class NotaRepository : INotaRepository
    {
        private readonly ApplicationDbContext _db;

        public NotaRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void AddNota(AddNotaVM vm)
        {
            Nota nota = new Nota();

            nota.Valor = vm.Nota;
            nota.Faltas = vm.Faltas;
            nota.AlunoFK = vm.AlunoFK;
            nota.ProfessorFK = vm.ProfessorFK;
            nota.MateriaFK = vm.MateriaFK;
            nota.TurmaFK = vm.TurmaFK;
            nota.BimestreFK = vm.BimestreFK;
            

            _db.Notas.Add(nota);
            _db.SaveChanges();
        }

        public bool DeleteNota(int id)
        {
            var nota = _db.Notas.FirstOrDefault(x=> x.Id == id);

            if (nota != null)
            {
                _db.Notas.Remove(nota);
                _db.SaveChanges();

                return true;
            }

            return false;
        }

        public void UpdateNota(AddNotaVM vm)
        {
            var nota = _db.Notas.FirstOrDefault(x => x.Id == vm.NotaId);

            nota.Valor = vm.Nota;
            nota.Faltas = vm.Faltas;
            nota.MateriaFK = vm.MateriaFK;
            nota.BimestreFK = vm.BimestreFK;
            nota.AtualizadoEm = DateTime.Now;

            _db.Notas.Update(nota);
            _db.SaveChanges();
        }

        public NotasDoAlunoVM GetNotasDoAluno(string alunoId, int turmaId)
        {
            var notasDoAluno = new NotasDoAlunoVM();
            List<List<Nota>> todasNotas = new List<List<Nota>>();

            var materiasNaTurma = _db.MateriaTurmaProfessores.Where(x => x.TurmaFK == turmaId).ToList();

            foreach (var obj in materiasNaTurma)
            {
                todasNotas.Add(_db.Notas.Where(x => x.AlunoFK == alunoId && x.MateriaFK == obj.MateriaFK).ToList());
            }

            notasDoAluno.Aluno = _db.Users.Find(alunoId);
            notasDoAluno.Materias = _db.Materias.ToList();
            notasDoAluno.Notas = todasNotas;

            return notasDoAluno;
        }

        public NotasDoAlunoVM GetNotasAddByProf(string alunoId, string profUserName)
        {
            var prof = _db.Users.FirstOrDefault(x => x.UserName == profUserName);

            List<List<Nota>> listaComNotas = new List<List<Nota>>();
            listaComNotas.Add(_db.Notas.Where(x => x.AlunoFK == alunoId && x.ProfessorFK == prof.Id).ToList());

            var matProf = _db.MateriaTurmaProfessores.Where(x => x.Professor == prof.Id);
            var materias = new List<Materia>();

            foreach (var materia in matProf)
            {
                materias.Add(_db.Materias.FirstOrDefault(x => x.Id == materia.Id));
            }

            var notasDoAluno = new NotasDoAlunoVM();
            notasDoAluno.Aluno = _db.Users.Find(alunoId);
            notasDoAluno.Materias = materias;
            notasDoAluno.Notas = listaComNotas;

            return notasDoAluno;
        }

        public AddNotaVM GetNota(int notaId)
        {
            var nota = _db.Notas.Find(notaId);

            var vm = new AddNotaVM();
            var materiasProf = _db.MateriaTurmaProfessores.Where(x => x.TurmaFK == nota.TurmaFK && x.Professor == nota.ProfessorFK).ToList();
            var materias = new List<Materia>();

            foreach (var mat in materiasProf)
            {
                materias.Add(_db.Materias.Find(mat.MateriaFK));
            }

            vm.NotaId = nota.Id;
            vm.Nota = nota.Valor;
            vm.Faltas = nota.Faltas;
            vm.MateriaFK = nota.MateriaFK;
            vm.ProfessorFK = nota.ProfessorFK;
            vm.AlunoFK = nota.AlunoFK;
            vm.TurmaFK = nota.TurmaFK;
            vm.MateriasProfessor = materias;
            vm.BimestreFK = nota.BimestreFK;

            return vm;
        }
    }
}
