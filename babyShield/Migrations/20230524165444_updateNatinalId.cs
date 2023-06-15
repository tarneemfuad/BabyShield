using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace babyShield.Migrations
{
    /// <inheritdoc />
    public partial class updateNatinalId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_admin",
                table: "admin");

            migrationBuilder.RenameTable(
                name: "admin",
                newName: "admins");

            migrationBuilder.AlterColumn<long>(
                name: "nationalId",
                table: "receptions",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "nationalId",
                table: "patients",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "nationalId",
                table: "managers",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "nationalId",
                table: "doctors",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "nationalId",
                table: "admins",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_admins",
                table: "admins",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_admins",
                table: "admins");

            migrationBuilder.RenameTable(
                name: "admins",
                newName: "admin");

            migrationBuilder.AlterColumn<int>(
                name: "nationalId",
                table: "receptions",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "nationalId",
                table: "patients",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "nationalId",
                table: "managers",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "nationalId",
                table: "doctors",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "nationalId",
                table: "admin",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddPrimaryKey(
                name: "PK_admin",
                table: "admin",
                column: "Id");
        }
    }
}
