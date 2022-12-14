// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Periferia.DataAccess;

#nullable disable

namespace Periferia.DataAccess.Migrations
{
    [DbContext(typeof(TiendaDbContext))]
    [Migration("20220828204239_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Periferia.Models.EntityModels.Cliente", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Cedula")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Periferia.Models.EntityModels.Producto", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<double>("ValorUnitario")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("Periferia.Models.EntityModels.ProductoVendido", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProductoId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("VentaClienteId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ProductoId");

                    b.HasIndex("VentaClienteId");

                    b.ToTable("ProductosVendidos");
                });

            modelBuilder.Entity("Periferia.Models.EntityModels.VentaCliente", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClienteId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("ValorTotal")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("Periferia.Models.EntityModels.ProductoVendido", b =>
                {
                    b.HasOne("Periferia.Models.EntityModels.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Periferia.Models.EntityModels.VentaCliente", "VentaCliente")
                        .WithMany("ProductosVendidos")
                        .HasForeignKey("VentaClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");

                    b.Navigation("VentaCliente");
                });

            modelBuilder.Entity("Periferia.Models.EntityModels.VentaCliente", b =>
                {
                    b.HasOne("Periferia.Models.EntityModels.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Periferia.Models.EntityModels.VentaCliente", b =>
                {
                    b.Navigation("ProductosVendidos");
                });
#pragma warning restore 612, 618
        }
    }
}
