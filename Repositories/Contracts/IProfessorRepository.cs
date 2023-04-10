using Escola.Models;
using Escola.Models.ViewModels;

namespace Escola.Repositories.Contracts
{
    public interface IProfessorRepository
    {
        List<Turma> GetTurmas(string userName);
        TurmaEAlunos GetUsuariosNaTurma(int turmaId);
        ApplicationUser GetAluno(string alunoId);
        NotasDoAlunoVM GetAlunoNota(string alunoId);
        List<int> GetMateriasProfessor(string userName, int turmaId);
    }
}
