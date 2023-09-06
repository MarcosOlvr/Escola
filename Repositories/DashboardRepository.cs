using Escola.Data;
using Escola.Models;
using Escola.Models.ViewModels;
using Escola.Repositories.Contracts;

namespace Escola.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly ApplicationDbContext _db;

        public DashboardRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<ApplicationUser> AlunosSemTurma()
        {
            var alunosSemTurma = new List<ApplicationUser>();

            foreach (var userRole in _db.UserRoles)
            {
                foreach (var role in _db.Roles)
                {
                    if (role.Name == "Aluno" && userRole.RoleId == role.Id)
                    {
                        var verif = _db.TurmaUser.FirstOrDefault(x => x.UserFK == userRole.UserId);

                        if (verif == null)
                            alunosSemTurma.Add(_db.Users.FirstOrDefault(x=> x.Id == userRole.UserId));
                    }
                        
                }
            }

            return alunosSemTurma;
        }

        public List<ApplicationUser> GetProfessores()
        {
            var profs = new List<ApplicationUser>();

            foreach (var userRole in  _db.UserRoles)
            {
                foreach(var role in _db.Roles)
                {
                    if (role.Name == "Professor" && userRole.RoleId == role.Id)
                    {
                        profs.Add(_db.Users.Find(userRole.UserId));
                    }
                }
            }

            return profs;
        }

        public List<TurmasDashboardVM> GetTurmas()
        {
            List<TurmasDashboardVM> turmas = new List<TurmasDashboardVM>();
            
            foreach (var turma in _db.Turmas) 
            {
                TurmasDashboardVM vm = new TurmasDashboardVM();

                var tUserList = _db.TurmaUser.Where(x => x.TurmaFK == turma.Id).ToList();

                foreach (var tuser in tUserList)
                {
                    foreach (var role in _db.Roles) 
                    {
                        if (role.Name == "Aluno")
                        {
                            var qtyAlunos = _db.UserRoles.Where(x => x.UserId == tuser.UserFK && x.RoleId == role.Id).ToList();
                            vm.QtyAlunos += qtyAlunos.Count;
                        }
                        
                        if (role.Name == "Professor")
                        {
                            var qtyProf = _db.UserRoles.Where(x => x.UserId == tuser.UserFK && x.RoleId == role.Id).ToList();
                            vm.QtyProfessores += qtyProf.Count;
                        }
                    }
                }

                vm.Turma = turma;
                turmas.Add(vm);
            }

            return turmas;
        }

        public List<ApplicationUser> NotasDoAluno()
        {
            List<ApplicationUser> alunos = new List<ApplicationUser>();

            var ultimasNotas = UltimasNotas();

            foreach (var obj in ultimasNotas)
            {
                var aluno = _db.Users.FirstOrDefault(x => x.Id == obj.AlunoFK);

                if (!alunos.Contains(aluno))
                        alunos.Add(aluno);
            }

            return alunos;
        }

        public List<Materia> GetMaterias()
        {
            return _db.Materias.ToList().Take(5).ToList();
        }

        public int QtyAlunos()
        {
            List<ApplicationUser> users = _db.Users.ToList();
            var alunos = new List<ApplicationUser>();

            foreach (var u in users)
            {
                foreach (var role in _db.Roles)
                {
                    if (role.Name == "Aluno")
                    {
                        foreach (var userRole in _db.UserRoles)
                        {
                            if (userRole.UserId == u.Id && userRole.RoleId == role.Id)
                            {
                                alunos.Add(u);
                            }
                        }
                    }
                }
            }

            return alunos.Count;
        }

        public int QtyProfessores()
        {
            List<ApplicationUser> users = _db.Users.ToList();
            var professor = new List<ApplicationUser>();

            foreach (var u in users)
            {
                foreach (var role in _db.Roles)
                {
                    if (role.Name == "Professor")
                    {
                        foreach (var userRole in _db.UserRoles)
                        {
                            if (userRole.UserId == u.Id && userRole.RoleId == role.Id)
                            {
                                professor.Add(u);
                            }
                        }
                    }
                }
            }

            return professor.Count;
        }

        public int QtyTurmas()
        {
            return _db.Turmas.ToList().Count;
        }

        public List<Nota> UltimasNotas()
        {
            return _db.Notas.ToList().TakeLast(5).ToList();
        }

        public ApplicationUser GetUser(string userId)
        {
            return _db.Users.FirstOrDefault(x=> x.Id == userId || x.UserName == userId);
        }
    }
}
