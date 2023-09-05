using Escola.Models;

namespace Escola.Repositories.Contracts
{
    public interface IMateriaRepository : IRepositoryBase<Materia>
    {
        List<Turma> TurmasComMateria(int materiaId);

    }
}
