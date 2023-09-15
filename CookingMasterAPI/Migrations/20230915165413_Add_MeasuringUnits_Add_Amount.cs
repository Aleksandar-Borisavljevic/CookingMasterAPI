using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookingMasterAPI.Migrations
{
    /// <inheritdoc />
    public partial class Add_MeasuringUnits_Add_Amount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "Amount",
                table: "RecipeIngredients",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "UnitOfMeasure",
                table: "Ingredients",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "RecipeIngredients");

            migrationBuilder.DropColumn(
                name: "UnitOfMeasure",
                table: "Ingredients");
        }
    }
}
