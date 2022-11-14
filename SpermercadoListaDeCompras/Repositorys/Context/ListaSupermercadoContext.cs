using Entities.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositorys.Context;

public partial class ListaSupermercadoContext : DbContext
{
    public ListaSupermercadoContext()
    {
    }

    public ListaSupermercadoContext(DbContextOptions<ListaSupermercadoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ItemListum> ItemLista { get; set; }

    public virtual DbSet<Listum> Lista { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    public virtual DbSet<ProdutoSupermercado> ProdutoSupermercados { get; set; }

    public virtual DbSet<Supermercado> Supermercados { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=ListaSupermercado;Integrated Security=True; Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ItemListum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ItemList__3214EC07BC497743");

            entity.Property(e => e.CodigoBarrasProduto)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.Comprado).HasDefaultValueSql("((0))");
            entity.Property(e => e.Preco)
                .HasDefaultValueSql("((0.0))")
                .HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Quantidade).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.CodigoBarrasProdutoNavigation).WithMany(p => p.ItemLista)
                .HasForeignKey(d => d.CodigoBarrasProduto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ItemLista__Codig__398D8EEE");

            entity.HasOne(d => d.IdSupermercadoNavigation).WithMany(p => p.ItemLista)
                .HasForeignKey(d => d.IdSupermercado)
                .HasConstraintName("FK__ItemLista__IdSup__38996AB5");
        });

        modelBuilder.Entity<Listum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Lista__3214EC07D4A13CF5");

            entity.Property(e => e.DataLista)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.EstaAtivo).HasDefaultValueSql("((1))");
            entity.Property(e => e.Total)
                .HasDefaultValueSql("((0.0))")
                .HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Lista)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Lista__IdUsuario__2E1BDC42");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.CodigoBarras).HasName("PK__Produto__F61589C9FF6BC74B");

            entity.ToTable("Produto");

            entity.Property(e => e.CodigoBarras)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.Descricao)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Foto)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ProdutoSupermercado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__produtoS__3214EC07D7B143BF");

            entity.ToTable("produtoSupermercado");

            entity.Property(e => e.CodigoBarrasProduto)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.Preco)
                .HasDefaultValueSql("((0.0))")
                .HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.CodigoBarrasProdutoNavigation).WithMany(p => p.ProdutoSupermercados)
                .HasForeignKey(d => d.CodigoBarrasProduto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__produtoSu__Codig__32E0915F");

            entity.HasOne(d => d.Supermercado).WithMany(p => p.ProdutoSupermercados)
                .HasForeignKey(d => d.IdSupermercado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__produtoSu__IdSup__31EC6D26");
        });

        modelBuilder.Entity<Supermercado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Supermer__3214EC0719AAD759");

            entity.ToTable("Supermercado");

            entity.Property(e => e.Bairro)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Cep)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Cidade)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Logradouro)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC07CB9CFB6E");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Email, "UQ__Usuario__A9D105349F1CC04A").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Senha)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
