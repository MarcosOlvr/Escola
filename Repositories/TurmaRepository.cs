using Escola.Data;
using Escola.Models;
using Escola.Models.ViewModels;
using Escola.Repositories.Contracts;

namespace Escola.Repositories
{
    public class TurmaRepository : RepositoryBase<Turma>, ITurmaRepository
    {
        private readonly ApplicationDbContext _db;

        public TurmaRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public void AddAlunoTurma()
        {
            throw new NotImplementedException();
        }

        public void AddProfTurma(AddProfTurmaVM vm)
        {
            var model = new TurmaUser();

            model.TurmaFK = vm.TurmaFK;
            model.UserFK = vm.ProfessorFK;

            _db.TurmaUser.Add(model);
            _db.SaveChanges();
        }
    }
}
