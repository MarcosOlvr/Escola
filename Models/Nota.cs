namespace Escola.Models
{
    public class Nota
    {
        public int Id { get; set; }
        public float Valor { get; set; }
        public int Faltas { get; set; }
        public int MateriaFK { get; set; }
        public int BimestreFK { get; set; }
        public int TurmaFK { get; set; }
        public string AlunoFK { get; set; }
        public string ProfessorFK { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.Now;
        public DateTime AtualizadoEm { get; set; } = DateTime.Now;
    }
}
