using Escola.Models;
using Escola.Models.ViewModels;

namespace Escola.Repositories.Contracts
{
    public interface INotaRepository : IRepositoryBase<Nota>
    {
        NotasDoAlunoVM GetNotasDoAluno(string alunoId, int turmaId);
        NotasDoAlunoVM GetNotasAddByProf(string alunoId, string profUserName);
    }
}
