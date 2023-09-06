using Escola.Models;
using Escola.Models.ViewModels;

namespace Escola.Repositories.Contracts
{
    public interface ITurmaRepository : IRepositoryBase<Turma>
    {
        void AddTurmaMateriaProfessor(MateriaTurmaProfessorVM vm);
        void AddUserNaTurma(AddUserTurmaVM vm);
        TurmaUser GetTurmaDoUser(int turmaId, string userId);
        void RemoverUserDaTurma(int turmaId, string userId);
    }
}
