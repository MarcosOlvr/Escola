using Escola.Models;
using Escola.Models.ViewModels;

namespace Escola.Repositories.Contracts
{
    public interface IProfessorRepository
    {
        ApplicationUser GetProfessor(string userName);
        List<Turma> GetTurmas(string userName);
        TurmaEAlunos GetUsuariosNaTurma(int turmaId);
        ApplicationUser GetAluno(string alunoId);
        NotasDoAlunoVM GetAlunoNota(string alunoId);
        List<Materia> GetMateriasProfessor(string userName, int turmaId);
    }
}
