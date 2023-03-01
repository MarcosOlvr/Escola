using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Escola.Data.Migrations
{
    public partial class AddDatasNasNotas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AtualizadoEm",
                table: "Notas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CriadoEm",
                table: "Notas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TurmaFK",
                table: "Notas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Notas_TurmaFK",
                table: "Notas",
                column: "TurmaFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Turmas_TurmaFK",
                table: "Notas",
                column: "TurmaFK",
                principalTable: "Turmas",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notas_Turmas_TurmaFK",
                table: "Notas");

            migrationBuilder.DropIndex(
                name: "IX_Notas_TurmaFK",
                table: "Notas");

            migrationBuilder.DropColumn(
                name: "AtualizadoEm",
                table: "Notas");

            migrationBuilder.DropColumn(
                name: "CriadoEm",
                table: "Notas");

            migrationBuilder.DropColumn(
                name: "TurmaFK",
                table: "Notas");
        }
    }
}
