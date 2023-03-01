using Escola.Models;
using Escola.Models.ViewModels;

namespace Escola.Repositories.Contracts
{
    public interface IAlunoRepository
    {
        Turma GetTurmaByUsername(string userName);
        NotasDoAlunoVM GetNotasDoAluno(string userName, int turmaId);
    }
}
