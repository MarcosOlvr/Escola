using Escola.Models;
using Escola.Models.ViewModels;

namespace Escola.Repositories.Contracts
{
    public interface IMateriaRepository : IRepositoryBase<Materia>
    {
        List<Turma> TurmasComMateria(int materiaId);
    }
}
