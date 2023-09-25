using Escola.Models;
using Escola.Models.ViewModels;

namespace Escola.Repositories.Contracts
{
    public interface INotaRepository : IRepositoryBase<Nota>
    {
        NotasDoAlunoVM NotasDoAluno(string alunoId, int turmaId);
        NotasDoAlunoVM NotasAddPeloProfessor(string alunoId, string profUserName, int turmaId);
    }
}
