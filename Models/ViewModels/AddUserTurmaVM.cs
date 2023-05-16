namespace Escola.Models.ViewModels
{
    public class AddUserTurmaVM
    {
        public List<ApplicationUser> UserList { get; set; }
        public string UserFK { get; set; }
        public int TurmaFK { get; set; }
    }
}
