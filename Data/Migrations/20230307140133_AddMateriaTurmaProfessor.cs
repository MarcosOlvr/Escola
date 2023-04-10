using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Escola.Data.Migrations
{
    public partial class AddMateriaTurmaProfessor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MateriaTurmaProfessores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Professor = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MateriaFK = table.Column<int>(type: "int", nullable: false),
                    TurmaFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MateriaTurmaProfessores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MateriaTurmaProfessores_Materias_MateriaFK",
                        column: x => x.MateriaFK,
                        principalTable: "Materias",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MateriaTurmaProfessores_Turmas_TurmaFK",
                        column: x => x.TurmaFK,
                        principalTable: "Turmas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MateriaTurmaProfessores_Users_Professor",
                        column: x => x.Professor,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MateriaTurmaProfessores_MateriaFK",
                table: "MateriaTurmaProfessores",
                column: "MateriaFK");

            migrationBuilder.CreateIndex(
                name: "IX_MateriaTurmaProfessores_Professor",
                table: "MateriaTurmaProfessores",
                column: "Professor");

            migrationBuilder.CreateIndex(
                name: "IX_MateriaTurmaProfessores_TurmaFK",
                table: "MateriaTurmaProfessores",
                column: "TurmaFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MateriaTurmaProfessores");
        }
    }
}
