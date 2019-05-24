using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Marmitex.Data.Migrations
{
    public partial class Inicio : Migration
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
                name: "Misturas",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    StatusCardapio = table.Column<int>(nullable: false),
                    AcrescimoValor = table.Column<decimal>(nullable: false)
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
                    StatusCardapio = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saladas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    ClienteId = table.Column<long>(nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Marmitas",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SaladaId = table.Column<long>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    Tamanho = table.Column<int>(nullable: false),
                    MisturaId = table.Column<long>(nullable: false),
                    Observacao = table.Column<string>(nullable: true),
                    PedidoId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marmitas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Marmitas_Misturas_MisturaId",
                        column: x => x.MisturaId,
                        principalTable: "Misturas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Marmitas_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Marmitas_Saladas_SaladaId",
                        column: x => x.SaladaId,
                        principalTable: "Saladas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_Acompanhamentos_Marmitas_MarmitaId",
                        column: x => x.MarmitaId,
                        principalTable: "Marmitas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MarmitaAcompanhamentos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MarmitaId = table.Column<long>(nullable: false),
                    AcompanhamentoId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarmitaAcompanhamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarmitaAcompanhamentos_Acompanhamentos_AcompanhamentoId",
                        column: x => x.AcompanhamentoId,
                        principalTable: "Acompanhamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarmitaAcompanhamentos_Marmitas_MarmitaId",
                        column: x => x.MarmitaId,
                        principalTable: "Marmitas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acompanhamentos_MarmitaId",
                table: "Acompanhamentos",
                column: "MarmitaId");

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
                name: "IX_Marmitas_PedidoId",
                table: "Marmitas",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Marmitas_SaladaId",
                table: "Marmitas",
                column: "SaladaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedidos",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarmitaAcompanhamentos");

            migrationBuilder.DropTable(
                name: "Acompanhamentos");

            migrationBuilder.DropTable(
                name: "Marmitas");

            migrationBuilder.DropTable(
                name: "Misturas");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Saladas");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
