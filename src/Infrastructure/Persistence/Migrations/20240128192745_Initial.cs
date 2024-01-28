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
                    { 1, new DateTime(2024, 1, 28, 20, 27, 45, 605, DateTimeKind.Local).AddTicks(2037), null, "Italian", null, null, null, null, new Guid("e18ab0bd-4889-4615-8796-363b1a1f3838") },
                    { 2, new DateTime(2024, 1, 28, 20, 27, 45, 605, DateTimeKind.Local).AddTicks(2091), null, "Indian", null, null, null, null, new Guid("27017c68-053d-4ad6-ba91-9653466462a4") },
                    { 3, new DateTime(2024, 1, 28, 20, 27, 45, 605, DateTimeKind.Local).AddTicks(2094), null, "Mexican", null, null, null, null, new Guid("a8790222-9edc-4796-bb6b-d117b2916378") },
                    { 4, new DateTime(2024, 1, 28, 20, 27, 45, 605, DateTimeKind.Local).AddTicks(2102), null, "Chinese", null, null, null, null, new Guid("1edea285-089b-425d-9e73-7a4202db7127") },
                    { 5, new DateTime(2024, 1, 28, 20, 27, 45, 605, DateTimeKind.Local).AddTicks(2105), null, "French", null, null, null, null, new Guid("5f7b9e1c-8304-416f-b5c1-24b6f5e2ed08") },
                    { 6, new DateTime(2024, 1, 28, 20, 27, 45, 605, DateTimeKind.Local).AddTicks(2108), null, "Thai", null, null, null, null, new Guid("60d96b46-7894-4895-b7a8-63847ec2798f") }
                });

            migrationBuilder.InsertData(
                table: "IngredientCategories",
                columns: new[] { "Id", "CategoryName", "Created", "CreatedBy", "Deleted", "DeletedBy", "IconPath", "LastModified", "LastModifiedBy", "Uid" },
                values: new object[,]
                {
                    { 1, "Fruit", new DateTime(2024, 1, 28, 20, 27, 45, 605, DateTimeKind.Local).AddTicks(2285), null, null, null, "fruit", null, null, new Guid("94fefa39-648e-43f3-8f8b-1ec382123da5") },
                    { 2, "Vegetables", new DateTime(2024, 1, 28, 20, 27, 45, 605, DateTimeKind.Local).AddTicks(2292), null, null, null, "vegetables", null, null, new Guid("448f871e-063d-4bc8-bca6-27c26c326eb8") },
                    { 3, "Spices", new DateTime(2024, 1, 28, 20, 27, 45, 605, DateTimeKind.Local).AddTicks(2295), null, null, null, "spices", null, null, new Guid("1d03cf87-a71d-42f6-8267-40c054787b27") },
                    { 4, "Meat", new DateTime(2024, 1, 28, 20, 27, 45, 605, DateTimeKind.Local).AddTicks(2298), null, null, null, "meat", null, null, new Guid("c13ef27e-2353-468f-9854-971cdb4afb70") },
                    { 5, "Seafood", new DateTime(2024, 1, 28, 20, 27, 45, 605, DateTimeKind.Local).AddTicks(2300), null, null, null, "seafood", null, null, new Guid("4b35a85c-1287-4253-8999-4a26dcccc82d") },
                    { 6, "Cereals", new DateTime(2024, 1, 28, 20, 27, 45, 605, DateTimeKind.Local).AddTicks(2304), null, null, null, "cereals", null, null, new Guid("e9522658-3dc0-42b5-a153-d1fd5e4dfd1f") },
                    { 7, "Dairy Product", new DateTime(2024, 1, 28, 20, 27, 45, 605, DateTimeKind.Local).AddTicks(2307), null, null, null, "dairyproduct", null, null, new Guid("f1f9b9ef-f12a-48c2-bad2-5fb3fb0e7fde") },
                    { 8, "Nuts", new DateTime(2024, 1, 28, 20, 27, 45, 605, DateTimeKind.Local).AddTicks(2310), null, null, null, "nuts", null, null, new Guid("161f06f0-4772-4695-8ba3-d35374fd57b1") },
                    { 9, "Other", new DateTime(2024, 1, 28, 20, 27, 45, 605, DateTimeKind.Local).AddTicks(2312), null, null, null, "other", null, null, new Guid("8c9b4758-c669-4246-bca2-b9958218df81") }
                });

            migrationBuilder.InsertData(
                table: "IngredientNutrients",
                columns: new[] { "Id", "Calories", "Carbohydrates", "Created", "CreatedBy", "Deleted", "DeletedBy", "Fat", "LastModified", "LastModifiedBy", "Protein", "Sugar", "Uid" },
                values: new object[,]
                {
                    { 1, 105m, 27m, new DateTime(2024, 1, 28, 20, 27, 45, 605, DateTimeKind.Local).AddTicks(2348), null, null, null, 1m, null, null, 1.3m, 14m, new Guid("d8eda04a-3f98-4e65-89b4-a5cb3fad4acc") },
                    { 2, 18m, 3.9m, new DateTime(2024, 1, 28, 20, 27, 45, 605, DateTimeKind.Local).AddTicks(2352), null, null, null, 0.2m, null, null, 0.9m, 2.6m, new Guid("925b3c5e-58c2-4c66-afc9-2629220fe0fd") },
                    { 3, 29m, 9.3m, new DateTime(2024, 1, 28, 20, 27, 45, 605, DateTimeKind.Local).AddTicks(2379), null, null, null, 0.3m, null, null, 1.1m, 2.5m, new Guid("9c125d9b-ca69-4335-98af-2cf3185ed478") },
                    { 4, 23m, 2.7m, new DateTime(2024, 1, 28, 20, 27, 45, 605, DateTimeKind.Local).AddTicks(2383), null, null, null, 0.6m, null, null, 3.2m, 0.3m, new Guid("0f306817-5243-47cb-bbed-fc80b67473b4") },
                    { 5, 40m, 8.8m, new DateTime(2024, 1, 28, 20, 27, 45, 605, DateTimeKind.Local).AddTicks(2389), null, null, null, 0.4m, null, null, 1.9m, 5.3m, new Guid("209634e6-f892-4283-a850-8f9f43eb2840") }
                });

            migrationBuilder.InsertData(
                table: "CulinaryRecipes",
                columns: new[] { "Id", "Created", "CreatedBy", "CuisineTypeId", "Deleted", "DeletedBy", "LastModified", "LastModifiedBy", "RecipeDescription", "RecipeName", "Uid", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 28, 20, 27, 45, 605, DateTimeKind.Local).AddTicks(2453), null, 1, null, null, null, null, "Instructions:\r\n\r\nCook the spaghetti according to package instructions. Drain and set aside.\r\n\r\nIn a large pan, heat olive oil over medium heat. Add the chopped onion and sauté until softened.\r\n\r\nAdd minced garlic to the pan and sauté for another 1-2 minutes until fragrant.\r\n\r\nAdd ground beef to the pan and cook until browned, breaking it apart with a spoon as it cooks.\r\n\r\nStir in grated carrots and chopped celery. Cook for a few minutes until the vegetables begin to soften.\r\n\r\nAdd crushed tomatoes, tomato paste, dried oregano, and dried basil to the pan. Season with salt and pepper to taste. Stir well to combine.\r\n\r\nReduce the heat to low, cover the pan, and let the sauce simmer for at least 20-30 minutes to allow the flavors to meld.\r\n\r\nTaste and adjust the seasoning if necessary.\r\n\r\nServe the Bolognese sauce over the cooked spaghetti.\r\n\r\nOptionally, garnish with grated Parmesan cheese and fresh basil or parsley.\r\n\r\nEnjoy your homemade Spaghetti Bolognese! Feel free to customize the recipe based on your preferences.", "Spaghetti Bolognese", new Guid("c182a84c-9e35-4214-9994-5c4cd61c4d7a"), null },
                    { 2, new DateTime(2024, 1, 28, 20, 27, 45, 605, DateTimeKind.Local).AddTicks(2457), null, 1, null, null, null, null, "Preheat the Oven:\r\nPreheat your oven to the temperature recommended for your pizza dough (usually around 450°F or 230°C).\r\n\r\nPrepare the Pizza Dough:\r\nIf using store-bought dough, follow the instructions on the package. If making homemade dough, roll it out on a floured surface to your desired thickness.\r\n\r\nAssemble the Pizza:\r\nPlace the rolled-out pizza dough on a pizza stone or baking sheet. Drizzle a bit of olive oil over the dough. Spread a thin layer of tomato sauce over the dough, leaving a border around the edges.\r\n\r\nAdd Cheese and Basil:\r\nArrange slices of fresh mozzarella evenly over the sauce. Tear fresh basil leaves and scatter them over the cheese. Season with salt and pepper to taste. Optionally, sprinkle grated Parmesan cheese on top.\r\n\r\nBake in the Oven:\r\nTransfer the pizza to the preheated oven and bake according to the dough's instructions or until the crust is golden and the cheese is melted and bubbly.\r\n\r\nServe:\r\nOnce the pizza is out of the oven, let it cool for a few minutes before slicing. Serve hot and enjoy your homemade Margherita Pizza!\r\n\r\nFeel free to customize the recipe to your liking. Margherita Pizza is known for its simplicity and fresh flavors, making it a delicious and classic choice.", "Margherita Pizza", new Guid("89330a5c-24d7-4574-bcf7-bdbf179dea9a"), null }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Created", "CreatedBy", "Deleted", "DeletedBy", "IconPath", "IngredientCategoryId", "IngredientName", "IngredientNutrientId", "LastModified", "LastModifiedBy", "Uid", "UnitOfMeasure" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 28, 20, 27, 45, 605, DateTimeKind.Local).AddTicks(2418), null, null, null, "banana", 1, "Banana", 1, null, null, new Guid("9925c82c-08d6-4cda-ab78-527b905d5283"), (short)0 },
                    { 2, new DateTime(2024, 1, 28, 20, 27, 45, 605, DateTimeKind.Local).AddTicks(2421), null, null, null, "tomato", 2, "Tomato", 2, null, null, new Guid("2f949a3b-1ae4-4049-9650-8789c14dd55e"), (short)0 },
                    { 3, new DateTime(2024, 1, 28, 20, 27, 45, 605, DateTimeKind.Local).AddTicks(2424), null, null, null, "lemon", 1, "Lemon", 3, null, null, new Guid("a5479865-abb5-46e7-8760-434019083234"), (short)0 },
                    { 4, new DateTime(2024, 1, 28, 20, 27, 45, 605, DateTimeKind.Local).AddTicks(2429), null, null, null, "basil", 3, "Basil", 4, null, null, new Guid("332880f7-b13e-40bd-934a-3023eb918f44"), (short)0 },
                    { 5, new DateTime(2024, 1, 28, 20, 27, 45, 605, DateTimeKind.Local).AddTicks(2432), null, null, null, "redchilipapper", 2, "Red Chili Papper", 5, null, null, new Guid("5bc7e4d7-ed70-4e23-97d1-6f530515666b"), (short)0 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "Amount", "Created", "CreatedBy", "CulinaryRecipeId", "Deleted", "DeletedBy", "IngredientId", "LastModified", "LastModifiedBy" },
                values: new object[,]
                {
                    { 1, (short)0, new DateTime(2024, 1, 28, 20, 27, 45, 605, DateTimeKind.Local).AddTicks(2475), null, 1, null, null, 1, null, null },
                    { 2, (short)0, new DateTime(2024, 1, 28, 20, 27, 45, 605, DateTimeKind.Local).AddTicks(2477), null, 2, null, null, 2, null, null },
                    { 3, (short)0, new DateTime(2024, 1, 28, 20, 27, 45, 605, DateTimeKind.Local).AddTicks(2479), null, 2, null, null, 4, null, null },
                    { 4, (short)0, new DateTime(2024, 1, 28, 20, 27, 45, 605, DateTimeKind.Local).AddTicks(2481), null, 2, null, null, 5, null, null }
                });

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
