using Microsoft.EntityFrameworkCore.Migrations;

namespace Marmitex.Data.Migrations
{
    public partial class UniqueTelefone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Clientes",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Celular",
                table: "Clientes",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Telefone_Celular",
                table: "Clientes",
                columns: new[] { "Telefone", "Celular" },
                unique: true,
                filter: "[Telefone] IS NOT NULL AND [Celular] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Clientes_Telefone_Celular",
                table: "Clientes");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Clientes",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Celular",
                table: "Clientes",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
