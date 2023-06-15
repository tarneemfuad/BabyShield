using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace babyShield.Migrations
{
    /// <inheritdoc />
    public partial class addisFreaze : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isFreaze",
                table: "clinics",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isFreaze",
                table: "clinics");
        }
    }
}
