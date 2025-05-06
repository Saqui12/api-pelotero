using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedHorarioDisponibles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "HorariosDisponibilidad",
                columns: new[] { "horario_id", "dia_semana", "hora_apertura", "hora_cierre", "recurso_id" },
                values: new object[,]
                {
                    { new Guid("03bc1990-5e8d-4237-a9e4-2e6b8ba56537"), "Friday", new TimeOnly(8, 0, 0), new TimeOnly(20, 0, 0), new Guid("07bc1990-5e8d-4237-a9e4-8e6b8ba56537") },
                    { new Guid("07bc1990-5e8d-4237-a9e4-4e6b5ba36537"), "Monday", new TimeOnly(8, 0, 0), new TimeOnly(20, 0, 0), new Guid("07bc1990-5e8d-4237-a9e4-8e6b8ba56537") },
                    { new Guid("07bc1990-5e8d-4237-a9e4-8e6b8ba51237"), "Wendesday", new TimeOnly(8, 0, 0), new TimeOnly(20, 0, 0), new Guid("07bc1990-5e8d-4237-a9e4-8e6b8ba56537") },
                    { new Guid("07bc1990-5e8d-4237-a9e4-8e6b8ba56739"), "Tuesday", new TimeOnly(8, 0, 0), new TimeOnly(20, 0, 0), new Guid("07bc1990-5e8d-4237-a9e4-8e6b8ba56537") },
                    { new Guid("07bc1990-5e8d-5237-a3e4-8e6b8ba56537"), "Thursday", new TimeOnly(8, 0, 0), new TimeOnly(20, 0, 0), new Guid("07bc1990-5e8d-4237-a9e4-8e6b8ba56537") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HorariosDisponibilidad",
                keyColumn: "horario_id",
                keyValue: new Guid("03bc1990-5e8d-4237-a9e4-2e6b8ba56537"));

            migrationBuilder.DeleteData(
                table: "HorariosDisponibilidad",
                keyColumn: "horario_id",
                keyValue: new Guid("07bc1990-5e8d-4237-a9e4-4e6b5ba36537"));

            migrationBuilder.DeleteData(
                table: "HorariosDisponibilidad",
                keyColumn: "horario_id",
                keyValue: new Guid("07bc1990-5e8d-4237-a9e4-8e6b8ba51237"));

            migrationBuilder.DeleteData(
                table: "HorariosDisponibilidad",
                keyColumn: "horario_id",
                keyValue: new Guid("07bc1990-5e8d-4237-a9e4-8e6b8ba56739"));

            migrationBuilder.DeleteData(
                table: "HorariosDisponibilidad",
                keyColumn: "horario_id",
                keyValue: new Guid("07bc1990-5e8d-5237-a3e4-8e6b8ba56537"));
        }
    }
}
