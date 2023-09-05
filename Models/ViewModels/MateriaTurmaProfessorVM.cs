namespace Escola.Models.ViewModels
{
    public class MateriaTurmaProfessorVM
    {
        public List<Materia> Materias { get; set; }
        public List<ApplicationUser> UserList { get; set; }
        public string ProfessorId { get; set; }
        public int TurmaId { get; set; }
        public int MateriaId { get; set; }  
    }
}
