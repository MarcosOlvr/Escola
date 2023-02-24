using Escola.Data;
using Escola.Models;
using Escola.Models.ViewModels;
using Escola.Repositories.Contracts;
using System;

namespace Escola.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly ApplicationDbContext _db;

        public ProfessorRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public ApplicationUser GetAluno(string alunoId)
        {
            var aluno = _db.Users.Find(alunoId);

            return aluno;
        }

        public NotasDoAlunoVM GetAlunoNota(string alunoId)
        {
            var aluno = _db.Users.Find(alunoId);

            var portugues = _db.Notas.Where(x => x.AlunoFK == alunoId && x.MateriaFK == 2).ToList();
            var matematica = _db.Notas.Where(x => x.AlunoFK == alunoId && x.MateriaFK == 1).ToList();
            var historia = _db.Notas.Where(x => x.AlunoFK == alunoId && x.MateriaFK == 3).ToList();
            var geografia = _db.Notas.Where(x => x.AlunoFK == alunoId && x.MateriaFK == 4).ToList();
            var ciencias = _db.Notas.Where(x => x.AlunoFK == alunoId && x.MateriaFK == 5).ToList();

            var notasDoAluno = new NotasDoAlunoVM();

            notasDoAluno.Aluno = aluno;
            notasDoAluno.Portugues = portugues;
            notasDoAluno.Matematica = matematica;
            notasDoAluno.Historia = historia;
            notasDoAluno.Geografia = geografia;
            notasDoAluno.Ciencias = ciencias;

            return notasDoAluno;
        }

        public TurmaEAlunos GetUsuariosNaTurma(int turmaId)
        {
            var turma = _db.Turmas.Find(turmaId);

            var turmaListadaComAlunos = _db.TurmaUser.Where(x => x.TurmaFK == turmaId).ToList();

            List<ApplicationUser> alunosNaTurma = new List<ApplicationUser>();
            List<ApplicationUser> professoresNaTurma = new List<ApplicationUser>();

            foreach (var obj in turmaListadaComAlunos)
            {
                var aluno = _db.Users.Find(obj.UserFK);

                var isInRole = _db.UserRoles.FirstOrDefault(x => x.UserId == aluno.Id);

                if (isInRole.UserId == aluno.Id && isInRole.RoleId == "3") // Role 3 é a role de alunos
                {
                    alunosNaTurma.Add(aluno);
                }
            }

            foreach (var obj in turmaListadaComAlunos)
            {
                var professor = _db.Users.Find(obj.UserFK);
                var isInRole = _db.UserRoles.FirstOrDefault(x => x.UserId == professor.Id);

                if (isInRole.UserId == professor.Id && isInRole.RoleId == "2")
                {
                    professoresNaTurma.Add(professor);
                }
            }

            var turmaEAlunos = new TurmaEAlunos();

            turmaEAlunos.Turma = turma;
            turmaEAlunos.Alunos = alunosNaTurma;
            turmaEAlunos.Professores = professoresNaTurma;

            return turmaEAlunos;
        }

        public List<Turma> GetTurmas(string userName)
        {
            ApplicationUser professor = _db.Users.FirstOrDefault(x => x.UserName == userName);
            var turmasDoUser = _db.TurmaUser.Where(x => x.UserFK == professor.Id).ToList();

            List<Turma> turmas = new List<Turma>();

            foreach (var obj in turmasDoUser)
            {
                var turmaSelecionada = _db.Turmas.Find(obj.TurmaFK);

                turmas.Add(turmaSelecionada);
            };

            return turmas;
        }
    }
}
