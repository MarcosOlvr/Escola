using Escola.Data;
using Escola.Models;
using Escola.Repositories.Contracts;

namespace Escola.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly ApplicationDbContext _db;

        public DashboardRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<ApplicationUser> GetAlunosNota()
        {
            List<ApplicationUser> alunos = new List<ApplicationUser>();

            var ultimasNotas = GetUltimasNotas();

            foreach (var obj in ultimasNotas)
            {
                var aluno = _db.Users.FirstOrDefault(x => x.Id == obj.AlunoFK);

                if (!alunos.Contains(aluno))
                        alunos.Add(aluno);
            }

            return alunos;
        }

        public List<Materia> GetMaterias()
        {
            return _db.Materias.ToList().Take(5).ToList();
        }

        public List<Nota> GetUltimasNotas()
        {
            return _db.Notas.ToList().TakeLast(5).ToList();
        }
    }
}
