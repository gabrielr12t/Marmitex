﻿// <auto-generated />
using System;
using Marmitex.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Marmitex.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Cep");

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

                    b.Property<long?>("MarmitaId");

                    b.Property<long?>("PedidoId");

                    b.HasKey("Id");

                    b.HasIndex("MarmitaId");

                    b.HasIndex("PedidoId");

                    b.ToTable("ItensPedidos");
                });

            modelBuilder.Entity("Marmitex.Domain.Entidades.Marmita", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("MisturaId");

                    b.Property<long?>("SaladaId");

                    b.Property<int>("Tamanho");

                    b.Property<decimal>("Valor");

                    b.HasKey("Id");

                    b.HasIndex("MisturaId");

                    b.HasIndex("SaladaId");

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

                    b.Property<long?>("ClienteId");

                    b.Property<DateTime>("Data");

                    b.Property<decimal>("Total");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

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
                        .HasForeignKey("MarmitaId");

                    b.HasOne("Marmitex.Domain.Entidades.Pedido", "Pedido")
                        .WithMany()
                        .HasForeignKey("PedidoId");
                });

            modelBuilder.Entity("Marmitex.Domain.Entidades.Marmita", b =>
                {
                    b.HasOne("Marmitex.Domain.Entidades.Mistura", "Mistura")
                        .WithMany()
                        .HasForeignKey("MisturaId");

                    b.HasOne("Marmitex.Domain.Entidades.Salada", "Salada")
                        .WithMany()
                        .HasForeignKey("SaladaId");
                });

            modelBuilder.Entity("Marmitex.Domain.Entidades.Pedido", b =>
                {
                    b.HasOne("Marmitex.Domain.Entidades.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");
                });
#pragma warning restore 612, 618
        }
    }
}
