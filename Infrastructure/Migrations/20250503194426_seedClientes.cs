using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedClientes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "cliente_id", "activo", "apellido", "email", "fecha_registro", "nombre", "telefono" },
                values: new object[,]
                {
                    { new Guid("04bc1990-5e8d-4237-a9e4-6e6b8ba76237"), true, "López", "pedro@gmail.com", new DateOnly(2025, 5, 3), "Pedro", "456789123" },
                    { new Guid("04bc1990-5e8d-4237-a9e4-8e5b8ba56237"), true, "Pérez", "juanperez@gmail.com", new DateOnly(2025, 5, 10), "Juan", "123456789" },
                    { new Guid("07bc1770-5e8d-4237-a9e4-8e6b8ba56237"), true, "Gómez", "maria@gmail.com", new DateOnly(2025, 5, 1), "María", "987654321" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "cliente_id",
                keyValue: new Guid("04bc1990-5e8d-4237-a9e4-6e6b8ba76237"));

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "cliente_id",
                keyValue: new Guid("04bc1990-5e8d-4237-a9e4-8e5b8ba56237"));

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "cliente_id",
                keyValue: new Guid("07bc1770-5e8d-4237-a9e4-8e6b8ba56237"));
        }
    }
}
