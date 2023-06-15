using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace babyShield.Migrations
{
    /// <inheritdoc />
    public partial class delAnAddAlergy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "allergy",
                table: "patients");

            migrationBuilder.AddColumn<string>(
                name: "Allergy",
                table: "patientVaccines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Allergy",
                table: "patientVaccines");

            migrationBuilder.AddColumn<string>(
                name: "allergy",
                table: "patients",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
