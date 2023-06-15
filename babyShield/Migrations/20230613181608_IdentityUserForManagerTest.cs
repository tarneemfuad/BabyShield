using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace babyShield.Migrations
{
    /// <inheritdoc />
    public partial class IdentityUserForManagerTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "managers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "managers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "managers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "managers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "managers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "managers",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "managers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "managers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "managers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "managers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "managers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "managers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "managers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "managers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "managers");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "managers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "managers");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "managers");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "managers");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "managers");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "managers");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "managers");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "managers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "managers");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "managers");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "managers");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "managers");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "managers");
        }
    }
}
