using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookingMasterAPI.Migrations
{
    /// <inheritdoc />
    public partial class Add_Uid_Ingredient_Category : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Uid",
                table: "IngredientCategories",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Uid",
                table: "IngredientCategories");
        }
    }
}
