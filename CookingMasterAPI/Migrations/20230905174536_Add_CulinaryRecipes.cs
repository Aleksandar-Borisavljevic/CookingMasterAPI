using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookingMasterAPI.Migrations
{
    /// <inheritdoc />
    public partial class Add_CulinaryRecipes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CuisineTypes",
                columns: table => new
                {
                    CuisineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CuisineName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuisineTypes", x => x.CuisineId);
                });

            migrationBuilder.CreateTable(
                name: "CulinaryRecipes",
                columns: table => new
                {
                    CulinaryRecipeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CuisineTypeId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    RecipeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Uid = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CulinaryRecipes", x => x.CulinaryRecipeId);
                    table.ForeignKey(
                        name: "FK_CulinaryRecipes_CuisineTypes_CuisineTypeId",
                        column: x => x.CuisineTypeId,
                        principalTable: "CuisineTypes",
                        principalColumn: "CuisineId");
                    table.ForeignKey(
                        name: "FK_CulinaryRecipes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredients",
                columns: table => new
                {
                    RecipeIngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CulinaryRecipeId = table.Column<int>(type: "int", nullable: true),
                    IngredientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredients", x => x.RecipeIngredientId);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_CulinaryRecipes_CulinaryRecipeId",
                        column: x => x.CulinaryRecipeId,
                        principalTable: "CulinaryRecipes",
                        principalColumn: "CulinaryRecipeId");
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CulinaryRecipes_CuisineTypeId",
                table: "CulinaryRecipes",
                column: "CuisineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CulinaryRecipes_UserId",
                table: "CulinaryRecipes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_CulinaryRecipeId",
                table: "RecipeIngredients",
                column: "CulinaryRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_IngredientId",
                table: "RecipeIngredients",
                column: "IngredientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeIngredients");

            migrationBuilder.DropTable(
                name: "CulinaryRecipes");

            migrationBuilder.DropTable(
                name: "CuisineTypes");
        }
    }
}
