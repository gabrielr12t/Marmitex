using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Marmitex.Data.Migrations
{
    public partial class InicioBanco : Migration
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
                    Data = table.Column<DateTime>(nullable: false)
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
                    ClienteId = table.Column<int>(nullable: false),
                    ClienteId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_ClienteId1",
                        column: x => x.ClienteId1,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Marmitas",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SaladaId1 = table.Column<long>(nullable: true),
                    SaladaId = table.Column<int>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    Tamanho = table.Column<int>(nullable: false),
                    MisturaId1 = table.Column<long>(nullable: true),
                    MisturaId = table.Column<int>(nullable: false),
                    AcompanhamentoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marmitas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Marmitas_Misturas_MisturaId1",
                        column: x => x.MisturaId1,
                        principalTable: "Misturas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Marmitas_Saladas_SaladaId1",
                        column: x => x.SaladaId1,
                        principalTable: "Saladas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Acompanhamentos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
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
                name: "ItensPedidos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PedidoId1 = table.Column<long>(nullable: true),
                    MarmitaId1 = table.Column<long>(nullable: true),
                    PedidoId = table.Column<int>(nullable: false),
                    MarmitaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensPedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensPedidos_Marmitas_MarmitaId1",
                        column: x => x.MarmitaId1,
                        principalTable: "Marmitas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItensPedidos_Pedidos_PedidoId1",
                        column: x => x.PedidoId1,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acompanhamentos_MarmitaId",
                table: "Acompanhamentos",
                column: "MarmitaId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedidos_MarmitaId1",
                table: "ItensPedidos",
                column: "MarmitaId1");

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedidos_PedidoId1",
                table: "ItensPedidos",
                column: "PedidoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Marmitas_MisturaId1",
                table: "Marmitas",
                column: "MisturaId1");

            migrationBuilder.CreateIndex(
                name: "IX_Marmitas_SaladaId1",
                table: "Marmitas",
                column: "SaladaId1");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteId1",
                table: "Pedidos",
                column: "ClienteId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acompanhamentos");

            migrationBuilder.DropTable(
                name: "ItensPedidos");

            migrationBuilder.DropTable(
                name: "Marmitas");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Misturas");

            migrationBuilder.DropTable(
                name: "Saladas");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
