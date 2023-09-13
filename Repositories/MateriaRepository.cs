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

        public void RemoverMateriaDeUmProfessor(MateriaTurmaProfessorVM obj)
        {
            try
            {
                var model = new MateriaTurmaProfessor
                {
                    MateriaFK = obj.MateriaId,
                    Professor = obj.ProfessorId,
                    TurmaFK = obj.TurmaId,
                };

                var materiaTurmaProfessor = _db.MateriaTurmaProfessores.Where(x => x.Professor == model.Professor
                    && x.MateriaFK == model.MateriaFK
                    && x.TurmaFK == model.TurmaFK)
                    .FirstOrDefault();

                _db.MateriaTurmaProfessores.Remove(materiaTurmaProfessor);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
