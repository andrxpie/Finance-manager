using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finance_manager.Migrations
{
    /// <inheritdoc />
    public partial class uow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarPicture", "Balance", "Email", "Login", "Password" },
                values: new object[] { 1, "media/avatars/default.jpg", 5325.6400000000003, "admin@web.com", "admin", "admin" });
        }
    }
}
