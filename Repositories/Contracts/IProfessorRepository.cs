using Escola.Models;

namespace Escola.Repositories.Contracts
{
    public interface IProfessorRepository
    {
        List<Turma> GetTurmas(string userName);
        List<ApplicationUser> GetAlunosNaTurma(int turmaId);
    }
}
