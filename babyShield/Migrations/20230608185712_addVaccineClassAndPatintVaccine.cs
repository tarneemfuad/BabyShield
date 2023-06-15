using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace babyShield.Migrations
{
    /// <inheritdoc />
    public partial class addVaccineClassAndPatintVaccine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "patientVaccines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vaccineId = table.Column<int>(type: "int", nullable: false),
                    vaccineDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    width = table.Column<int>(type: "int", nullable: false),
                    hight = table.Column<int>(type: "int", nullable: false),
                    headRadios = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patientVaccines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_patientVaccines_patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vaccines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vaccineName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vaccineCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    doesNumber = table.Column<int>(type: "int", nullable: false),
                    RecomendAge = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vaccines", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_patientVaccines_PatientId",
                table: "patientVaccines",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "patientVaccines");

            migrationBuilder.DropTable(
                name: "vaccines");
        }
    }
}
