using Microsoft.EntityFrameworkCore.Migrations;

namespace Prueba_Conocimiento_Backend.Migrations
{
    public partial class v1010 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alumno_Materia_Alumnos_AlumnoId",
                table: "Alumno_Materia");

            migrationBuilder.DropForeignKey(
                name: "FK_Alumno_Materia_Materias_MateriaId",
                table: "Alumno_Materia");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alumno_Materia",
                table: "Alumno_Materia");

            migrationBuilder.RenameTable(
                name: "Alumno_Materia",
                newName: "Alumno_Materias");

            migrationBuilder.RenameIndex(
                name: "IX_Alumno_Materia_MateriaId",
                table: "Alumno_Materias",
                newName: "IX_Alumno_Materias_MateriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alumno_Materias",
                table: "Alumno_Materias",
                columns: new[] { "AlumnoId", "MateriaId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Alumno_Materias_Alumnos_AlumnoId",
                table: "Alumno_Materias",
                column: "AlumnoId",
                principalTable: "Alumnos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Alumno_Materias_Materias_MateriaId",
                table: "Alumno_Materias",
                column: "MateriaId",
                principalTable: "Materias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alumno_Materias_Alumnos_AlumnoId",
                table: "Alumno_Materias");

            migrationBuilder.DropForeignKey(
                name: "FK_Alumno_Materias_Materias_MateriaId",
                table: "Alumno_Materias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alumno_Materias",
                table: "Alumno_Materias");

            migrationBuilder.RenameTable(
                name: "Alumno_Materias",
                newName: "Alumno_Materia");

            migrationBuilder.RenameIndex(
                name: "IX_Alumno_Materias_MateriaId",
                table: "Alumno_Materia",
                newName: "IX_Alumno_Materia_MateriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alumno_Materia",
                table: "Alumno_Materia",
                columns: new[] { "AlumnoId", "MateriaId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Alumno_Materia_Alumnos_AlumnoId",
                table: "Alumno_Materia",
                column: "AlumnoId",
                principalTable: "Alumnos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Alumno_Materia_Materias_MateriaId",
                table: "Alumno_Materia",
                column: "MateriaId",
                principalTable: "Materias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
