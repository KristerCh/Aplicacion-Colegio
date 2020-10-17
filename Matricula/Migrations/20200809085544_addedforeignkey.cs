using Microsoft.EntityFrameworkCore.Migrations;

namespace Matricula.Migrations
{
    public partial class addedforeignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "Estudiantes",
                newName: "Estudiantes",
                newSchema: "dbo");

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                schema: "dbo",
                table: "Estudiantes",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CursoId",
                schema: "dbo",
                table: "Estudiantes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CursoId",
                schema: "dbo",
                table: "Estudiantes");

            migrationBuilder.RenameTable(
                name: "Estudiantes",
                schema: "dbo",
                newName: "Estudiantes");

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "Estudiantes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);
        }
    }
}
