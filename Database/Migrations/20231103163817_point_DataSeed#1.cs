using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Finance_manager.Migrations
{
    /// <inheritdoc />
    public partial class point_DataSeed1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarPicture", "Balance", "Email", "Login", "Password" },
                values: new object[,]
                {
                    { 1, "media\\avatars\\default.jpg", 15000.0, "admin@finance.manager", "admin", "$2a$11$SE5dN37YdLiwcmWIgRwfpOxuvhMjD8xlBW08z9J58WaaLFzFgb6yW" },
                    { 2, "media\\avatars\\default.jpg", 15000.0, "admin@finance.manager", "123", "$2a$11$xaLu5fQiWJ3feYZ40ndy3O1YI9pnG5G6g8lgxfvL8iFmF27hVlIyy" }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "CategoryId", "DateTime", "IsCrediting", "Sum", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 11, 3, 18, 38, 17, 655, DateTimeKind.Local).AddTicks(3652), true, 5000, 1 },
                    { 2, 5, new DateTime(2023, 11, 3, 18, 38, 17, 655, DateTimeKind.Local).AddTicks(3656), false, 15000, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
