using Escola.Models;
using Escola.Models.ViewModels;

namespace Escola.Repositories.Contracts
{
    public interface IDashboardRepository
    {
        List<Nota> GetUltimasNotas();
        List<Materia> GetMaterias();
        List<ApplicationUser> GetAlunosNota();
        List<TurmasDashboardVM> GetAllTurmas();
        int GetQtyAlunos();
        int GetQtyProfessores();
        int GetQtyTurmas();
    }
}
