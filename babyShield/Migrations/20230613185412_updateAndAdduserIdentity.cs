using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace babyShield.Migrations
{
    /// <inheritdoc />
    public partial class updateAndAdduserIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "phoneNumber",
                table: "patients",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "phoneNumber",
                table: "doctors",
                newName: "PhoneNumber");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "receptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "receptions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "receptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "receptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "receptions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "receptions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "receptions",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "receptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "receptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "receptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "receptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "receptions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "receptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "receptions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "receptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "patients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "patients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "patients",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "patients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "patients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "patients",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "patients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "patients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "doctors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "doctors",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "doctors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "doctors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "doctors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "doctors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "doctors",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "doctors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "doctors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "doctors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "doctors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "doctors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "doctors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "doctors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "admins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "admins",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "admins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "admins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "admins",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "admins",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "admins",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "admins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "admins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "admins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "admins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "admins",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "admins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "admins",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "admins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_receptions_ApplicationUserId",
                table: "receptions",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_patients_ApplicationUserId",
                table: "patients",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_doctors_ApplicationUserId",
                table: "doctors",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_admins_ApplicationUserId",
                table: "admins",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_admins_AspNetUsers_ApplicationUserId",
                table: "admins",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_doctors_AspNetUsers_ApplicationUserId",
                table: "doctors",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_patients_AspNetUsers_ApplicationUserId",
                table: "patients",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_receptions_AspNetUsers_ApplicationUserId",
                table: "receptions",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_admins_AspNetUsers_ApplicationUserId",
                table: "admins");

            migrationBuilder.DropForeignKey(
                name: "FK_doctors_AspNetUsers_ApplicationUserId",
                table: "doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_patients_AspNetUsers_ApplicationUserId",
                table: "patients");

            migrationBuilder.DropForeignKey(
                name: "FK_receptions_AspNetUsers_ApplicationUserId",
                table: "receptions");

            migrationBuilder.DropIndex(
                name: "IX_receptions_ApplicationUserId",
                table: "receptions");

            migrationBuilder.DropIndex(
                name: "IX_patients_ApplicationUserId",
                table: "patients");

            migrationBuilder.DropIndex(
                name: "IX_doctors_ApplicationUserId",
                table: "doctors");

            migrationBuilder.DropIndex(
                name: "IX_admins_ApplicationUserId",
                table: "admins");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "receptions");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "receptions");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "receptions");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "receptions");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "receptions");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "receptions");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "receptions");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "receptions");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "receptions");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "receptions");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "receptions");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "receptions");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "receptions");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "receptions");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "receptions");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "patients");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "patients");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "patients");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "patients");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "patients");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "patients");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "patients");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "patients");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "patients");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "patients");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "patients");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "patients");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "patients");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "patients");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "doctors");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "doctors");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "doctors");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "doctors");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "doctors");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "doctors");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "doctors");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "doctors");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "doctors");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "doctors");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "doctors");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "doctors");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "doctors");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "doctors");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "admins");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "admins");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "admins");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "admins");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "admins");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "admins");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "admins");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "admins");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "admins");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "admins");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "admins");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "admins");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "admins");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "admins");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "admins");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "patients",
                newName: "phoneNumber");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "doctors",
                newName: "phoneNumber");

            migrationBuilder.AlterColumn<int>(
                name: "phoneNumber",
                table: "patients",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "phoneNumber",
                table: "doctors",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
