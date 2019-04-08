using Microsoft.EntityFrameworkCore.Migrations;

namespace Marmitex.Data.Migrations
{
    public partial class addFormaPagamentoPEdido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OpcaoEntrega",
                table: "Pedidos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OpcaoPagamento",
                table: "Pedidos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OpcaoEntrega",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "OpcaoPagamento",
                table: "Pedidos");
        }
    }
}
