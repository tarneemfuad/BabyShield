using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace babyShield.Migrations
{
    /// <inheritdoc />
    public partial class addPrescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "prescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    patientId = table.Column<int>(type: "int", nullable: false),
                    medicalCondition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    medication = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dosage = table.Column<int>(type: "int", nullable: false),
                    frequency = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_prescriptions_patients_patientId",
                        column: x => x.patientId,
                        principalTable: "patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_prescriptions_patientId",
                table: "prescriptions",
                column: "patientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "prescriptions");
        }
    }
}
