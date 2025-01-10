using System;
using System.Collections.Generic;
using FullStack.Models;
using Microsoft.EntityFrameworkCore;

namespace FullStack.Context;

public partial class CursoFullstackContext : DbContext
{
    public CursoFullstackContext()
    {
    }

    public CursoFullstackContext(DbContextOptions<CursoFullstackContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<Asignatura> Asignaturas { get; set; }

    public virtual DbSet<Calificacion> Calificacions { get; set; }

    public virtual DbSet<Matricula> Matriculas { get; set; }

    public virtual DbSet<Profesor> Profesors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-IG186QC;Database=curso_fullstack;User ID=curso_fullstack;Password=curso_fullstack;Trusted_Connection=False;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__alumno__3213E83F366A29A2");

            entity.ToTable("alumno");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Direccion)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Dni)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("dni");
            entity.Property(e => e.Edad).HasColumnName("edad");
            entity.Property(e => e.Email)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Asignatura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__asignatu__3213E83F14215935");

            entity.ToTable("asignatura");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Creditos).HasColumnName("creditos");
            entity.Property(e => e.Nombre)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Profesor)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("profesor");

            entity.HasOne(d => d.ProfesorNavigation).WithMany(p => p.Asignaturas)
                .HasForeignKey(d => d.Profesor)
                .HasConstraintName("FK__asignatur__profe__4E88ABD4");
        });

        modelBuilder.Entity<Calificacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__califica__3213E83F5F63FED2");

            entity.ToTable("calificacion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.MatriculaId).HasColumnName("matriculaId");
            entity.Property(e => e.Nota).HasColumnName("nota");
            entity.Property(e => e.Porcentaje).HasColumnName("porcentaje");

            entity.HasOne(d => d.Matricula).WithMany(p => p.Calificacions)
                .HasForeignKey(d => d.MatriculaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__calificac__matri__5535A963");
        });

        modelBuilder.Entity<Matricula>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__matricul__3213E83FBC989CFD");

            entity.ToTable("matricula");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AlumnoId).HasColumnName("alumnoId");
            entity.Property(e => e.AsignaturaId).HasColumnName("asignaturaId");

            entity.HasOne(d => d.Alumno).WithMany(p => p.Matriculas)
                .HasForeignKey(d => d.AlumnoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__matricula__alumn__5165187F");

            entity.HasOne(d => d.Asignatura).WithMany(p => p.Matriculas)
                .HasForeignKey(d => d.AsignaturaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__matricula__asign__52593CB8");
        });

        modelBuilder.Entity<Profesor>(entity =>
        {
            entity.HasKey(e => e.Usuario).HasName("PK__profesor__9AFF8FC72A80EA24");

            entity.ToTable("profesor");

            entity.Property(e => e.Usuario)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("usuario");
            entity.Property(e => e.Email)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Pass)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("pass");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
