using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.Ekips.WebApi.Domains
{
    public partial class EkipsContext : DbContext
    {
        public EkipsContext()
        {
        }

        public EkipsContext(DbContextOptions<EkipsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cargo> Cargo { get; set; }
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<Funcionario> Funcionario { get; set; }
        public virtual DbSet<Permissao> Permissao { get; set; }
        public virtual DbSet<Usuariovinculado> Usuariovinculado { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress;Initial Catalog=T_Ekips;User Id=sa;Pwd=132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.HasKey(e => e.Idcargo);

                entity.ToTable("CARGO");

                entity.Property(e => e.Idcargo).HasColumnName("IDCARGO");

                entity.Property(e => e.Cargo1)
                    .IsRequired()
                    .HasColumnName("CARGO")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.Iddepartamento);

                entity.ToTable("DEPARTAMENTO");

                entity.Property(e => e.Iddepartamento).HasColumnName("IDDEPARTAMENTO");

                entity.Property(e => e.Departamento1)
                    .IsRequired()
                    .HasColumnName("DEPARTAMENTO")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.HasKey(e => e.Idfuncionario);

                entity.ToTable("FUNCIONARIO");

                entity.HasIndex(e => e.Cpf)
                    .HasName("UQ__FUNCIONA__C1F8973132D62A48")
                    .IsUnique();

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__FUNCIONA__E2AB1FF40D4B4D8B")
                    .IsUnique();

                entity.Property(e => e.Idfuncionario).HasColumnName("IDFUNCIONARIO");

                entity.Property(e => e.Cpf).HasColumnName("CPF");

                entity.Property(e => e.Datanascimento)
                    .HasColumnName("DATANASCIMENTO")
                    .HasColumnType("date");

                entity.Property(e => e.Idcargo).HasColumnName("IDCARGO");

                entity.Property(e => e.Iddepartamento).HasColumnName("IDDEPARTAMENTO");

                entity.Property(e => e.Idusuariovinculado).HasColumnName("IDUSUARIOVINCULADO");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Salario).HasColumnName("SALARIO");

                entity.HasOne(d => d.IdcargoNavigation)
                    .WithMany(p => p.Funcionario)
                    .HasForeignKey(d => d.Idcargo)
                    .HasConstraintName("FK__FUNCIONAR__IDCAR__5BE2A6F2");

                entity.HasOne(d => d.IddepartamentoNavigation)
                    .WithMany(p => p.Funcionario)
                    .HasForeignKey(d => d.Iddepartamento)
                    .HasConstraintName("FK__FUNCIONAR__IDDEP__5AEE82B9");

                entity.HasOne(d => d.IdusuariovinculadoNavigation)
                    .WithMany(p => p.Funcionario)
                    .HasForeignKey(d => d.Idusuariovinculado)
                    .HasConstraintName("FK__FUNCIONAR__IDUSU__5CD6CB2B");
            });

            modelBuilder.Entity<Permissao>(entity =>
            {
                entity.HasKey(e => e.Idpermissao);

                entity.ToTable("PERMISSAO");

                entity.Property(e => e.Idpermissao).HasColumnName("IDPERMISSAO");

                entity.Property(e => e.Permissao1)
                    .IsRequired()
                    .HasColumnName("PERMISSAO")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuariovinculado>(entity =>
            {
                entity.HasKey(e => e.Idusuariovinculado);

                entity.ToTable("USUARIOVINCULADO");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__USUARIOV__161CF72496F492B4")
                    .IsUnique();

                entity.HasIndex(e => e.Senha)
                    .HasName("UQ__USUARIOV__C8727D650DBCD601")
                    .IsUnique();

                entity.Property(e => e.Idusuariovinculado).HasColumnName("IDUSUARIOVINCULADO");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Idpermissao).HasColumnName("IDPERMISSAO");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("SENHA")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdpermissaoNavigation)
                    .WithMany(p => p.Usuariovinculado)
                    .HasForeignKey(d => d.Idpermissao)
                    .HasConstraintName("FK__USUARIOVI__IDPER__5629CD9C");
            });
        }
    }
}
