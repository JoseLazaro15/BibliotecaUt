using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticaBiblioteca.Migrations
{
    /// <inheritdoc />
    public partial class BibliotecaUt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {






        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AsignacionRoles");

            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "PRESTAMO");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "ESTADO_PRESTAMO");

            migrationBuilder.DropTable(
                name: "LIBRO");

            migrationBuilder.DropTable(
                name: "PERSONA");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "AUTOR");

            migrationBuilder.DropTable(
                name: "CATEGORIA");

            migrationBuilder.DropTable(
                name: "EDITORIAL");

            migrationBuilder.DropTable(
                name: "TIPO_PERSONA");
        }
    }
}
