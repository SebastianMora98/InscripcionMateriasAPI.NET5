using Microsoft.EntityFrameworkCore.Migrations;

namespace Prueba_Conocimiento_Backend.Migrations
{
    public partial class v202 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "fechaActualizacion",
                table: "Alumno_Materias",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fechaActualizacion",
                table: "Alumno_Materias");
        }
    }
}
