using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CheckFipe.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Veiculo",
                columns: table => new
                {
                    IdVeiculo = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoMarca = table.Column<long>(nullable: false),
                    CodigoFipe = table.Column<string>(nullable: true),
                    CodigoAno = table.Column<string>(nullable: true),
                    Preco = table.Column<string>(nullable: true),
                    DescricaoCombustivel = table.Column<string>(nullable: true),
                    AnoModelo = table.Column<string>(nullable: true),
                    DescricaoMarca = table.Column<string>(nullable: true),
                    DescricaoModelo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculo", x => x.IdVeiculo);
                });

            migrationBuilder.CreateTable(
                name: "ConsultaVeiculo",
                columns: table => new
                {
                    IdConsultaVeiculo = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataConsultaVeiculo = table.Column<DateTime>(nullable: false),
                    IdVeiculo = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultaVeiculo", x => x.IdConsultaVeiculo);
                    table.ForeignKey(
                        name: "FK_ConsultaVeiculo_Veiculo_IdVeiculo",
                        column: x => x.IdVeiculo,
                        principalTable: "Veiculo",
                        principalColumn: "IdVeiculo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsultaVeiculo_IdVeiculo",
                table: "ConsultaVeiculo",
                column: "IdVeiculo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsultaVeiculo");

            migrationBuilder.DropTable(
                name: "Veiculo");
        }
    }
}
