using Escola.Models.ViewModels;

namespace Escola.Repositories.Contracts
{
    public interface INotaRepository : IRepositoryBase<AddNotaVM>
    {
        NotasDoAlunoVM GetNotasDoAluno(string alunoId, int turmaId);
        NotasDoAlunoVM GetNotasAddByProf(string alunoId, string profUserName);
    }
}
