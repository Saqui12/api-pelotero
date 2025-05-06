using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    cliente_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    apellido = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    telefono = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    fecha_registro = table.Column<DateOnly>(type: "date", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Clientes__47E34D6463C3D9ED", x => x.cliente_id);
                });

            migrationBuilder.CreateTable(
                name: "Recursos",
                columns: table => new
                {
                    recurso_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    descripcion = table.Column<string>(type: "text", nullable: true),
                    capacidad = table.Column<int>(type: "int", nullable: true),
                    precio_hora = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Recursos__054F2526F67C96EA", x => x.recurso_id);
                });

            migrationBuilder.CreateTable(
                name: "Bloqueos",
                columns: table => new
                {
                    bloqueo_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    recurso_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    hora_inicio = table.Column<TimeOnly>(type: "time", nullable: false),
                    hora_fin = table.Column<TimeOnly>(type: "time", nullable: false),
                    motivo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Bloqueos__23A6D9CE349ADE33", x => x.bloqueo_id);
                    table.ForeignKey(
                        name: "FK__Bloqueos__recurs__4AB81AF0",
                        column: x => x.recurso_id,
                        principalTable: "Recursos",
                        principalColumn: "recurso_id");
                });

            migrationBuilder.CreateTable(
                name: "HorariosDisponibilidad",
                columns: table => new
                {
                    horario_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    recurso_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    dia_semana = table.Column<int>(type: "int", nullable: true),
                    hora_apertura = table.Column<TimeOnly>(type: "time", nullable: false),
                    hora_cierre = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Horarios__5A3872289CFC8D99", x => x.horario_id);
                    table.ForeignKey(
                        name: "FK__HorariosD__recur__47DBAE45",
                        column: x => x.recurso_id,
                        principalTable: "Recursos",
                        principalColumn: "recurso_id");
                });

            migrationBuilder.CreateTable(
                name: "Turnos",
                columns: table => new
                {
                    turno_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cliente_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    recurso_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    hora_inicio = table.Column<TimeOnly>(type: "time", nullable: false),
                    hora_fin = table.Column<TimeOnly>(type: "time", nullable: false),
                    estado = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    monto_total = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    fecha_reserva = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    notas = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Turnos__8E611ADF24DACE81", x => x.turno_id);
                    table.ForeignKey(
                        name: "FK__Turnos__cliente___3F466844",
                        column: x => x.cliente_id,
                        principalTable: "Clientes",
                        principalColumn: "cliente_id");
                    table.ForeignKey(
                        name: "FK__Turnos__recurso___403A8C7D",
                        column: x => x.recurso_id,
                        principalTable: "Recursos",
                        principalColumn: "recurso_id");
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    pago_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    turno_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    monto = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    metodo_pago = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    fecha_pago = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    estado = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    transaccion_id = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Pagos__FFF0A58EA84C92A1", x => x.pago_id);
                    table.ForeignKey(
                        name: "FK__Pagos__turno_id__440B1D61",
                        column: x => x.turno_id,
                        principalTable: "Turnos",
                        principalColumn: "turno_id");
                });

            migrationBuilder.CreateIndex(
                name: "idx_bloqueos_fecha",
                table: "Bloqueos",
                column: "fecha");

            migrationBuilder.CreateIndex(
                name: "IX_Bloqueos_recurso_id",
                table: "Bloqueos",
                column: "recurso_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Clientes__AB6E616474DE82F3",
                table: "Clientes",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HorariosDisponibilidad_recurso_id",
                table: "HorariosDisponibilidad",
                column: "recurso_id");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_turno_id",
                table: "Pagos",
                column: "turno_id");

            migrationBuilder.CreateIndex(
                name: "idx_turnos_cliente",
                table: "Turnos",
                column: "cliente_id");

            migrationBuilder.CreateIndex(
                name: "idx_turnos_fecha_hora",
                table: "Turnos",
                columns: new[] { "fecha", "hora_inicio", "hora_fin" });

            migrationBuilder.CreateIndex(
                name: "idx_turnos_recurso",
                table: "Turnos",
                column: "recurso_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bloqueos");

            migrationBuilder.DropTable(
                name: "HorariosDisponibilidad");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Turnos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Recursos");
        }
    }
}
