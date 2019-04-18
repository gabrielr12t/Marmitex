using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Marmitex.Data.Migrations
{
    public partial class AddStatusCardapio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    Sexo = table.Column<int>(nullable: false),
                    Cep = table.Column<string>(nullable: true),
                    Rua = table.Column<string>(nullable: true),
                    RuaNumero = table.Column<int>(nullable: false),
                    Bairro = table.Column<string>(nullable: true),
                    NumeroCasa = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    Celular = table.Column<string>(nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    ClienteId = table.Column<long>(nullable: true),
                    OpcaoEntrega = table.Column<int>(nullable: false),
                    OpcaoPagamento = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MarmitaAcompanhamentos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MarmitaId = table.Column<long>(nullable: true),
                    AcompanhamentoId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarmitaAcompanhamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Acompanhamentos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    StatusCardapio = table.Column<int>(nullable: false),
                    MarmitaId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acompanhamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItensPedidos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PedidoId = table.Column<long>(nullable: true),
                    MarmitaId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensPedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensPedidos_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Misturas",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    StatusCardapio = table.Column<int>(nullable: false),
                    AcrescimoValor = table.Column<decimal>(nullable: false),
                    MarmitaId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Misturas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Saladas",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    StatusCardapio = table.Column<int>(nullable: false),
                    MarmitaId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saladas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marmitas",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SaladaId = table.Column<long>(nullable: true),
                    Valor = table.Column<decimal>(nullable: false),
                    Tamanho = table.Column<int>(nullable: false),
                    MisturaId = table.Column<long>(nullable: true),
                    Observacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marmitas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Marmitas_Misturas_MisturaId",
                        column: x => x.MisturaId,
                        principalTable: "Misturas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Marmitas_Saladas_SaladaId",
                        column: x => x.SaladaId,
                        principalTable: "Saladas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acompanhamentos_MarmitaId",
                table: "Acompanhamentos",
                column: "MarmitaId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedidos_MarmitaId",
                table: "ItensPedidos",
                column: "MarmitaId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedidos_PedidoId",
                table: "ItensPedidos",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_MarmitaAcompanhamentos_AcompanhamentoId",
                table: "MarmitaAcompanhamentos",
                column: "AcompanhamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_MarmitaAcompanhamentos_MarmitaId",
                table: "MarmitaAcompanhamentos",
                column: "MarmitaId");

            migrationBuilder.CreateIndex(
                name: "IX_Marmitas_MisturaId",
                table: "Marmitas",
                column: "MisturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Marmitas_SaladaId",
                table: "Marmitas",
                column: "SaladaId");

            migrationBuilder.CreateIndex(
                name: "IX_Misturas_MarmitaId",
                table: "Misturas",
                column: "MarmitaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedidos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Saladas_MarmitaId",
                table: "Saladas",
                column: "MarmitaId");

            migrationBuilder.AddForeignKey(
                name: "FK_MarmitaAcompanhamentos_Marmitas_MarmitaId",
                table: "MarmitaAcompanhamentos",
                column: "MarmitaId",
                principalTable: "Marmitas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MarmitaAcompanhamentos_Acompanhamentos_AcompanhamentoId",
                table: "MarmitaAcompanhamentos",
                column: "AcompanhamentoId",
                principalTable: "Acompanhamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Acompanhamentos_Marmitas_MarmitaId",
                table: "Acompanhamentos",
                column: "MarmitaId",
                principalTable: "Marmitas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItensPedidos_Marmitas_MarmitaId",
                table: "ItensPedidos",
                column: "MarmitaId",
                principalTable: "Marmitas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.DropTable(
                name: "ItensPedidos");

            migrationBuilder.DropTable(
                name: "MarmitaAcompanhamentos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Acompanhamentos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Marmitas");

            migrationBuilder.DropTable(
                name: "Misturas");

            migrationBuilder.DropTable(
                name: "Saladas");
        }
    }
}
