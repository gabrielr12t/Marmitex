using Microsoft.EntityFrameworkCore.Migrations;

namespace Marmitex.Data.Migrations
{
    public partial class BanconCriadoNovamente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "MarmitaId",
                table: "Saladas",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "MarmitaId",
                table: "Misturas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Saladas_MarmitaId",
                table: "Saladas",
                column: "MarmitaId");

            migrationBuilder.CreateIndex(
                name: "IX_Misturas_MarmitaId",
                table: "Misturas",
                column: "MarmitaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Misturas_Marmitas_MarmitaId",
                table: "Misturas",
                column: "MarmitaId",
                principalTable: "Marmitas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Saladas_Marmitas_MarmitaId",
                table: "Saladas",
                column: "MarmitaId",
                principalTable: "Marmitas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Misturas_Marmitas_MarmitaId",
                table: "Misturas");

            migrationBuilder.DropForeignKey(
                name: "FK_Saladas_Marmitas_MarmitaId",
                table: "Saladas");

            migrationBuilder.DropIndex(
                name: "IX_Saladas_MarmitaId",
                table: "Saladas");

            migrationBuilder.DropIndex(
                name: "IX_Misturas_MarmitaId",
                table: "Misturas");

            migrationBuilder.DropColumn(
                name: "MarmitaId",
                table: "Saladas");

            migrationBuilder.DropColumn(
                name: "MarmitaId",
                table: "Misturas");
        }
    }
}
