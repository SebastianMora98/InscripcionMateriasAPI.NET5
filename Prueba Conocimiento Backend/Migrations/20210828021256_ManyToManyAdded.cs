using Microsoft.EntityFrameworkCore.Migrations;

namespace Prueba_Conocimiento_Backend.Migrations
{
    public partial class ManyToManyAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inscripcion_Alumno_AlumnoId",
                table: "Inscripcion");

            migrationBuilder.DropForeignKey(
                name: "FK_Inscripcion_Materia_MateriaId",
                table: "Inscripcion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Materia",
                table: "Materia");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inscripcion",
                table: "Inscripcion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alumno",
                table: "Alumno");

            migrationBuilder.RenameTable(
                name: "Materia",
                newName: "Materias");

            migrationBuilder.RenameTable(
                name: "Inscripcion",
                newName: "Inscripciones");

            migrationBuilder.RenameTable(
                name: "Alumno",
                newName: "Alumnos");

            migrationBuilder.RenameIndex(
                name: "IX_Inscripcion_MateriaId",
                table: "Inscripciones",
                newName: "IX_Inscripciones_MateriaId");

            migrationBuilder.RenameIndex(
                name: "IX_Inscripcion_AlumnoId",
                table: "Inscripciones",
                newName: "IX_Inscripciones_AlumnoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Materias",
                table: "Materias",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inscripciones",
                table: "Inscripciones",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alumnos",
                table: "Alumnos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inscripciones_Alumnos_AlumnoId",
                table: "Inscripciones",
                column: "AlumnoId",
                principalTable: "Alumnos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inscripciones_Materias_MateriaId",
                table: "Inscripciones",
                column: "MateriaId",
                principalTable: "Materias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inscripciones_Alumnos_AlumnoId",
                table: "Inscripciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Inscripciones_Materias_MateriaId",
                table: "Inscripciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Materias",
                table: "Materias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inscripciones",
                table: "Inscripciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alumnos",
                table: "Alumnos");

            migrationBuilder.RenameTable(
                name: "Materias",
                newName: "Materia");

            migrationBuilder.RenameTable(
                name: "Inscripciones",
                newName: "Inscripcion");

            migrationBuilder.RenameTable(
                name: "Alumnos",
                newName: "Alumno");

            migrationBuilder.RenameIndex(
                name: "IX_Inscripciones_MateriaId",
                table: "Inscripcion",
                newName: "IX_Inscripcion_MateriaId");

            migrationBuilder.RenameIndex(
                name: "IX_Inscripciones_AlumnoId",
                table: "Inscripcion",
                newName: "IX_Inscripcion_AlumnoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Materia",
                table: "Materia",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inscripcion",
                table: "Inscripcion",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alumno",
                table: "Alumno",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inscripcion_Alumno_AlumnoId",
                table: "Inscripcion",
                column: "AlumnoId",
                principalTable: "Alumno",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inscripcion_Materia_MateriaId",
                table: "Inscripcion",
                column: "MateriaId",
                principalTable: "Materia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
