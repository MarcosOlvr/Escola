namespace Escola.Models.ViewModels
{
    public class AddNotaVM
    {
        public int Nota { get; set; }
        public int Faltas { get; set; }
        public int MateriaFK { get; set; }
        public int TurmaFK { get; set; }
        public int BimestreFK { get; set; }
        public string AlunoFK { get; set; }
        public string ProfessorFK { get; set; }
        public List<Materia> MateriasProfessor { get; set; }
    }
}
