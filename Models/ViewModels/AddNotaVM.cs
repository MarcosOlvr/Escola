namespace Escola.Models.ViewModels
{
    public class AddNotaVM
    {
        public ApplicationUser Aluno { get; set; }
        public int Nota { get; set; }
        public int Faltas { get; set; }
        public int MateriaFK { get; set; }
        public int TurmaFK { get; set; }
        public int AlunoFK { get; set; }
        public int ProfessorFK { get; set; }
        public List<int> MateriasProfessor { get; set; }
    }
}
