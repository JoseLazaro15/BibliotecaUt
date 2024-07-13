﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PracticaBiblioteca.Models;

#nullable disable

namespace PracticaBiblioteca.Migrations
{
    [DbContext(typeof(BibliotecaContext))]
    [Migration("20240711051831_dbonline")]
    partial class dbonline
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PracticaBiblioteca.Models.Autor", b =>
                {
                    b.Property<int>("IdAutor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAutor"));

                    b.Property<string>("Descripcion")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool?>("Estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("FechaCreacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.HasKey("IdAutor")
                        .HasName("PK__AUTOR__DD33B031C3D9EF54");

                    b.ToTable("AUTOR");
                });

            modelBuilder.Entity("PracticaBiblioteca.Models.Categorium", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCategoria"));

                    b.Property<string>("Descripcion")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool?>("Estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("FechaCreacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.HasKey("IdCategoria")
                        .HasName("PK__CATEGORI__A3C02A105B6E3261");

                    b.ToTable("CATEGORIA");
                });

            modelBuilder.Entity("PracticaBiblioteca.Models.Editorial", b =>
                {
                    b.Property<int>("IdEditorial")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEditorial"));

                    b.Property<string>("Descripcion")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool?>("Estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("FechaCreacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.HasKey("IdEditorial")
                        .HasName("PK__EDITORIA__EF8386718274EAAC");

                    b.ToTable("EDITORIAL");
                });

            modelBuilder.Entity("PracticaBiblioteca.Models.EstadoPrestamo", b =>
                {
                    b.Property<int>("IdEstadoPrestamo")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool?>("Estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("FechaCreacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.HasKey("IdEstadoPrestamo")
                        .HasName("PK__ESTADO_P__BCB875495C6FBE78");

                    b.ToTable("ESTADO_PRESTAMO");
                });

            modelBuilder.Entity("PracticaBiblioteca.Models.Libro", b =>
                {
                    b.Property<int>("IdLibro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdLibro"));

                    b.Property<int?>("Ejemplares")
                        .HasColumnType("int");

                    b.Property<bool?>("Estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("FechaCreacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("IdAutor")
                        .HasColumnType("int");

                    b.Property<int?>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<int?>("IdEditorial")
                        .HasColumnType("int");

                    b.Property<string>("NombrePortada")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("RutaPortada")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Titulo")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Ubicacion")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdLibro")
                        .HasName("PK__LIBRO__3E0B49ADCC54BA9D");

                    b.HasIndex("IdAutor");

                    b.HasIndex("IdCategoria");

                    b.HasIndex("IdEditorial");

                    b.ToTable("LIBRO");
                });

            modelBuilder.Entity("PracticaBiblioteca.Models.Persona", b =>
                {
                    b.Property<int>("IdPersona")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPersona"));

                    b.Property<string>("Apellido")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Clave")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Codigo")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Correo")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool?>("Estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("FechaCreacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("IdTipoPersona")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdPersona")
                        .HasName("PK__PERSONA__2EC8D2AC62B0AE6D");

                    b.HasIndex("IdTipoPersona");

                    b.ToTable("PERSONA");
                });

            modelBuilder.Entity("PracticaBiblioteca.Models.Prestamo", b =>
                {
                    b.Property<int>("IdPrestamo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPrestamo"));

                    b.Property<bool?>("Estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("EstadoEntregado")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("EstadoRecibido")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("FechaConfirmacionDevolucion")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("FechaCreacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime?>("FechaDevolucion")
                        .HasColumnType("datetime");

                    b.Property<int?>("IdEstadoPrestamo")
                        .HasColumnType("int");

                    b.Property<int?>("IdLibro")
                        .HasColumnType("int");

                    b.Property<int?>("IdPersona")
                        .HasColumnType("int");

                    b.HasKey("IdPrestamo")
                        .HasName("PK__PRESTAMO__6FF194C074B4C76C");

                    b.HasIndex("IdEstadoPrestamo");

                    b.HasIndex("IdLibro");

                    b.HasIndex("IdPersona");

                    b.ToTable("PRESTAMO");
                });

            modelBuilder.Entity("PracticaBiblioteca.Models.TipoPersona", b =>
                {
                    b.Property<int>("IdTipoPersona")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool?>("Estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("FechaCreacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.HasKey("IdTipoPersona")
                        .HasName("PK__TIPO_PER__79FCAFBF2A1A27B3");

                    b.ToTable("TIPO_PERSONA");
                });

            modelBuilder.Entity("PracticaBiblioteca.Models.Libro", b =>
                {
                    b.HasOne("PracticaBiblioteca.Models.Autor", "IdAutorNavigation")
                        .WithMany("Libros")
                        .HasForeignKey("IdAutor")
                        .HasConstraintName("FK__LIBRO__IdAutor__300424B4");

                    b.HasOne("PracticaBiblioteca.Models.Categorium", "IdCategoriaNavigation")
                        .WithMany("Libros")
                        .HasForeignKey("IdCategoria")
                        .HasConstraintName("FK__LIBRO__IdCategor__30F848ED");

                    b.HasOne("PracticaBiblioteca.Models.Editorial", "IdEditorialNavigation")
                        .WithMany("Libros")
                        .HasForeignKey("IdEditorial")
                        .HasConstraintName("FK__LIBRO__IdEditori__31EC6D26");

                    b.Navigation("IdAutorNavigation");

                    b.Navigation("IdCategoriaNavigation");

                    b.Navigation("IdEditorialNavigation");
                });

            modelBuilder.Entity("PracticaBiblioteca.Models.Persona", b =>
                {
                    b.HasOne("PracticaBiblioteca.Models.TipoPersona", "IdTipoPersonaNavigation")
                        .WithMany("Personas")
                        .HasForeignKey("IdTipoPersona")
                        .HasConstraintName("FK__PERSONA__IdTipoP__3A81B327");

                    b.Navigation("IdTipoPersonaNavigation");
                });

            modelBuilder.Entity("PracticaBiblioteca.Models.Prestamo", b =>
                {
                    b.HasOne("PracticaBiblioteca.Models.EstadoPrestamo", "IdEstadoPrestamoNavigation")
                        .WithMany("Prestamos")
                        .HasForeignKey("IdEstadoPrestamo")
                        .HasConstraintName("FK__PRESTAMO__IdEsta__4316F928");

                    b.HasOne("PracticaBiblioteca.Models.Libro", "IdLibroNavigation")
                        .WithMany("Prestamos")
                        .HasForeignKey("IdLibro")
                        .HasConstraintName("FK__PRESTAMO__IdLibr__44FF419A");

                    b.HasOne("PracticaBiblioteca.Models.Persona", "IdPersonaNavigation")
                        .WithMany("Prestamos")
                        .HasForeignKey("IdPersona")
                        .HasConstraintName("FK__PRESTAMO__IdPers__440B1D61");

                    b.Navigation("IdEstadoPrestamoNavigation");

                    b.Navigation("IdLibroNavigation");

                    b.Navigation("IdPersonaNavigation");
                });

            modelBuilder.Entity("PracticaBiblioteca.Models.Autor", b =>
                {
                    b.Navigation("Libros");
                });

            modelBuilder.Entity("PracticaBiblioteca.Models.Categorium", b =>
                {
                    b.Navigation("Libros");
                });

            modelBuilder.Entity("PracticaBiblioteca.Models.Editorial", b =>
                {
                    b.Navigation("Libros");
                });

            modelBuilder.Entity("PracticaBiblioteca.Models.EstadoPrestamo", b =>
                {
                    b.Navigation("Prestamos");
                });

            modelBuilder.Entity("PracticaBiblioteca.Models.Libro", b =>
                {
                    b.Navigation("Prestamos");
                });

            modelBuilder.Entity("PracticaBiblioteca.Models.Persona", b =>
                {
                    b.Navigation("Prestamos");
                });

            modelBuilder.Entity("PracticaBiblioteca.Models.TipoPersona", b =>
                {
                    b.Navigation("Personas");
                });
#pragma warning restore 612, 618
        }
    }
}