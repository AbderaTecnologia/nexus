using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nexus.Cadastro.Infra.Migrations
{
    /// <inheritdoc />
    public partial class resolveerror : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Address_AddressId1",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_AddressId1",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "AddressId1",
                table: "Companies");

            migrationBuilder.CreateIndex(
                name: "IX_Address_CompanyId",
                table: "Address",
                column: "CompanyId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Companies_CompanyId",
                table: "Address",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Companies_CompanyId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_CompanyId",
                table: "Address");

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "Companies",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId1",
                table: "Companies",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Companies_AddressId1",
                table: "Companies",
                column: "AddressId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Address_AddressId1",
                table: "Companies",
                column: "AddressId1",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
