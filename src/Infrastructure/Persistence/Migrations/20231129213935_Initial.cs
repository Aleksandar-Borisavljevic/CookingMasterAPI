using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookingMasterApi.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_IngredientCategories_IngredientCategoryId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_IngredientNutrients_IngredientNutrientId",
                table: "Ingredients");

            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                table: "Ingredients",
                newName: "LastModified");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Ingredients",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "IngredientId",
                table: "Ingredients",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                table: "IngredientNutrients",
                newName: "LastModified");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "IngredientNutrients",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "IngredientNutrientId",
                table: "IngredientNutrients",
                newName: "Id");

            migrationBuilder.AlterColumn<Guid>(
                name: "Uid",
                table: "Ingredients",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IngredientNutrientId",
                table: "Ingredients",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IngredientName",
                table: "Ingredients",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IngredientCategoryId",
                table: "Ingredients",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IconPath",
                table: "Ingredients",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Ingredients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Deleted",
                table: "Ingredients",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Ingredients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Ingredients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Uid",
                table: "IngredientNutrients",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "IngredientNutrients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Deleted",
                table: "IngredientNutrients",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "IngredientNutrients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "IngredientNutrients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: -6,
                column: "Uid",
                value: new Guid("854a877a-05dd-4d76-a6ce-10b8e3ce8196"));

            migrationBuilder.UpdateData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: -5,
                column: "Uid",
                value: new Guid("d2c99c99-2afe-4070-a07c-5e4d59995551"));

            migrationBuilder.UpdateData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: -4,
                column: "Uid",
                value: new Guid("d840b4dc-1cb5-4f62-9321-68d13f002308"));

            migrationBuilder.UpdateData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: -3,
                column: "Uid",
                value: new Guid("9eb20dff-b541-48bb-a9e2-e94e6b411dcf"));

            migrationBuilder.UpdateData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: -2,
                column: "Uid",
                value: new Guid("fd846694-f76c-49e6-9502-7515c87ddc39"));

            migrationBuilder.UpdateData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: -1,
                column: "Uid",
                value: new Guid("68182175-ce37-4432-954a-22414308f401"));

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_IngredientCategories_IngredientCategoryId",
                table: "Ingredients",
                column: "IngredientCategoryId",
                principalTable: "IngredientCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_IngredientNutrients_IngredientNutrientId",
                table: "Ingredients",
                column: "IngredientNutrientId",
                principalTable: "IngredientNutrients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_IngredientCategories_IngredientCategoryId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_IngredientNutrients_IngredientNutrientId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "IngredientNutrients");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "IngredientNutrients");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "IngredientNutrients");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "IngredientNutrients");

            migrationBuilder.RenameColumn(
                name: "LastModified",
                table: "Ingredients",
                newName: "DeleteDate");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Ingredients",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Ingredients",
                newName: "IngredientId");

            migrationBuilder.RenameColumn(
                name: "LastModified",
                table: "IngredientNutrients",
                newName: "DeleteDate");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "IngredientNutrients",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "IngredientNutrients",
                newName: "IngredientNutrientId");

            migrationBuilder.AlterColumn<string>(
                name: "Uid",
                table: "Ingredients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "IngredientNutrientId",
                table: "Ingredients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "IngredientName",
                table: "Ingredients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "IngredientCategoryId",
                table: "Ingredients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "IconPath",
                table: "Ingredients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Uid",
                table: "IngredientNutrients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: -6,
                column: "Uid",
                value: new Guid("c5be35e5-40cd-4a33-b790-135aac0668e2"));

            migrationBuilder.UpdateData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: -5,
                column: "Uid",
                value: new Guid("ad42ca3f-204c-4f2b-867a-c9eeff9b49d3"));

            migrationBuilder.UpdateData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: -4,
                column: "Uid",
                value: new Guid("55c4a784-1477-454e-a827-1dd6ce96fdc5"));

            migrationBuilder.UpdateData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: -3,
                column: "Uid",
                value: new Guid("64f77680-e1c1-47bf-a1f1-24663c5463f4"));

            migrationBuilder.UpdateData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: -2,
                column: "Uid",
                value: new Guid("8e06bb83-f3c0-4e87-b52e-bade2f0a656d"));

            migrationBuilder.UpdateData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: -1,
                column: "Uid",
                value: new Guid("6380d8a6-57f3-41df-8264-fbcd4f3db12c"));

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_IngredientCategories_IngredientCategoryId",
                table: "Ingredients",
                column: "IngredientCategoryId",
                principalTable: "IngredientCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_IngredientNutrients_IngredientNutrientId",
                table: "Ingredients",
                column: "IngredientNutrientId",
                principalTable: "IngredientNutrients",
                principalColumn: "IngredientNutrientId");
        }
    }
}
