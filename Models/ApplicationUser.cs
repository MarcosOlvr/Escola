using Microsoft.AspNetCore.Identity;

namespace Escola.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
