using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace curso_ef_platzi.Migrations
{
    /// <inheritdoc />
    public partial class InitData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaID", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("771fe61e-10b0-4174-8e42-bf5296b5e749"), "Tareas que todavía no se realizaron, se planean realizar en un futuro.", "Pendientes", 3 },
                    { new Guid("f046722f-c17e-47c5-aa34-c07f1578f9d9"), "Tareas que todavía no se realizaron, y no se planean realizar en un futuro.", "Descartadas", 1 },
                    { new Guid("f0b33476-d01b-4b35-bbe7-8dcf74308c2f"), "Tareas que ya finalizaron.", "Terminadas", 2 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[,]
                {
                    { new Guid("8c138467-c085-4333-8a89-d637e071757a"), new Guid("771fe61e-10b0-4174-8e42-bf5296b5e749"), "Hay que lavar la ropa.", new DateTime(2023, 12, 20, 17, 3, 17, 633, DateTimeKind.Utc).AddTicks(4563), 0, "Lavar ropa" },
                    { new Guid("8c138467-c085-4333-8a89-d637e071757b"), new Guid("f0b33476-d01b-4b35-bbe7-8dcf74308c2f"), "Desde la pagina oficial.", new DateTime(2023, 12, 20, 17, 3, 17, 633, DateTimeKind.Utc).AddTicks(4613), 0, "Pagar impuestos" },
                    { new Guid("8c138467-c085-4333-8a89-d637e071757c"), new Guid("771fe61e-10b0-4174-8e42-bf5296b5e749"), "Acordarse de llevar ropa.", new DateTime(2023, 12, 20, 17, 3, 17, 633, DateTimeKind.Utc).AddTicks(4619), 0, "Hacer deporte" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaID",
                keyValue: new Guid("f046722f-c17e-47c5-aa34-c07f1578f9d9"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("8c138467-c085-4333-8a89-d637e071757a"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("8c138467-c085-4333-8a89-d637e071757b"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("8c138467-c085-4333-8a89-d637e071757c"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaID",
                keyValue: new Guid("771fe61e-10b0-4174-8e42-bf5296b5e749"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaID",
                keyValue: new Guid("f0b33476-d01b-4b35-bbe7-8dcf74308c2f"));
        }
    }
}
