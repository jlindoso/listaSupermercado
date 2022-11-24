using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositorys.Migrations
{
    /// <inheritdoc />
    public partial class adicionandofotoaoproduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Produto");

            migrationBuilder.AddColumn<int>(
                name: "FotoId",
                table: "Produto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FotosProdutos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Imagem = table.Column<byte[]>(type: "varbinary", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FotosProdutos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FotosProdutos");

            migrationBuilder.DropColumn(
                name: "FotoId",
                table: "Produto");

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Produto",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);
        }
    }
}
