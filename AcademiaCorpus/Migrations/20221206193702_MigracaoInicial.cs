using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace AcademiaCorpus.Migrations
{
    public partial class MigracaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeAluno = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataNascimentoAluno = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FotoAlunoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnderecoAluno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAluno = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.AlunoId);
                });

            migrationBuilder.CreateTable(
                name: "Treinos",
                columns: table => new
                {
                    TreinosId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GrupoMuscular = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Musculo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Series = table.Column<int>(type: "int", nullable: false),
                    DiaDaSemana = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AlunoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treinos", x => x.TreinosId);
                    table.ForeignKey(
                        name: "FK_Treinos_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "AlunoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Treinos_AlunoId",
                table: "Treinos",
                column: "AlunoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Treinos");

            migrationBuilder.DropTable(
                name: "Alunos");
        }
    }
}
