using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace babyShield.Migrations
{
    /// <inheritdoc />
    public partial class alsoAddApplicationUserForManager : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "managers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_managers_ApplicationUserId",
                table: "managers",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_managers_AspNetUsers_ApplicationUserId",
                table: "managers",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_managers_AspNetUsers_ApplicationUserId",
                table: "managers");

            migrationBuilder.DropIndex(
                name: "IX_managers_ApplicationUserId",
                table: "managers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "managers");
        }
    }
}
