using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositorys.Migrations
{
    /// <inheritdoc />
    public partial class recriandobanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    CodigoBarras = table.Column<string>(type: "varchar(13)", unicode: false, maxLength: 13, nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Descricao = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Foto = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Produto__F61589C9FF6BC74B", x => x.CodigoBarras);
                });

            migrationBuilder.CreateTable(
                name: "Supermercado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Logradouro = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Cidade = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Bairro = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Estado = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Cep = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Supermer__3214EC0719AAD759", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Senha = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuario__3214EC07CB9CFB6E", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "produtoSupermercado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Preco = table.Column<decimal>(type: "decimal(18,0)", nullable: true, defaultValueSql: "((0.0))"),
                    IdSupermercado = table.Column<int>(type: "int", nullable: false),
                    CodigoBarrasProduto = table.Column<string>(type: "varchar(13)", unicode: false, maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__produtoS__3214EC07D7B143BF", x => x.Id);
                    table.ForeignKey(
                        name: "FK__produtoSu__Codig__32E0915F",
                        column: x => x.CodigoBarrasProduto,
                        principalTable: "Produto",
                        principalColumn: "CodigoBarras");
                    table.ForeignKey(
                        name: "FK__produtoSu__IdSup__31EC6D26",
                        column: x => x.IdSupermercado,
                        principalTable: "Supermercado",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Lista",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataLista = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    Total = table.Column<decimal>(type: "decimal(18,0)", nullable: true, defaultValueSql: "((0.0))"),
                    EstaAtivo = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Lista__3214EC07D4A13CF5", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lista_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemLista",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantidade = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    Comprado = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    Preco = table.Column<decimal>(type: "decimal(18,0)", nullable: true, defaultValueSql: "((0.0))"),
                    IdSupermercado = table.Column<int>(type: "int", nullable: true),
                    CodigoBarrasProduto = table.Column<string>(type: "varchar(13)", unicode: false, maxLength: 13, nullable: false),
                    IdLista = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ItemList__3214EC07BC497743", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemLista_Lista_IdLista",
                        column: x => x.IdLista,
                        principalTable: "Lista",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__ItemLista__Codig__398D8EEE",
                        column: x => x.CodigoBarrasProduto,
                        principalTable: "Produto",
                        principalColumn: "CodigoBarras");
                    table.ForeignKey(
                        name: "FK__ItemLista__IdSup__38996AB5",
                        column: x => x.IdSupermercado,
                        principalTable: "Supermercado",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemLista_CodigoBarrasProduto",
                table: "ItemLista",
                column: "CodigoBarrasProduto");

            migrationBuilder.CreateIndex(
                name: "IX_ItemLista_IdLista",
                table: "ItemLista",
                column: "IdLista");

            migrationBuilder.CreateIndex(
                name: "IX_ItemLista_IdSupermercado",
                table: "ItemLista",
                column: "IdSupermercado");

            migrationBuilder.CreateIndex(
                name: "IX_Lista_IdUsuario",
                table: "Lista",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_produtoSupermercado_CodigoBarrasProduto",
                table: "produtoSupermercado",
                column: "CodigoBarrasProduto");

            migrationBuilder.CreateIndex(
                name: "IX_produtoSupermercado_IdSupermercado",
                table: "produtoSupermercado",
                column: "IdSupermercado");

            migrationBuilder.CreateIndex(
                name: "UQ__Usuario__A9D105349F1CC04A",
                table: "Usuario",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemLista");

            migrationBuilder.DropTable(
                name: "produtoSupermercado");

            migrationBuilder.DropTable(
                name: "Lista");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Supermercado");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
