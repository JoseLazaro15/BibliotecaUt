using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticaBiblioteca.Migrations
{
    /// <inheritdoc />
    public partial class dbonline : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AUTOR",
                columns: table => new
                {
                    IdAutor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AUTOR__DD33B031C3D9EF54", x => x.IdAutor);
                });

            migrationBuilder.CreateTable(
                name: "CATEGORIA",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CATEGORI__A3C02A105B6E3261", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "EDITORIAL",
                columns: table => new
                {
                    IdEditorial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__EDITORIA__EF8386718274EAAC", x => x.IdEditorial);
                });

            migrationBuilder.CreateTable(
                name: "ESTADO_PRESTAMO",
                columns: table => new
                {
                    IdEstadoPrestamo = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ESTADO_P__BCB875495C6FBE78", x => x.IdEstadoPrestamo);
                });

            migrationBuilder.CreateTable(
                name: "TIPO_PERSONA",
                columns: table => new
                {
                    IdTipoPersona = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TIPO_PER__79FCAFBF2A1A27B3", x => x.IdTipoPersona);
                });

            migrationBuilder.CreateTable(
                name: "LIBRO",
                columns: table => new
                {
                    IdLibro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    RutaPortada = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    NombrePortada = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    IdAutor = table.Column<int>(type: "int", nullable: true),
                    IdCategoria = table.Column<int>(type: "int", nullable: true),
                    IdEditorial = table.Column<int>(type: "int", nullable: true),
                    Ubicacion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Ejemplares = table.Column<int>(type: "int", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LIBRO__3E0B49ADCC54BA9D", x => x.IdLibro);
                    table.ForeignKey(
                        name: "FK__LIBRO__IdAutor__300424B4",
                        column: x => x.IdAutor,
                        principalTable: "AUTOR",
                        principalColumn: "IdAutor");
                    table.ForeignKey(
                        name: "FK__LIBRO__IdCategor__30F848ED",
                        column: x => x.IdCategoria,
                        principalTable: "CATEGORIA",
                        principalColumn: "IdCategoria");
                    table.ForeignKey(
                        name: "FK__LIBRO__IdEditori__31EC6D26",
                        column: x => x.IdEditorial,
                        principalTable: "EDITORIAL",
                        principalColumn: "IdEditorial");
                });

            migrationBuilder.CreateTable(
                name: "PERSONA",
                columns: table => new
                {
                    IdPersona = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Apellido = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Correo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Clave = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Codigo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    IdTipoPersona = table.Column<int>(type: "int", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PERSONA__2EC8D2AC62B0AE6D", x => x.IdPersona);
                    table.ForeignKey(
                        name: "FK__PERSONA__IdTipoP__3A81B327",
                        column: x => x.IdTipoPersona,
                        principalTable: "TIPO_PERSONA",
                        principalColumn: "IdTipoPersona");
                });

            migrationBuilder.CreateTable(
                name: "PRESTAMO",
                columns: table => new
                {
                    IdPrestamo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEstadoPrestamo = table.Column<int>(type: "int", nullable: true),
                    IdPersona = table.Column<int>(type: "int", nullable: true),
                    IdLibro = table.Column<int>(type: "int", nullable: true),
                    FechaDevolucion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaConfirmacionDevolucion = table.Column<DateTime>(type: "datetime", nullable: true),
                    EstadoEntregado = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    EstadoRecibido = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PRESTAMO__6FF194C074B4C76C", x => x.IdPrestamo);
                    table.ForeignKey(
                        name: "FK__PRESTAMO__IdEsta__4316F928",
                        column: x => x.IdEstadoPrestamo,
                        principalTable: "ESTADO_PRESTAMO",
                        principalColumn: "IdEstadoPrestamo");
                    table.ForeignKey(
                        name: "FK__PRESTAMO__IdLibr__44FF419A",
                        column: x => x.IdLibro,
                        principalTable: "LIBRO",
                        principalColumn: "IdLibro");
                    table.ForeignKey(
                        name: "FK__PRESTAMO__IdPers__440B1D61",
                        column: x => x.IdPersona,
                        principalTable: "PERSONA",
                        principalColumn: "IdPersona");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LIBRO_IdAutor",
                table: "LIBRO",
                column: "IdAutor");

            migrationBuilder.CreateIndex(
                name: "IX_LIBRO_IdCategoria",
                table: "LIBRO",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_LIBRO_IdEditorial",
                table: "LIBRO",
                column: "IdEditorial");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONA_IdTipoPersona",
                table: "PERSONA",
                column: "IdTipoPersona");

            migrationBuilder.CreateIndex(
                name: "IX_PRESTAMO_IdEstadoPrestamo",
                table: "PRESTAMO",
                column: "IdEstadoPrestamo");

            migrationBuilder.CreateIndex(
                name: "IX_PRESTAMO_IdLibro",
                table: "PRESTAMO",
                column: "IdLibro");

            migrationBuilder.CreateIndex(
                name: "IX_PRESTAMO_IdPersona",
                table: "PRESTAMO",
                column: "IdPersona");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRESTAMO");

            migrationBuilder.DropTable(
                name: "ESTADO_PRESTAMO");

            migrationBuilder.DropTable(
                name: "LIBRO");

            migrationBuilder.DropTable(
                name: "PERSONA");

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
