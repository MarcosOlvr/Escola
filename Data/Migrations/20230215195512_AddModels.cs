using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Escola.Data.Migrations
{
    public partial class AddModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bimestres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bimestres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Turmas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turmas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<float>(type: "real", nullable: false),
                    MateriaFK = table.Column<int>(type: "int", nullable: false),
                    BimestreFK = table.Column<int>(type: "int", nullable: false),
                    AlunoFK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProfessorFK = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notas_Bimestres_BimestreFK",
                        column: x => x.BimestreFK,
                        principalTable: "Bimestres",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notas_Materias_MateriaFK",
                        column: x => x.MateriaFK,
                        principalTable: "Materias",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notas_Users_AlunoFK",
                        column: x => x.AlunoFK,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notas_Users_ProfessorFK",
                        column: x => x.ProfessorFK,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TurmaUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserFK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TurmaFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurmaUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TurmaUser_Turmas_TurmaFK",
                        column: x => x.TurmaFK,
                        principalTable: "Turmas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TurmaUser_Users_UserFK",
                        column: x => x.UserFK,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notas_AlunoFK",
                table: "Notas",
                column: "AlunoFK");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_BimestreFK",
                table: "Notas",
                column: "BimestreFK");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_MateriaFK",
                table: "Notas",
                column: "MateriaFK");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_ProfessorFK",
                table: "Notas",
                column: "ProfessorFK");

            migrationBuilder.CreateIndex(
                name: "IX_TurmaUser_TurmaFK",
                table: "TurmaUser",
                column: "TurmaFK");

            migrationBuilder.CreateIndex(
                name: "IX_TurmaUser_UserFK",
                table: "TurmaUser",
                column: "UserFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notas");

            migrationBuilder.DropTable(
                name: "TurmaUser");

            migrationBuilder.DropTable(
                name: "Bimestres");

            migrationBuilder.DropTable(
                name: "Materias");

            migrationBuilder.DropTable(
                name: "Turmas");
        }
    }
}
