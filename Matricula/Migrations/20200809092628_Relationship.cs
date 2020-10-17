using Microsoft.EntityFrameworkCore.Migrations;

namespace Matricula.Migrations
{
    public partial class Relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_CursoId",
                schema: "dbo",
                table: "Estudiantes",
                column: "CursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiantes_Cursos_CursoId",
                schema: "dbo",
                table: "Estudiantes",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estudiantes_Cursos_CursoId",
                schema: "dbo",
                table: "Estudiantes");

            migrationBuilder.DropIndex(
                name: "IX_Estudiantes_CursoId",
                schema: "dbo",
                table: "Estudiantes");
        }
    }
}
