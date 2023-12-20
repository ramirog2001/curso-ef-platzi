﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using curso_ef_platzi;

#nullable disable

namespace curso_ef_platzi.Migrations
{
    [DbContext(typeof(TareasContext))]
    partial class TareasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("curso_ef_platzi.Models.Categoria", b =>
                {
                    b.Property<Guid>("CategoriaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Descripcion")
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<int>("Peso")
                        .HasColumnType("integer");

                    b.HasKey("CategoriaID");

                    b.ToTable("Categoria", (string)null);

                    b.HasData(
                        new
                        {
                            CategoriaID = new Guid("771fe61e-10b0-4174-8e42-bf5296b5e749"),
                            Descripcion = "Tareas que todavía no se realizaron, se planean realizar en un futuro.",
                            Nombre = "Pendientes",
                            Peso = 3
                        },
                        new
                        {
                            CategoriaID = new Guid("f0b33476-d01b-4b35-bbe7-8dcf74308c2f"),
                            Descripcion = "Tareas que ya finalizaron.",
                            Nombre = "Terminadas",
                            Peso = 2
                        },
                        new
                        {
                            CategoriaID = new Guid("f046722f-c17e-47c5-aa34-c07f1578f9d9"),
                            Descripcion = "Tareas que todavía no se realizaron, y no se planean realizar en un futuro.",
                            Nombre = "Descartadas",
                            Peso = 1
                        });
                });

            modelBuilder.Entity("curso_ef_platzi.Models.Tarea", b =>
                {
                    b.Property<Guid>("TareaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("uuid");

                    b.Property<string>("Descripcion")
                        .HasColumnType("text");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("PrioridadTarea")
                        .HasColumnType("integer");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("TareaId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Tarea", (string)null);

                    b.HasData(
                        new
                        {
                            TareaId = new Guid("8c138467-c085-4333-8a89-d637e071757a"),
                            CategoriaId = new Guid("771fe61e-10b0-4174-8e42-bf5296b5e749"),
                            Descripcion = "Hay que lavar la ropa.",
                            FechaCreacion = new DateTime(2023, 12, 20, 17, 3, 17, 633, DateTimeKind.Utc).AddTicks(4563),
                            PrioridadTarea = 0,
                            Titulo = "Lavar ropa"
                        },
                        new
                        {
                            TareaId = new Guid("8c138467-c085-4333-8a89-d637e071757b"),
                            CategoriaId = new Guid("f0b33476-d01b-4b35-bbe7-8dcf74308c2f"),
                            Descripcion = "Desde la pagina oficial.",
                            FechaCreacion = new DateTime(2023, 12, 20, 17, 3, 17, 633, DateTimeKind.Utc).AddTicks(4613),
                            PrioridadTarea = 0,
                            Titulo = "Pagar impuestos"
                        },
                        new
                        {
                            TareaId = new Guid("8c138467-c085-4333-8a89-d637e071757c"),
                            CategoriaId = new Guid("771fe61e-10b0-4174-8e42-bf5296b5e749"),
                            Descripcion = "Acordarse de llevar ropa.",
                            FechaCreacion = new DateTime(2023, 12, 20, 17, 3, 17, 633, DateTimeKind.Utc).AddTicks(4619),
                            PrioridadTarea = 0,
                            Titulo = "Hacer deporte"
                        });
                });

            modelBuilder.Entity("curso_ef_platzi.Models.Tarea", b =>
                {
                    b.HasOne("curso_ef_platzi.Models.Categoria", "Categoria")
                        .WithMany("Tareas")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("curso_ef_platzi.Models.Categoria", b =>
                {
                    b.Navigation("Tareas");
                });
#pragma warning restore 612, 618
        }
    }
}
