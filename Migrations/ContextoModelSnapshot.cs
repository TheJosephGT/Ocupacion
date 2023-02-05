﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Registros.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("Ocupaciones", b =>
                {
                    b.Property<int>("OcupacionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double?>("Salario")
                        .HasColumnType("REAL");

                    b.HasKey("OcupacionID");

                    b.ToTable("ocupaciones");
                });

            modelBuilder.Entity("PagosDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PagoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PrestamoId")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ValorPagado")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("PagosDetalles");

                    b.HasDiscriminator<string>("Discriminator").HasValue("PagosDetalle");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Persona", b =>
                {
                    b.Property<int>("PersonaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Celular")
                        .HasColumnType("TEXT");

                    b.Property<string>("Direccion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FechaNacimiento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("OcupacionId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Telefono")
                        .HasColumnType("TEXT");

                    b.HasKey("PersonaId");

                    b.ToTable("Persona");
                });

            modelBuilder.Entity("Prestamo", b =>
                {
                    b.Property<int>("PrestamoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Concepto")
                        .HasColumnType("TEXT");

                    b.Property<string>("Fecha")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("PersonaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Vence")
                        .HasColumnType("TEXT");

                    b.Property<int?>("balance")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("monto")
                        .HasColumnType("INTEGER");

                    b.HasKey("PrestamoId");

                    b.ToTable("Prestamo");
                });

            modelBuilder.Entity("Pagos", b =>
                {
                    b.HasBaseType("PagosDetalle");

                    b.Property<string>("Concepto")
                        .HasColumnType("TEXT");

                    b.Property<string>("Fecha")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Monto")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PersonaId")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("Pagos");
                });
#pragma warning restore 612, 618
        }
    }
}
