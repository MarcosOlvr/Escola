namespace Escola.Models.ViewModels
{
    public class NotasDoAlunoVM
    {
        public ApplicationUser Aluno { get; set; }
        public List<Nota> Portugues { get; set; }
        public List<Nota> Matematica { get; set; }
        public List<Nota> Historia { get; set; }
        public List<Nota> Geografia { get; set; }
        public List<Nota> Ciencias { get; set; }
    }
}
