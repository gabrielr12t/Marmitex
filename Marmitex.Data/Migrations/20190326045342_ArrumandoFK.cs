using Microsoft.EntityFrameworkCore.Migrations;

namespace Marmitex.Data.Migrations
{
    public partial class ArrumandoFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensPedidos_Marmitas_MarmitaId1",
                table: "ItensPedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_ItensPedidos_Pedidos_PedidoId1",
                table: "ItensPedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Marmitas_Misturas_MisturaId1",
                table: "Marmitas");

            migrationBuilder.DropForeignKey(
                name: "FK_Marmitas_Saladas_SaladaId1",
                table: "Marmitas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_ClienteId1",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_ClienteId1",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Marmitas_MisturaId1",
                table: "Marmitas");

            migrationBuilder.DropIndex(
                name: "IX_Marmitas_SaladaId1",
                table: "Marmitas");

            migrationBuilder.DropIndex(
                name: "IX_ItensPedidos_MarmitaId1",
                table: "ItensPedidos");

            migrationBuilder.DropIndex(
                name: "IX_ItensPedidos_PedidoId1",
                table: "ItensPedidos");

            migrationBuilder.DropColumn(
                name: "ClienteId1",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "AcompanhamentoId",
                table: "Marmitas");

            migrationBuilder.DropColumn(
                name: "MisturaId1",
                table: "Marmitas");

            migrationBuilder.DropColumn(
                name: "SaladaId1",
                table: "Marmitas");

            migrationBuilder.DropColumn(
                name: "MarmitaId1",
                table: "ItensPedidos");

            migrationBuilder.DropColumn(
                name: "PedidoId1",
                table: "ItensPedidos");

            migrationBuilder.AlterColumn<long>(
                name: "ClienteId",
                table: "Pedidos",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "SaladaId",
                table: "Marmitas",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "MisturaId",
                table: "Marmitas",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "PedidoId",
                table: "ItensPedidos",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "MarmitaId",
                table: "ItensPedidos",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedidos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Marmitas_MisturaId",
                table: "Marmitas",
                column: "MisturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Marmitas_SaladaId",
                table: "Marmitas",
                column: "SaladaId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedidos_MarmitaId",
                table: "ItensPedidos",
                column: "MarmitaId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedidos_PedidoId",
                table: "ItensPedidos",
                column: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensPedidos_Marmitas_MarmitaId",
                table: "ItensPedidos",
                column: "MarmitaId",
                principalTable: "Marmitas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItensPedidos_Pedidos_PedidoId",
                table: "ItensPedidos",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Marmitas_Misturas_MisturaId",
                table: "Marmitas",
                column: "MisturaId",
                principalTable: "Misturas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Marmitas_Saladas_SaladaId",
                table: "Marmitas",
                column: "SaladaId",
                principalTable: "Saladas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_ClienteId",
                table: "Pedidos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensPedidos_Marmitas_MarmitaId",
                table: "ItensPedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_ItensPedidos_Pedidos_PedidoId",
                table: "ItensPedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Marmitas_Misturas_MisturaId",
                table: "Marmitas");

            migrationBuilder.DropForeignKey(
                name: "FK_Marmitas_Saladas_SaladaId",
                table: "Marmitas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_ClienteId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Marmitas_MisturaId",
                table: "Marmitas");

            migrationBuilder.DropIndex(
                name: "IX_Marmitas_SaladaId",
                table: "Marmitas");

            migrationBuilder.DropIndex(
                name: "IX_ItensPedidos_MarmitaId",
                table: "ItensPedidos");

            migrationBuilder.DropIndex(
                name: "IX_ItensPedidos_PedidoId",
                table: "ItensPedidos");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Pedidos",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ClienteId1",
                table: "Pedidos",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SaladaId",
                table: "Marmitas",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MisturaId",
                table: "Marmitas",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AcompanhamentoId",
                table: "Marmitas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "MisturaId1",
                table: "Marmitas",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SaladaId1",
                table: "Marmitas",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PedidoId",
                table: "ItensPedidos",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MarmitaId",
                table: "ItensPedidos",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "MarmitaId1",
                table: "ItensPedidos",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PedidoId1",
                table: "ItensPedidos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteId1",
                table: "Pedidos",
                column: "ClienteId1");

            migrationBuilder.CreateIndex(
                name: "IX_Marmitas_MisturaId1",
                table: "Marmitas",
                column: "MisturaId1");

            migrationBuilder.CreateIndex(
                name: "IX_Marmitas_SaladaId1",
                table: "Marmitas",
                column: "SaladaId1");

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedidos_MarmitaId1",
                table: "ItensPedidos",
                column: "MarmitaId1");

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedidos_PedidoId1",
                table: "ItensPedidos",
                column: "PedidoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensPedidos_Marmitas_MarmitaId1",
                table: "ItensPedidos",
                column: "MarmitaId1",
                principalTable: "Marmitas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItensPedidos_Pedidos_PedidoId1",
                table: "ItensPedidos",
                column: "PedidoId1",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Marmitas_Misturas_MisturaId1",
                table: "Marmitas",
                column: "MisturaId1",
                principalTable: "Misturas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Marmitas_Saladas_SaladaId1",
                table: "Marmitas",
                column: "SaladaId1",
                principalTable: "Saladas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_ClienteId1",
                table: "Pedidos",
                column: "ClienteId1",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
