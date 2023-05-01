using Escola.Models;

namespace Escola.Repositories.Contracts
{
    public interface IDashboardRepository
    {
        List<Nota> GetUltimasNotas();
        List<Materia> GetMaterias();
        List<ApplicationUser> GetAlunosNota();
    }
}
