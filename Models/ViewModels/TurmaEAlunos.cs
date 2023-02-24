namespace Escola.Models.ViewModels
{
    public class TurmaEAlunos
    {
        public List<ApplicationUser> Alunos { get; set; }
        public List<ApplicationUser> Professores { get; set; }
        public Turma Turma { get; set; }
    }
}
