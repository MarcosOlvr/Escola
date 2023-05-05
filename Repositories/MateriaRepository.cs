using Escola.Data;
using Escola.Models;
using Escola.Repositories.Contracts;

namespace Escola.Repositories
{
    public class MateriaRepository : RepositoryBase<Materia>, IMateriaRepository
    {
        public MateriaRepository(ApplicationDbContext db) : base(db)
        {
            
        }
    }
}
