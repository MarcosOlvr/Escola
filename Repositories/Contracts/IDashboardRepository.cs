using Escola.Models;
using Escola.Models.ViewModels;

namespace Escola.Repositories.Contracts
{
    public interface IDashboardRepository
    {
        List<Nota> UltimasNotas();
        List<Materia> GetMaterias();
        List<ApplicationUser> NotasDoAluno();
        List<TurmasDashboardVM> GetTurmas();
        int QtyAlunos();
        int QtyProfessores();
        int QtyTurmas();
        int QtyUsuarios();
        List<ApplicationUser> GetProfessores(int turmaId);
        List<ApplicationUser> AlunosSemTurma();
        ApplicationUser GetUser(string userId);
        List<ApplicationUser> GetUsers();
        void UpdateUser(UserDTO dto);
        void DeleteUser(string userId);
    }
}
