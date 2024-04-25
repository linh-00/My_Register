using System;
using System.Collections.Generic;
using Inc.MyRegister.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Inc.MyRegister.DAL.Contexts;

public partial class MyRegisterContext : DbContext
{
    public MyRegisterContext()
    {
    }

    public MyRegisterContext(DbContextOptions<MyRegisterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EMPRESA> EMPRESAs { get; set; }

    public virtual DbSet<FUNCIONARIO> FUNCIONARIOs { get; set; }

    public virtual DbSet<REGISTRO_PONTO> REGISTRO_PONTOs { get; set; }

    public virtual DbSet<USUARIO> USUARIOs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost, 1433; Initial Catalog=MyRegister; persist security info=True;user id=sa; password=P@0com0v0;TrustServerCertificate=True;MultipleActiveResultSets=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EMPRESA>(entity =>
        {
            entity.HasKey(e => e.ID_EMPRESA).HasName("PK__EMPRESA__E30DF09C7E41242E");

            entity.ToTable("EMPRESA");

            entity.Property(e => e.ID_EMPRESA).ValueGeneratedNever();
            entity.Property(e => e.CNPJ)
                .HasMaxLength(18)
                .IsUnicode(false);
            entity.Property(e => e.CONTATO_COPERATIVO)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.DOMINIO)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DS_NOME)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.EMAIL)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.ENDERECO)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FUNCIONARIO>(entity =>
        {
            entity.HasKey(e => e.ID_FUNCIONARIO).HasName("PK__FUNCIONA__1E0555247F6C746F");

            entity.ToTable("FUNCIONARIO");

            entity.Property(e => e.ID_FUNCIONARIO).ValueGeneratedNever();
            entity.Property(e => e.CARGO)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CONTATO_FUNCIONARIO)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.CPF)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.DS_NOME)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.EMAIL_CORPORATIVO)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.MATRICULA)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.SETOR)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.ID_EMPRESANavigation).WithMany(p => p.FUNCIONARIOs)
                .HasForeignKey(d => d.ID_EMPRESA)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ID_EMPRESA");
        });

        modelBuilder.Entity<REGISTRO_PONTO>(entity =>
        {
            entity.HasKey(e => e.ID_REGISTRO_PONTO).HasName("PK__REGISTRO__6733B2E95FC1A552");

            entity.ToTable("REGISTRO_PONTO");

            entity.Property(e => e.ID_REGISTRO_PONTO).ValueGeneratedNever();
            entity.Property(e => e.DT_PONTO).HasColumnType("datetime");
            entity.Property(e => e.TP_PONTO)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.ID_FUNCIONARIONavigation).WithMany(p => p.REGISTRO_PONTOs)
                .HasForeignKey(d => d.ID_FUNCIONARIO)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ID_FUNCIONARIO");
        });

        modelBuilder.Entity<USUARIO>(entity =>
        {
            entity.HasKey(e => e.ID_USUARIO).HasName("PK__USUARIO__91136B904621BA87");

            entity.ToTable("USUARIO");

            entity.Property(e => e.ID_USUARIO).ValueGeneratedNever();
            entity.Property(e => e.DS_EMAIL)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.DS_NOME)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.DS_SENHA)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.TP_CARGO)
                .HasMaxLength(80)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
