using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class OpFlixContext : DbContext
    {
        public OpFlixContext()
        {
        }

        public OpFlixContext(DbContextOptions<OpFlixContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Lancamento> Lancamento { get; set; }
        public virtual DbSet<Permissao> Permissao { get; set; }
        public virtual DbSet<Permissão> Permissão { get; set; }
        public virtual DbSet<Plataforma> Plataforma { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress;Initial Catalog=T_OpFlix;User Id=sa;Pwd=132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria);

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Categori__7D8FE3B25C3F51A7")
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Lancamento>(entity =>
            {
                entity.HasKey(e => e.IdLancamento);

                entity.Property(e => e.DataDeLancamento)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Sinopse)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Tempo)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Lancamento)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__Lancament__IdCat__60A75C0F");

                entity.HasOne(d => d.IdPermissaoNavigation)
                    .WithMany(p => p.Lancamento)
                    .HasForeignKey(d => d.IdPermissao)
                    .HasConstraintName("FK__Lancament__IdPer__619B8048");
            });

            modelBuilder.Entity<Permissao>(entity =>
            {
                entity.HasKey(e => e.IdPermissao);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Permissão>(entity =>
            {
                entity.HasKey(e => e.IdPermissão);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Plataforma>(entity =>
            {
                entity.HasKey(e => e.IdPlataforma);

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Platafor__7D8FE3B2F0C40157")
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Imagem)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdP)
                    .HasConstraintName("FK__Usuario__IdP__5BE2A6F2");
            });
        }
    }
}
