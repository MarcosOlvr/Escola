using Escola.Data;
using Escola.Models;
using Escola.Models.ViewModels;
using Escola.Repositories.Contracts;

namespace Escola.Repositories
{
    public class NotaRepository : INotaRepository
    {
        private readonly ApplicationDbContext _db;

        public NotaRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void AddNota(AddNotaVM vm)
        {
            Nota nota = new Nota();

            nota.Valor = vm.Nota;
            nota.Faltas = vm.Faltas;
            nota.AlunoFK = vm.AlunoFK;
            nota.ProfessorFK = vm.ProfessorFK;
            nota.MateriaFK = vm.MateriaFK;
            nota.TurmaFK = vm.TurmaFK;
            nota.BimestreFK = vm.BimestreFK;
            

            _db.Notas.Add(nota);
            _db.SaveChanges();
        }

        public void DeleteNota(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateNota(AddNotaVM vm)
        {
            throw new NotImplementedException();
        }
    }
}
