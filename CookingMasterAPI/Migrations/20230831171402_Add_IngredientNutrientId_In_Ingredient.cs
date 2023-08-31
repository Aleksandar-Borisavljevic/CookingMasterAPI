using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookingMasterAPI.Migrations
{
    /// <inheritdoc />
    public partial class Add_IngredientNutrientId_In_Ingredient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientNutrients_Ingredients_IngredientId",
                table: "IngredientNutrients");

            migrationBuilder.DropIndex(
                name: "IX_IngredientNutrients_IngredientId",
                table: "IngredientNutrients");

            migrationBuilder.DropColumn(
                name: "IngredientId",
                table: "IngredientNutrients");

            migrationBuilder.AddColumn<int>(
                name: "IngredientNutrientId",
                table: "Ingredients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_IngredientNutrientId",
                table: "Ingredients",
                column: "IngredientNutrientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_IngredientNutrients_IngredientNutrientId",
                table: "Ingredients",
                column: "IngredientNutrientId",
                principalTable: "IngredientNutrients",
                principalColumn: "IngredientNutrientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_IngredientNutrients_IngredientNutrientId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_IngredientNutrientId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "IngredientNutrientId",
                table: "Ingredients");

            migrationBuilder.AddColumn<int>(
                name: "IngredientId",
                table: "IngredientNutrients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_IngredientNutrients_IngredientId",
                table: "IngredientNutrients",
                column: "IngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientNutrients_Ingredients_IngredientId",
                table: "IngredientNutrients",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "IngredientId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
