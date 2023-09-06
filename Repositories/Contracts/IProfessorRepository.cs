using Escola.Models;
using Escola.Models.ViewModels;

namespace Escola.Repositories.Contracts
{
    public interface IProfessorRepository
    {
        List<Turma> GetTurmas(string userName);
        TurmaEAlunos UsuariosNaTurma(int turmaId);
        List<Materia> MateriasDoProfessorNaTurma(string userName, int turmaId);
    }
}
