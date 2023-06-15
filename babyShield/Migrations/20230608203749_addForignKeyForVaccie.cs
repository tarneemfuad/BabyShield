using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace babyShield.Migrations
{
    /// <inheritdoc />
    public partial class addForignKeyForVaccie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_patientVaccines_vaccineId",
                table: "patientVaccines",
                column: "vaccineId");

            migrationBuilder.AddForeignKey(
                name: "FK_patientVaccines_vaccines_vaccineId",
                table: "patientVaccines",
                column: "vaccineId",
                principalTable: "vaccines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_patientVaccines_vaccines_vaccineId",
                table: "patientVaccines");

            migrationBuilder.DropIndex(
                name: "IX_patientVaccines_vaccineId",
                table: "patientVaccines");
        }
    }
}
