using Escola.Data;
using Escola.Models;
using Escola.Models.ViewModels;
using Escola.Repositories.Contracts;

namespace Escola.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly ApplicationDbContext _db;

        public AlunoRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public Turma TurmaById(string alunoId)
        {
            try
            {
                var turmaDoAluno = _db.TurmaUser.FirstOrDefault(x => x.UserFK == alunoId);
                var turma = _db.Turmas.FirstOrDefault(x => x.Id == turmaDoAluno.TurmaFK);

                return turma;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Turma TurmaByUsername(string userName)
        {
            try
            {
                var aluno = _db.Users.FirstOrDefault(u => u.UserName == userName);

                var turmaDoAluno = _db.TurmaUser.FirstOrDefault(x => x.UserFK == aluno.Id);

                var turma = _db.Turmas.FirstOrDefault(x => x.Id == turmaDoAluno.TurmaFK);

                return turma;
            }
            catch (Exception ex)
            { 
                throw new Exception(ex.Message); 
            }
        }
    }
}
