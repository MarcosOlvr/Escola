using Escola.Data;
using Escola.Models;
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
    }
}
