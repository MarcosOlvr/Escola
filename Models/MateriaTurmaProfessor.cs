namespace Escola.Models
{
    public class MateriaTurmaProfessor
    {
        public int Id { get; set; }
        public string Professor { get; set; }
        public int MateriaFK { get; set; }
        public int TurmaFK { get; set; }
    }
}
