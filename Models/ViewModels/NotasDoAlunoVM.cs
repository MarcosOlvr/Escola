namespace Escola.Models.ViewModels
{
    public class NotasDoAlunoVM
    {
        public ApplicationUser Aluno { get; set; }
        public List<List<Nota>> Notas { get; set; }
        public List<Materia> Materias { get; set; }
    }
}
