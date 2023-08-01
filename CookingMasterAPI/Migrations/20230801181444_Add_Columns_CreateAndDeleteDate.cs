using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookingMasterAPI.Migrations
{
    /// <inheritdoc />
    public partial class Add_Columns_CreateAndDeleteDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "IngredientCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "IngredientCategories",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "IngredientCategories");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "IngredientCategories");
        }
    }
}
