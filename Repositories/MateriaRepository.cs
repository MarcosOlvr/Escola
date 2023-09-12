using Escola.Data;
using Escola.Models;
using Escola.Models.ViewModels;
using Escola.Repositories.Contracts;

namespace Escola.Repositories
{
    public class MateriaRepository : RepositoryBase<Materia>, IMateriaRepository
    {
        private readonly ApplicationDbContext _db;

        public MateriaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void AddMateriaNaTurma(MateriaNaTurmaDTO materia)
        {
            throw new NotImplementedException();
        }

        public void RemoverMateriaDaTurma(int materiaId)
        {
            throw new NotImplementedException();
        }

        public List<Turma> TurmasComMateria(int materiaId)
        {
            var turmas = new List<Turma>();    

            var turmaIdList = _db.MateriaTurmaProfessores.Where(x => x.MateriaFK == materiaId).ToList();

            foreach (var obj in turmaIdList)
            {
                turmas.Add(_db.Turmas.Find(obj.TurmaFK));
            }

            return turmas;
        }

        public List<Turma> TurmasSemAMateria(int materiaId)
        {
            var turmas = _db.Turmas.ToList();

            var turmaIdList = _db.MateriaTurmaProfessores.Where(x => x.MateriaFK == materiaId).ToList();

            foreach (var turma in turmas.ToList())
            {
                foreach(var turmaId in turmaIdList)
                {
                    if (turmaId.TurmaFK == turma.Id)
                        turmas.Remove(turma);
                }
            }

            return turmas;
        }
    }
}
