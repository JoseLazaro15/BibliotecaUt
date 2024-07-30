using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PracticaBiblioteca.Models;

public partial class BibliotecaContext : DbContext
{
    public BibliotecaContext()
    {
    }

    public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autor> Autors { get; set; }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Editorial> Editorials { get; set; }

    public virtual DbSet<EstadoPrestamo> EstadoPrestamos { get; set; }

    public virtual DbSet<Libro> Libros { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Prestamo> Prestamos { get; set; }

    public virtual DbSet<TipoPersona> TipoPersonas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("workstation id=Bibliotecaut.mssql.somee.com;packet size=4096;user id=gomix08_SQLLogin_1;pwd=j2z5qrpbkc;data source=Bibliotecaut.mssql.somee.com;persist security info=False;initial catalog=Bibliotecaut;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autor>(entity =>
        {
            entity.HasKey(e => e.IdAutor).HasName("PK__AUTOR__DD33B031C3D9EF54");

            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__CATEGORI__A3C02A105B6E3261");

            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Editorial>(entity =>
        {
            entity.HasKey(e => e.IdEditorial).HasName("PK__EDITORIA__EF8386718274EAAC");

            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<EstadoPrestamo>(entity =>
        {
            entity.HasKey(e => e.IdEstadoPrestamo).HasName("PK__ESTADO_P__BCB875495C6FBE78");

            entity.Property(e => e.IdEstadoPrestamo).ValueGeneratedNever();
            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.IdLibro).HasName("PK__LIBRO__3E0B49ADCC54BA9D");

            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdAutorNavigation).WithMany(p => p.Libros).HasConstraintName("FK__LIBRO__IdAutor__300424B4");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Libros).HasConstraintName("FK__LIBRO__IdCategor__30F848ED");

            entity.HasOne(d => d.IdEditorialNavigation).WithMany(p => p.Libros).HasConstraintName("FK__LIBRO__IdEditori__31EC6D26");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.IdPersona).HasName("PK__PERSONA__2EC8D2AC62B0AE6D");

            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdTipoPersonaNavigation).WithMany(p => p.Personas).HasConstraintName("FK__PERSONA__IdTipoP__3A81B327");
        });

        modelBuilder.Entity<Prestamo>(entity =>
        {
            entity.HasKey(e => e.IdPrestamo).HasName("PK__PRESTAMO__6FF194C074B4C76C");

            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdEstadoPrestamoNavigation).WithMany(p => p.Prestamos).HasConstraintName("FK__PRESTAMO__IdEsta__4316F928");

            entity.HasOne(d => d.IdLibroNavigation).WithMany(p => p.Prestamos).HasConstraintName("FK__PRESTAMO__IdLibr__44FF419A");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Prestamos).HasConstraintName("FK__PRESTAMO__IdPers__440B1D61");
        });

        modelBuilder.Entity<TipoPersona>(entity =>
        {
            entity.HasKey(e => e.IdTipoPersona).HasName("PK__TIPO_PER__79FCAFBF2A1A27B3");

            entity.Property(e => e.IdTipoPersona).ValueGeneratedNever();
            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
