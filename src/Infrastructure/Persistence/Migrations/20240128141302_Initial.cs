using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CookingMasterApi.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PictureUid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CuisineTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CuisineName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuisineTypes", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "IngredientCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IconPath = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IngredientNutrients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Calories = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Protein = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Carbohydrates = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Sugar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientNutrients", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CulinaryRecipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecipeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CuisineTypeId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CulinaryRecipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CulinaryRecipes_CuisineTypes_CuisineTypeId",
                        column: x => x.CuisineTypeId,
                        principalTable: "CuisineTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientCategoryId = table.Column<int>(type: "int", nullable: false),
                    IngredientNutrientId = table.Column<int>(type: "int", nullable: false),
                    IngredientName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IconPath = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UnitOfMeasure = table.Column<short>(type: "smallint", nullable: false),
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredients_IngredientCategories_IngredientCategoryId",
                        column: x => x.IngredientCategoryId,
                        principalTable: "IngredientCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ingredients_IngredientNutrients_IngredientNutrientId",
                        column: x => x.IngredientNutrientId,
                        principalTable: "IngredientNutrients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CulinaryRecipeId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<short>(type: "smallint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_CulinaryRecipes_CulinaryRecipeId",
                        column: x => x.CulinaryRecipeId,
                        principalTable: "CulinaryRecipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CuisineTypes",
                columns: new[] { "Id", "Created", "CreatedBy", "CuisineName", "Deleted", "DeletedBy", "LastModified", "LastModifiedBy", "Uid" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 28, 15, 13, 2, 825, DateTimeKind.Local).AddTicks(6372), null, "Italian", null, null, null, null, new Guid("8125de54-f8fc-4d60-9d3f-cb5349fe9726") },
                    { 2, new DateTime(2024, 1, 28, 15, 13, 2, 825, DateTimeKind.Local).AddTicks(6428), null, "Indian", null, null, null, null, new Guid("9a89ff9d-f3a6-4cff-b0a5-fa00bc393331") },
                    { 3, new DateTime(2024, 1, 28, 15, 13, 2, 825, DateTimeKind.Local).AddTicks(6440), null, "Mexican", null, null, null, null, new Guid("59e0cccd-a6da-43fa-85c3-abcf33c0d2f0") },
                    { 4, new DateTime(2024, 1, 28, 15, 13, 2, 825, DateTimeKind.Local).AddTicks(6443), null, "Chinese", null, null, null, null, new Guid("17107db8-e911-41b2-8d2f-ddd163008d02") },
                    { 5, new DateTime(2024, 1, 28, 15, 13, 2, 825, DateTimeKind.Local).AddTicks(6445), null, "French", null, null, null, null, new Guid("6da29d71-cf69-40fa-ba71-2d74d32713ea") },
                    { 6, new DateTime(2024, 1, 28, 15, 13, 2, 825, DateTimeKind.Local).AddTicks(6448), null, "Thai", null, null, null, null, new Guid("03f2c3e1-42fd-487b-b757-db6abee9f6ca") }
                });

            migrationBuilder.InsertData(
                table: "IngredientCategories",
                columns: new[] { "Id", "CategoryName", "Created", "CreatedBy", "Deleted", "DeletedBy", "IconPath", "LastModified", "LastModifiedBy", "Uid" },
                values: new object[,]
                {
                    { 1, "Fruit", new DateTime(2024, 1, 28, 15, 13, 2, 825, DateTimeKind.Local).AddTicks(6651), null, null, null, "fruit", null, null, new Guid("3d37ed57-e8c6-4bd1-8dfd-5959129a9886") },
                    { 2, "Vegetables", new DateTime(2024, 1, 28, 15, 13, 2, 825, DateTimeKind.Local).AddTicks(6655), null, null, null, "vegetables", null, null, new Guid("de0ea465-6851-4a7f-8dcd-7b974b330ce0") },
                    { 3, "Spices", new DateTime(2024, 1, 28, 15, 13, 2, 825, DateTimeKind.Local).AddTicks(6658), null, null, null, "spices", null, null, new Guid("85670ea6-3e1b-4c99-889d-9f882b8b1553") },
                    { 4, "Meat", new DateTime(2024, 1, 28, 15, 13, 2, 825, DateTimeKind.Local).AddTicks(6660), null, null, null, "meat", null, null, new Guid("0ca4cc51-42a2-46a5-990e-483ed1c4134f") },
                    { 5, "Seafood", new DateTime(2024, 1, 28, 15, 13, 2, 825, DateTimeKind.Local).AddTicks(6664), null, null, null, "seafood", null, null, new Guid("ae7c070a-2206-4e8a-9315-6052cc162c11") },
                    { 6, "Cereals", new DateTime(2024, 1, 28, 15, 13, 2, 825, DateTimeKind.Local).AddTicks(6667), null, null, null, "cereals", null, null, new Guid("55b5d5a1-e45b-4a95-8c73-34bee3a12a2d") },
                    { 7, "Dairy Product", new DateTime(2024, 1, 28, 15, 13, 2, 825, DateTimeKind.Local).AddTicks(6669), null, null, null, "dairyproduct", null, null, new Guid("0dac3bb8-b7d3-421a-83d2-f626934f1291") },
                    { 8, "Nuts", new DateTime(2024, 1, 28, 15, 13, 2, 825, DateTimeKind.Local).AddTicks(6672), null, null, null, "nuts", null, null, new Guid("1090be03-888c-4d03-9ad9-0b6ca28fc987") },
                    { 9, "Other", new DateTime(2024, 1, 28, 15, 13, 2, 825, DateTimeKind.Local).AddTicks(6676), null, null, null, "other", null, null, new Guid("8817fcbd-d9aa-407c-b97b-f66bb083f174") }
                });

            migrationBuilder.InsertData(
                table: "IngredientNutrients",
                columns: new[] { "Id", "Calories", "Carbohydrates", "Created", "CreatedBy", "Deleted", "DeletedBy", "Fat", "LastModified", "LastModifiedBy", "Protein", "Sugar", "Uid" },
                values: new object[] { 1, 105m, 27m, new DateTime(2024, 1, 28, 15, 13, 2, 825, DateTimeKind.Local).AddTicks(6708), null, null, null, 1m, null, null, 1.3m, 14m, new Guid("0715af36-1e62-40ce-91cb-955b9d921d32") });

            migrationBuilder.InsertData(
                table: "CulinaryRecipes",
                columns: new[] { "Id", "Created", "CreatedBy", "CuisineTypeId", "Deleted", "DeletedBy", "LastModified", "LastModifiedBy", "RecipeDescription", "RecipeName", "Uid", "UserId" },
                values: new object[] { 1, new DateTime(2024, 1, 28, 15, 13, 2, 825, DateTimeKind.Local).AddTicks(6763), null, 1, null, null, null, null, "Instructions:\r\n\r\nCook the spaghetti according to package instructions. Drain and set aside.\r\n\r\nIn a large pan, heat olive oil over medium heat. Add the chopped onion and sauté until softened.\r\n\r\nAdd minced garlic to the pan and sauté for another 1-2 minutes until fragrant.\r\n\r\nAdd ground beef to the pan and cook until browned, breaking it apart with a spoon as it cooks.\r\n\r\nStir in grated carrots and chopped celery. Cook for a few minutes until the vegetables begin to soften.\r\n\r\nAdd crushed tomatoes, tomato paste, dried oregano, and dried basil to the pan. Season with salt and pepper to taste. Stir well to combine.\r\n\r\nReduce the heat to low, cover the pan, and let the sauce simmer for at least 20-30 minutes to allow the flavors to meld.\r\n\r\nTaste and adjust the seasoning if necessary.\r\n\r\nServe the Bolognese sauce over the cooked spaghetti.\r\n\r\nOptionally, garnish with grated Parmesan cheese and fresh basil or parsley.\r\n\r\nEnjoy your homemade Spaghetti Bolognese! Feel free to customize the recipe based on your preferences.", "Spaghetti Bolognese", new Guid("45221af4-6a80-4a27-b933-042117ec83c5"), null });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Created", "CreatedBy", "Deleted", "DeletedBy", "IconPath", "IngredientCategoryId", "IngredientName", "IngredientNutrientId", "LastModified", "LastModifiedBy", "Uid", "UnitOfMeasure" },
                values: new object[] { 1, new DateTime(2024, 1, 28, 15, 13, 2, 825, DateTimeKind.Local).AddTicks(6737), null, null, null, "banana", 1, "Banana", 1, null, null, new Guid("c5609129-5bcc-43a5-a0c9-59836d0fe6a4"), (short)0 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "Amount", "Created", "CreatedBy", "CulinaryRecipeId", "Deleted", "DeletedBy", "IngredientId", "LastModified", "LastModifiedBy" },
                values: new object[] { 1, (short)0, new DateTime(2024, 1, 28, 15, 13, 2, 825, DateTimeKind.Local).AddTicks(6781), null, 1, null, null, 1, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CulinaryRecipes_CuisineTypeId",
                table: "CulinaryRecipes",
                column: "CuisineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_IngredientCategoryId",
                table: "Ingredients",
                column: "IngredientCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_IngredientNutrientId",
                table: "Ingredients",
                column: "IngredientNutrientId");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "FileDetails");

            migrationBuilder.DropTable(
                name: "RecipeIngredients");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CulinaryRecipes");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "CuisineTypes");

            migrationBuilder.DropTable(
                name: "IngredientCategories");

            migrationBuilder.DropTable(
                name: "IngredientNutrients");
        }
    }
}
