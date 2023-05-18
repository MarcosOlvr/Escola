using Escola.Models;
using Escola.Models.ViewModels;

namespace Escola.Repositories.Contracts
{
    public interface IProfessorRepository
    {
        List<Turma> GetTurmas(string userName);
        TurmaEAlunos GetUsuariosNaTurma(int turmaId);
        List<Materia> GetMateriasProfessor(string userName, int turmaId);
    }
}
