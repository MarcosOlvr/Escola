using Escola.Data;
using Escola.Models;
using Escola.Repositories.Contracts;

namespace Escola.Repositories
{
    public class TurmaRepository : RepositoryBase<Turma>, ITurmaRepository
    {
        public TurmaRepository(ApplicationDbContext db): base(db)
        {
        }
    }
}
