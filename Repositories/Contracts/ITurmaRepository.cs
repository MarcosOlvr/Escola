using Escola.Models;
using Escola.Models.ViewModels;

namespace Escola.Repositories.Contracts
{
    public interface ITurmaRepository : IRepositoryBase<Turma>
    {
        void AddUserTurma(AddUserTurmaVM vm);
        TurmaUser GetTurmaUser(int turmaId, string userId);
        void RemoverUserTurma(int turmaId, string userId);
    }
}
