﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repositorys.Context;

#nullable disable

namespace Repositorys.Migrations
{
    [DbContext(typeof(ListaSupermercadoContext))]
    [Migration("20221123135204_adicionando foto ao produto")]
    partial class adicionandofotoaoproduto
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Entity.Models.ItemListum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CodigoBarrasProduto")
                        .IsRequired()
                        .HasMaxLength(13)
                        .IsUnicode(false)
                        .HasColumnType("varchar(13)");

                    b.Property<bool?>("Comprado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((0))");

                    b.Property<int>("IdLista")
                        .HasColumnType("int");

                    b.Property<int?>("IdSupermercado")
                        .HasColumnType("int");

                    b.Property<decimal?>("Preco")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18, 0)")
                        .HasDefaultValueSql("((0.0))");

                    b.Property<int?>("Quantidade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((0))");

                    b.HasKey("Id")
                        .HasName("PK__ItemList__3214EC07BC497743");

                    b.HasIndex("CodigoBarrasProduto");

                    b.HasIndex("IdLista");

                    b.HasIndex("IdSupermercado");

                    b.ToTable("ItemLista");
                });

            modelBuilder.Entity("Entities.Entity.Models.Listum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataLista")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<bool?>("EstaAtivo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<decimal?>("Total")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18, 0)")
                        .HasDefaultValueSql("((0.0))");

                    b.HasKey("Id")
                        .HasName("PK__Lista__3214EC07D4A13CF5");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Lista");
                });

            modelBuilder.Entity("Entities.Entity.Models.Produto", b =>
                {
                    b.Property<string>("CodigoBarras")
                        .HasMaxLength(13)
                        .IsUnicode(false)
                        .HasColumnType("varchar(13)");

                    b.Property<string>("Descricao")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("FotoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("CodigoBarras")
                        .HasName("PK__Produto__F61589C9FF6BC74B");

                    b.ToTable("Produto", (string)null);
                });

            modelBuilder.Entity("Entities.Entity.Models.ProdutoSupermercado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CodigoBarrasProduto")
                        .IsRequired()
                        .HasMaxLength(13)
                        .IsUnicode(false)
                        .HasColumnType("varchar(13)");

                    b.Property<int>("IdSupermercado")
                        .HasColumnType("int");

                    b.Property<decimal?>("Preco")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18, 0)")
                        .HasDefaultValueSql("((0.0))");

                    b.HasKey("Id")
                        .HasName("PK__produtoS__3214EC07D7B143BF");

                    b.HasIndex("CodigoBarrasProduto");

                    b.HasIndex("IdSupermercado");

                    b.ToTable("produtoSupermercado", (string)null);
                });

            modelBuilder.Entity("Entities.Entity.Models.Supermercado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bairro")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Cep")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Cidade")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Estado")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Logradouro")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nome")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("PK__Supermer__3214EC0719AAD759");

                    b.ToTable("Supermercado", (string)null);
                });

            modelBuilder.Entity("Entities.Entity.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nome")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Senha")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id")
                        .HasName("PK__Usuario__3214EC07CB9CFB6E");

                    b.HasIndex(new[] { "Email" }, "UQ__Usuario__A9D105349F1CC04A")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("Entities.Models.FotoProduto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Imagem")
                        .IsRequired()
                        .HasColumnType("varbinary");

                    b.HasKey("Id");

                    b.ToTable("FotosProdutos");
                });

            modelBuilder.Entity("Entities.Entity.Models.ItemListum", b =>
                {
                    b.HasOne("Entities.Entity.Models.Produto", "CodigoBarrasProdutoNavigation")
                        .WithMany()
                        .HasForeignKey("CodigoBarrasProduto")
                        .IsRequired()
                        .HasConstraintName("FK__ItemLista__Codig__398D8EEE");

                    b.HasOne("Entities.Entity.Models.Listum", "IdListumNavigation")
                        .WithMany("ItemLista")
                        .HasForeignKey("IdLista")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Entity.Models.Supermercado", "IdSupermercadoNavigation")
                        .WithMany()
                        .HasForeignKey("IdSupermercado")
                        .HasConstraintName("FK__ItemLista__IdSup__38996AB5");

                    b.Navigation("CodigoBarrasProdutoNavigation");

                    b.Navigation("IdListumNavigation");

                    b.Navigation("IdSupermercadoNavigation");
                });

            modelBuilder.Entity("Entities.Entity.Models.Listum", b =>
                {
                    b.HasOne("Entities.Entity.Models.Usuario", "IdUsuarioNavigation")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdUsuarioNavigation");
                });

            modelBuilder.Entity("Entities.Entity.Models.ProdutoSupermercado", b =>
                {
                    b.HasOne("Entities.Entity.Models.Produto", "CodigoBarrasProdutoNavigation")
                        .WithMany()
                        .HasForeignKey("CodigoBarrasProduto")
                        .IsRequired()
                        .HasConstraintName("FK__produtoSu__Codig__32E0915F");

                    b.HasOne("Entities.Entity.Models.Supermercado", "Supermercado")
                        .WithMany()
                        .HasForeignKey("IdSupermercado")
                        .IsRequired()
                        .HasConstraintName("FK__produtoSu__IdSup__31EC6D26");

                    b.Navigation("CodigoBarrasProdutoNavigation");

                    b.Navigation("Supermercado");
                });

            modelBuilder.Entity("Entities.Entity.Models.Listum", b =>
                {
                    b.Navigation("ItemLista");
                });
#pragma warning restore 612, 618
        }
    }
}