using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seeduser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "078a1ad8e-302a-4e75-a156-f997bb40d131", 0, "462bd384-4698-42a8-90e0-2a359e6af3bd", "employee@gmail.com", false, "Employee1234!", false, null, "EMPLOYEE@GMAIL.COM", "EMPLOYEE@GMAIL.COM", "AQAAAAIAAYagAAAAEPhdcQnNXI8EKVZakKNmRPedmr+sBV1yxeBAeSOAqEvtujsYAgMTQ7Sq2/aZ36mqQg==", null, false, "e0b5ce7a-c6a1-4c1c-8f9e-2f9212ee73bc", false, "employee@gmail.com" },
                    { "079a1rd8e-302a-4e75-a156-f997bb40d131", 0, "162bd384-4698-42a8-90e0-2a359e6af3bd", "user@gmail.com", false, "User1234!", false, null, "USER@GMAIL.COM", "USER@GMAIL.COM", "AQAAAAIAAYagAAAAEN6erUfNGTWPzpDB0rcvN8mAsr+Oed4PWckqlJPCRUNizdj58HRYN8B9HF9Xc3rSiQ==", null, false, "e7b5ce7a-c6a1-4c1c-8f9e-2f9212ee73bc", false, "user@gmail.com" },
                    { "07bc1990-5e8d-4237-a9e4-8e6b8ba56237", 0, "892bd384-4698-42a8-90e0-2a359e6af3bd", "admin@gmail.com", false, "Admin1234!", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEAiIJOcSduEzjc8bubbyi0gF/7rAz4yYE1sLol2XzqD3Jd/VsmhserCkL44tZExtcA==", null, false, "e2b5ce7a-c6a1-4c1c-8f9e-2f9212ee73bc", false, "admin@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "078a1ad8e-302a-4e75-a156-f997bb40d131", "078a1ad8e-302a-4e75-a156-f997bb40d131" },
                    { "596fd05b-7d8c-4c8d-aef1-c50dae89977a", "079a1rd8e-302a-4e75-a156-f997bb40d131" },
                    { "07bc1340-5e8d-4237-a9e4-8e6b8ba56237", "07bc1990-5e8d-4237-a9e4-8e6b8ba56237" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "078a1ad8e-302a-4e75-a156-f997bb40d131", "078a1ad8e-302a-4e75-a156-f997bb40d131" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "596fd05b-7d8c-4c8d-aef1-c50dae89977a", "079a1rd8e-302a-4e75-a156-f997bb40d131" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "07bc1340-5e8d-4237-a9e4-8e6b8ba56237", "07bc1990-5e8d-4237-a9e4-8e6b8ba56237" });

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
        }
    }
}
