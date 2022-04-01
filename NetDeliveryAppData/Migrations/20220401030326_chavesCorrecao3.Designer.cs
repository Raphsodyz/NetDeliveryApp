﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetDeliveryAppData.Contexto;

#nullable disable

namespace NetDeliveryAppData.Migrations
{
    [DbContext(typeof(NetDeliveryAppContext))]
    [Migration("20220401030326_chavesCorrecao3")]
    partial class chavesCorrecao3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("NetDeliveryAppDominio.Entidades.Bebida", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Sabor")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Volume")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.ToTable("Bebidas");
                });

            modelBuilder.Entity("NetDeliveryAppDominio.Entidades.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataCriacao")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("PedidosId")
                        .HasColumnType("int");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("NetDeliveryAppDominio.Entidades.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Cidade")
                        .HasColumnType("longtext");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<sbyte>("Numero")
                        .HasColumnType("tinyint");

                    b.Property<string>("Observacao")
                        .HasColumnType("longtext");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("NetDeliveryAppDominio.Entidades.Hamburguer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Ingredientes")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.ToTable("Hamburguers");
                });

            modelBuilder.Entity("NetDeliveryAppDominio.Entidades.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BebidaId")
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataPedido")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("HamburguerId")
                        .HasColumnType("int");

                    b.Property<string>("Observacao")
                        .HasColumnType("longtext");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("BebidaId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("HamburguerId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("NetDeliveryAppDominio.Entidades.Endereco", b =>
                {
                    b.HasOne("NetDeliveryAppDominio.Entidades.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("NetDeliveryAppDominio.Entidades.Pedido", b =>
                {
                    b.HasOne("NetDeliveryAppDominio.Entidades.Bebida", "Bebida")
                        .WithMany()
                        .HasForeignKey("BebidaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetDeliveryAppDominio.Entidades.Cliente", "Cliente")
                        .WithMany("Pedidos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetDeliveryAppDominio.Entidades.Hamburguer", "Hamburguer")
                        .WithMany()
                        .HasForeignKey("HamburguerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bebida");

                    b.Navigation("Cliente");

                    b.Navigation("Hamburguer");
                });

            modelBuilder.Entity("NetDeliveryAppDominio.Entidades.Cliente", b =>
                {
                    b.Navigation("Pedidos");
                });
#pragma warning restore 612, 618
        }
    }
}
