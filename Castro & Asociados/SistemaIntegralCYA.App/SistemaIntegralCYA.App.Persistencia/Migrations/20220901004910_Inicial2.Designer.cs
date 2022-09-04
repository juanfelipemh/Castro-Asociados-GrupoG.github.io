﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaIntegralCYA.App.Persistencia;

namespace SistemaIntegralCYA.App.Persistencia.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20220901004910_Inicial2")]
    partial class Inicial2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("SistemaIntegralCYA.App.Dominio.Entidades.Historial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("AdministradorId")
                        .HasColumnType("int");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("DescripcionServicio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaServicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("Horario")
                        .HasColumnType("int");

                    b.Property<string>("Servicio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TecnicosId")
                        .HasColumnType("int");

                    b.Property<float>("Valor")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("AdministradorId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("TecnicosId");

                    b.ToTable("Historial");
                });

            modelBuilder.Entity("SistemaIntegralCYA.App.Dominio.Entidades.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaveUsuario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorreoElectronico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroTelefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Personas");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Persona");
                });

            modelBuilder.Entity("SistemaIntegralCYA.App.Dominio.Entidades.Servicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<float>("Costo")
                        .HasColumnType("real");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TecnicosId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TecnicosId");

                    b.ToTable("Servicios");
                });

            modelBuilder.Entity("SistemaIntegralCYA.App.Dominio.Entidades.Administrador", b =>
                {
                    b.HasBaseType("SistemaIntegralCYA.App.Dominio.Entidades.Persona");

                    b.HasDiscriminator().HasValue("Administrador");
                });

            modelBuilder.Entity("SistemaIntegralCYA.App.Dominio.Entidades.Cliente", b =>
                {
                    b.HasBaseType("SistemaIntegralCYA.App.Dominio.Entidades.Persona");

                    b.Property<string>("DatosMedioPago")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Horario")
                        .HasColumnType("int");

                    b.Property<int?>("TecnicoId")
                        .HasColumnType("int");

                    b.HasIndex("TecnicoId");

                    b.HasDiscriminator().HasValue("Cliente");
                });

            modelBuilder.Entity("SistemaIntegralCYA.App.Dominio.Entidades.Tecnicos", b =>
                {
                    b.HasBaseType("SistemaIntegralCYA.App.Dominio.Entidades.Persona");

                    b.Property<int>("Horario")
                        .HasColumnType("int")
                        .HasColumnName("Tecnicos_Horario");

                    b.Property<string>("TarjetaProfesional")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Tecnicos");
                });

            modelBuilder.Entity("SistemaIntegralCYA.App.Dominio.Entidades.Historial", b =>
                {
                    b.HasOne("SistemaIntegralCYA.App.Dominio.Entidades.Administrador", null)
                        .WithMany("Historial")
                        .HasForeignKey("AdministradorId");

                    b.HasOne("SistemaIntegralCYA.App.Dominio.Entidades.Cliente", null)
                        .WithMany("Historial")
                        .HasForeignKey("ClienteId");

                    b.HasOne("SistemaIntegralCYA.App.Dominio.Entidades.Tecnicos", null)
                        .WithMany("Historial")
                        .HasForeignKey("TecnicosId");
                });

            modelBuilder.Entity("SistemaIntegralCYA.App.Dominio.Entidades.Servicio", b =>
                {
                    b.HasOne("SistemaIntegralCYA.App.Dominio.Entidades.Tecnicos", null)
                        .WithMany("Servicio")
                        .HasForeignKey("TecnicosId");
                });

            modelBuilder.Entity("SistemaIntegralCYA.App.Dominio.Entidades.Cliente", b =>
                {
                    b.HasOne("SistemaIntegralCYA.App.Dominio.Entidades.Tecnicos", "Tecnico")
                        .WithMany()
                        .HasForeignKey("TecnicoId");

                    b.Navigation("Tecnico");
                });

            modelBuilder.Entity("SistemaIntegralCYA.App.Dominio.Entidades.Administrador", b =>
                {
                    b.Navigation("Historial");
                });

            modelBuilder.Entity("SistemaIntegralCYA.App.Dominio.Entidades.Cliente", b =>
                {
                    b.Navigation("Historial");
                });

            modelBuilder.Entity("SistemaIntegralCYA.App.Dominio.Entidades.Tecnicos", b =>
                {
                    b.Navigation("Historial");

                    b.Navigation("Servicio");
                });
#pragma warning restore 612, 618
        }
    }
}
