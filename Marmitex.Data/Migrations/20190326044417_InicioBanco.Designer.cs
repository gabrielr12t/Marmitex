﻿// <auto-generated />
using System;
using Marmitex.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Marmitex.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190326044417_InicioBanco")]
    partial class InicioBanco
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Marmitex.Domain.Entidades.Acompanhamento", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data");

                    b.Property<long?>("MarmitaId");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.HasIndex("MarmitaId");

                    b.ToTable("Acompanhamentos");
                });

            modelBuilder.Entity("Marmitex.Domain.Entidades.Cliente", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro");

                    b.Property<string>("Celular");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<string>("Nome");

                    b.Property<string>("NumeroCasa");

                    b.Property<string>("Rua");

                    b.Property<int>("RuaNumero");

                    b.Property<int>("Sexo");

                    b.Property<string>("Sobrenome");

                    b.Property<string>("Telefone");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Marmitex.Domain.Entidades.ItensPedido", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MarmitaId");

                    b.Property<long?>("MarmitaId1");

                    b.Property<int>("PedidoId");

                    b.Property<long?>("PedidoId1");

                    b.HasKey("Id");

                    b.HasIndex("MarmitaId1");

                    b.HasIndex("PedidoId1");

                    b.ToTable("ItensPedidos");
                });

            modelBuilder.Entity("Marmitex.Domain.Entidades.Marmita", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AcompanhamentoId");

                    b.Property<int>("MisturaId");

                    b.Property<long?>("MisturaId1");

                    b.Property<int>("SaladaId");

                    b.Property<long?>("SaladaId1");

                    b.Property<int>("Tamanho");

                    b.Property<decimal>("Valor");

                    b.HasKey("Id");

                    b.HasIndex("MisturaId1");

                    b.HasIndex("SaladaId1");

                    b.ToTable("Marmitas");
                });

            modelBuilder.Entity("Marmitex.Domain.Entidades.Mistura", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AcrescimoValor");

                    b.Property<DateTime>("Data");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Misturas");
                });

            modelBuilder.Entity("Marmitex.Domain.Entidades.Pedido", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId");

                    b.Property<long?>("ClienteId1");

                    b.Property<DateTime>("Data");

                    b.Property<decimal>("Total");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId1");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("Marmitex.Domain.Entidades.Salada", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Saladas");
                });

            modelBuilder.Entity("Marmitex.Domain.Entidades.Acompanhamento", b =>
                {
                    b.HasOne("Marmitex.Domain.Entidades.Marmita")
                        .WithMany("Acompanhamentos")
                        .HasForeignKey("MarmitaId");
                });

            modelBuilder.Entity("Marmitex.Domain.Entidades.ItensPedido", b =>
                {
                    b.HasOne("Marmitex.Domain.Entidades.Marmita", "Marmita")
                        .WithMany()
                        .HasForeignKey("MarmitaId1");

                    b.HasOne("Marmitex.Domain.Entidades.Pedido", "Pedido")
                        .WithMany()
                        .HasForeignKey("PedidoId1");
                });

            modelBuilder.Entity("Marmitex.Domain.Entidades.Marmita", b =>
                {
                    b.HasOne("Marmitex.Domain.Entidades.Mistura", "Mistura")
                        .WithMany()
                        .HasForeignKey("MisturaId1");

                    b.HasOne("Marmitex.Domain.Entidades.Salada", "Salada")
                        .WithMany()
                        .HasForeignKey("SaladaId1");
                });

            modelBuilder.Entity("Marmitex.Domain.Entidades.Pedido", b =>
                {
                    b.HasOne("Marmitex.Domain.Entidades.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId1");
                });
#pragma warning restore 612, 618
        }
    }
}
