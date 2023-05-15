namespace Escola.Models.ViewModels
{
    public class AddProfTurmaVM
    {
        public List<ApplicationUser> Professores { get; set; }
        public string ProfessorFK { get; set; }
        public int TurmaFK { get; set; }
    }
}
