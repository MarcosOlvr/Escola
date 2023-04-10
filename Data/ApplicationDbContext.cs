using Escola.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
using System.Reflection.Emit;

namespace Escola.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Bimestre> Bimestres { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Nota> Notas { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<TurmaUser> TurmaUser { get; set; }
        public DbSet<MateriaTurmaProfessor> MateriaTurmaProfessores { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().ToTable("Users");

            builder.Entity<TurmaUser>()
                .HasOne<Turma>()
                .WithMany()
                .HasForeignKey(t => t.TurmaFK)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<TurmaUser>()
                .HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(t => t.UserFK)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Nota>()
                .HasOne<Materia>()
                .WithMany()
                .HasForeignKey(t => t.MateriaFK)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Nota>()
                .HasOne<Bimestre>()
                .WithMany()
                .HasForeignKey(t => t.BimestreFK)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Nota>()
                .HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(t => t.AlunoFK)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Nota>()
                .HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(t => t.ProfessorFK)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder.Entity<Nota>()
                .HasOne<Turma>()
                .WithMany()
                .HasForeignKey(t => t.TurmaFK)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder.Entity<MateriaTurmaProfessor>()
                .HasOne<Turma>()
                .WithMany()
                .HasForeignKey(t => t.TurmaFK)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder.Entity<MateriaTurmaProfessor>()
                .HasOne<Materia>()
                .WithMany()
                .HasForeignKey(t => t.MateriaFK)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder.Entity<MateriaTurmaProfessor>()
                .HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(t => t.Professor)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}