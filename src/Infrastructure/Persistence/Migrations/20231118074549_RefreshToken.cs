using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookingMasterApi.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: -6,
                column: "Uid",
                value: new Guid("78dda4bc-5ecf-40ae-9d3f-eabd811e2409"));

            migrationBuilder.UpdateData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: -5,
                column: "Uid",
                value: new Guid("ae76553f-f3de-4af0-a48d-c469519f1e01"));

            migrationBuilder.UpdateData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: -4,
                column: "Uid",
                value: new Guid("d63bcc55-4d4e-4f3a-b8bf-ce820d05b139"));

            migrationBuilder.UpdateData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: -3,
                column: "Uid",
                value: new Guid("c065d8c6-609f-418f-a9ee-a05c7d01a4f0"));

            migrationBuilder.UpdateData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: -2,
                column: "Uid",
                value: new Guid("ceb478d1-386e-4f40-8e12-679e0d54261e"));

            migrationBuilder.UpdateData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: -1,
                column: "Uid",
                value: new Guid("144a414c-a67f-44c8-b4a5-0ac7150c9d6b"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.UpdateData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: -6,
                column: "Uid",
                value: new Guid("7eb88233-31a3-4a3e-a79b-519354391d9f"));

            migrationBuilder.UpdateData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: -5,
                column: "Uid",
                value: new Guid("92e8bd0c-658e-46bb-887d-9cd92b14dadd"));

            migrationBuilder.UpdateData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: -4,
                column: "Uid",
                value: new Guid("f58fcad6-d439-4482-883d-bde98f41724a"));

            migrationBuilder.UpdateData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: -3,
                column: "Uid",
                value: new Guid("00067402-037a-40b1-9aeb-c279640d06b0"));

            migrationBuilder.UpdateData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: -2,
                column: "Uid",
                value: new Guid("50a6e701-0aa7-4fa2-9640-36fbb549f375"));

            migrationBuilder.UpdateData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: -1,
                column: "Uid",
                value: new Guid("5b6f9e62-f040-4fcc-a835-a5b927df4352"));
        }
    }
}
