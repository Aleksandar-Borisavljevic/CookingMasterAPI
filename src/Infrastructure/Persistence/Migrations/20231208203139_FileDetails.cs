using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookingMasterApi.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FileDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PictureUid",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FileDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Container = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileDetails", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: -6,
                column: "Uid",
                value: new Guid("826f9c44-57da-4e92-98d3-0a9fe1d00310"));

            migrationBuilder.UpdateData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: -5,
                column: "Uid",
                value: new Guid("e907af49-fa77-4acb-80e1-da01c8083df8"));

            migrationBuilder.UpdateData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: -4,
                column: "Uid",
                value: new Guid("5e567e88-b80f-45ee-9f7b-40899693b5ab"));

            migrationBuilder.UpdateData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: -3,
                column: "Uid",
                value: new Guid("b2a4be45-4a81-4716-8581-87760fc5e8a6"));

            migrationBuilder.UpdateData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: -2,
                column: "Uid",
                value: new Guid("d25e6705-bc62-4660-9cb2-369e07786f5d"));

            migrationBuilder.UpdateData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: -1,
                column: "Uid",
                value: new Guid("4524e06d-a4da-4a80-826d-4ef58d9d172b"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileDetails");

            migrationBuilder.DropColumn(
                name: "PictureUid",
                table: "AspNetUsers");

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
    }
}
