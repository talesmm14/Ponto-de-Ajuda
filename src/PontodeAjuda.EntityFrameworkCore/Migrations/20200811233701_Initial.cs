using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PontodeAjuda.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Suprimentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false),
                    icon = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suprimentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pontos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 256, nullable: false),
                    Descricao = table.Column<string>(maxLength: 65536, nullable: true),
                    Endereco = table.Column<string>(maxLength: 65536, nullable: false),
                    Telefone = table.Column<string>(nullable: true),
                    DataFinal = table.Column<DateTime>(nullable: false),
                    SuprimentosId = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pontos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pontos_Suprimentos_SuprimentosId",
                        column: x => x.SuprimentosId,
                        principalTable: "Suprimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pontos_SuprimentosId",
                table: "Pontos",
                column: "SuprimentosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pontos");

            migrationBuilder.DropTable(
                name: "Suprimentos");
        }
    }
}
