using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class prueb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06bc1990-5e8d-4237-a9e4-8e6b8ba56237");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "078a1ad8e-302a-4e75-a156-f997bb40d131",
                column: "NormalizedName",
                value: "EMPLOYEE");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "07bc1340-5e8d-4237-a9e4-8e6b8ba56237", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "078a1ad8e-302a-4e75-a156-f997bb40d131", 0, "462bd384-4698-42a8-90e0-2a359e6af3bd", "employee@gmail.com", false, "Employee", false, null, null, null, "Employee1234!", null, false, "e0b5ce7a-c6a1-4c1c-8f9e-2f9212ee73bc", false, "Employee1234!" },
                    { "079a1rd8e-302a-4e75-a156-f997bb40d131", 0, "162bd384-4698-42a8-90e0-2a359e6af3bd", "user@gmail.com", false, "User", false, null, null, null, "User1234!", null, false, "e7b5ce7a-c6a1-4c1c-8f9e-2f9212ee73bc", false, "User1234!" },
                    { "07bc1990-5e8d-4237-a9e4-8e6b8ba56237", 0, "892bd384-4698-42a8-90e0-2a359e6af3bd", "admin@gmail.com", false, "Admin", false, null, null, null, "Admin1234!", null, false, "e2b5ce7a-c6a1-4c1c-8f9e-2f9212ee73bc", false, "Admin1234!" }
                });

            migrationBuilder.InsertData(
                table: "Recursos",
                columns: new[] { "recurso_id", "activo", "capacidad", "descripcion", "nombre", "precio_hora" },
                values: new object[,]
                {
                    { new Guid("07bc1990-5e8d-4237-a9e4-8e6b8ba56537"), true, 80, "Descripcion del recurso 1", "Jungla", 8000m },
                    { new Guid("07bc1990-5e8d-4237-a9e4-8e6b8ba88237"), true, 60, "Descripcion del recurso 2", "Jump", 10000m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07bc1340-5e8d-4237-a9e4-8e6b8ba56237");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "078a1ad8e-302a-4e75-a156-f997bb40d131");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "079a1rd8e-302a-4e75-a156-f997bb40d131");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "07bc1990-5e8d-4237-a9e4-8e6b8ba56237");

            migrationBuilder.DeleteData(
                table: "Recursos",
                keyColumn: "recurso_id",
                keyValue: new Guid("07bc1990-5e8d-4237-a9e4-8e6b8ba56537"));

            migrationBuilder.DeleteData(
                table: "Recursos",
                keyColumn: "recurso_id",
                keyValue: new Guid("07bc1990-5e8d-4237-a9e4-8e6b8ba88237"));


            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "078a1ad8e-302a-4e75-a156-f997bb40d131",
                column: "NormalizedName",
                value: "EMPLOYE");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "06bc1990-5e8d-4237-a9e4-8e6b8ba56237", null, "Admin", "ADMIN" });
        }
    }
}
