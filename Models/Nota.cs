namespace Escola.Models
{
    public class Nota
    {
        public int Id { get; set; }
        public float Valor { get; set; }
        public int Faltas { get; set; }
        public int MateriaFK { get; set; }
        public int BimestreFK { get; set; }
        public string AlunoFK { get; set; }
        public string ProfessorFK { get; set; }
    }
}
