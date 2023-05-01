namespace Escola.Models.ViewModels
{
    public class IndexDashboardVM
    {
        public List<Nota> UltimasNotas { get; set; }
        public List<ApplicationUser> AlunosNota { get; set; }
        public List<Materia> Materias { get; set; }
    }
}
