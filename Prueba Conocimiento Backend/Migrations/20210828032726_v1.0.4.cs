using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Prueba_Conocimiento_Backend.Migrations
{
    public partial class v104 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "fechaCreacion",
                table: "Alumno_Materia",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fechaCreacion",
                table: "Alumno_Materia");
        }
    }
}
