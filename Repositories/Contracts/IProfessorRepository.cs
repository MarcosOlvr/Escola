using Escola.Models;
using Escola.Models.ViewModels;

namespace Escola.Repositories.Contracts
{
    public interface IProfessorRepository
    {
        List<Turma> GetTurmas(string userName);
        List<ApplicationUser> GetAlunosNaTurma(int turmaId);
        ApplicationUser GetAluno(string alunoId);
        NotasDoAlunoVM GetAlunoNota(string alunoId);
    }
}
