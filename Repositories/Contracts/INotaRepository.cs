using Escola.Models.ViewModels;

namespace Escola.Repositories.Contracts
{
    public interface INotaRepository
    {
        void AddNota(AddNotaVM vm);
        void UpdateNota(AddNotaVM vm);
        bool DeleteNota(int id);
        NotasDoAlunoVM GetNotasDoAluno(string alunoId, int turmaId);
        NotasDoAlunoVM GetNotasAddByProf(string alunoId, string profUserName);
        AddNotaVM GetNota(int notaId);
    }
}
