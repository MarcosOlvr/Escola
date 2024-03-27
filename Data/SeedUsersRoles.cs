using Microsoft.AspNetCore.Identity;

namespace Escola.Data
{
    public class SeedUsersRoles
    {
        private readonly List<IdentityRole> _roles;
        private readonly List<IdentityUser> _users;
        private readonly List<IdentityUserRole<string>> _userRoles;
        public SeedUsersRoles()
        {
            _roles = GetRoles();
            _users = GetUsers();
            _userRoles = GetUserRoles(_users, _roles);
        }

        public List<IdentityRole> Roles { get { return _roles; } }
        public List<IdentityUser> Users { get { return _users; } }
        public List<IdentityUserRole<string>> UserRoles { get { return _userRoles; } }

        private List<IdentityRole> GetRoles()
        {

            // Seed Roles
            var adminRole = new IdentityRole("Admin");
            adminRole.NormalizedName = adminRole.Name!.ToUpper();

            var professorRole = new IdentityRole("Professor");
            professorRole.NormalizedName = professorRole.Name!.ToUpper();

            var alunoRole = new IdentityRole("Aluno");
            alunoRole.NormalizedName = alunoRole.Name!.ToUpper();

            List<IdentityRole> roles = new List<IdentityRole>() {
           adminRole,
           professorRole,
           alunoRole
        };

            return roles;
        }

        private List<IdentityUser> GetUsers()
        {

            string pwd = "P@ssword";
            var passwordHasher = new PasswordHasher<IdentityUser>();

            // Seed Users
            var adminUser = new IdentityUser
            {
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
                EmailConfirmed = true,
            };
            adminUser.NormalizedUserName = adminUser.UserName.ToUpper();
            adminUser.NormalizedEmail = adminUser.Email.ToUpper();
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, pwd);

            List<IdentityUser> users = new List<IdentityUser>() {
           adminUser
        };

            return users;
        }

        private List<IdentityUserRole<string>> GetUserRoles(List<IdentityUser> users, List<IdentityRole> roles)
        {
            // Seed UserRoles
            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();

            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[0].Id,
                RoleId = roles.First(q => q.Name == "Admin").Id
            });

            return userRoles;
        }
    }
}
