namespace Escola.Models.ViewModels
{
    public class IndexDashboardVM
    {
        public int QtyProfessores { get; set; }
        public int QtyAlunos { get; set; }
        public int QtyTurmas { get; set; }
        public List<Nota> UltimasNotas { get; set; }
        public List<ApplicationUser> AlunosNota { get; set; }
        public List<Materia> Materias { get; set; }
    }
}
