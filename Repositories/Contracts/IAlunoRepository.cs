using Escola.Models;
using Escola.Models.ViewModels;

namespace Escola.Repositories.Contracts
{
    public interface IAlunoRepository
    {
        Turma TurmaByUsername(string userName);
        Turma TurmaById(string alunoId);
    }
}
