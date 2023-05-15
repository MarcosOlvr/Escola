using Escola.Models;
using Escola.Models.ViewModels;

namespace Escola.Repositories.Contracts
{
    public interface ITurmaRepository : IRepositoryBase<Turma>
    {
        void AddProfTurma(AddProfTurmaVM vm);
        void AddAlunoTurma();
    }
}
