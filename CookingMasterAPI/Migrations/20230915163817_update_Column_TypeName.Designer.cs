﻿// <auto-generated />
using System;
using CookingMasterAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CookingMasterAPI.Migrations
{
    [DbContext(typeof(APIDbContext))]
    [Migration("20230915163817_update_Column_TypeName")]
    partial class update_Column_TypeName
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CookingMasterAPI.Models.Entity.CuisineType", b =>
                {
                    b.Property<int>("CuisineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CuisineId"));

                    b.Property<string>("CuisineName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Uid")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CuisineId");

                    b.ToTable("CuisineTypes");
                });

            modelBuilder.Entity("CookingMasterAPI.Models.Entity.CulinaryRecipe", b =>
                {
                    b.Property<int>("CulinaryRecipeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CulinaryRecipeId"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CuisineTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RecipeDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("RecipeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Uid")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CulinaryRecipeId");

                    b.HasIndex("CuisineTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("CulinaryRecipes");
                });

            modelBuilder.Entity("CookingMasterAPI.Models.Entity.Ingredient", b =>
                {
                    b.Property<int>("IngredientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IngredientId"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("IconPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("IngredientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("IngredientNutrientId")
                        .HasColumnType("int");

                    b.Property<string>("Uid")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IngredientId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("IngredientNutrientId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("CookingMasterAPI.Models.Entity.IngredientCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("IconPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Uid")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CategoryId");

                    b.ToTable("IngredientCategories");
                });

            modelBuilder.Entity("CookingMasterAPI.Models.Entity.IngredientNutrient", b =>
                {
                    b.Property<int>("IngredientNutrientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IngredientNutrientId"));

                    b.Property<decimal>("Calories")
                        .HasColumnType("decimal(6, 2)");

                    b.Property<decimal>("Carbohydrates")
                        .HasColumnType("decimal(6, 2)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Fat")
                        .HasColumnType("decimal(6, 2)");

                    b.Property<decimal>("Protein")
                        .HasColumnType("decimal(6, 2)");

                    b.Property<decimal>("Sugar")
                        .HasColumnType("decimal(6, 2)");

                    b.Property<string>("Uid")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IngredientNutrientId");

                    b.ToTable("IngredientNutrients");
                });

            modelBuilder.Entity("CookingMasterAPI.Models.Entity.RecipeIngredient", b =>
                {
                    b.Property<int>("RecipeIngredientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RecipeIngredientId"));

                    b.Property<int?>("CulinaryRecipeId")
                        .HasColumnType("int");

                    b.Property<int?>("IngredientId")
                        .HasColumnType("int");

                    b.HasKey("RecipeIngredientId");

                    b.HasIndex("CulinaryRecipeId");

                    b.HasIndex("IngredientId");

                    b.ToTable("RecipeIngredients");
                });

            modelBuilder.Entity("CookingMasterAPI.Models.Entity.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PasswordResetToken")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime?>("ResetTokenExpires")
                        .HasColumnType("datetime2");

                    b.Property<string>("Uid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("VerificationToken")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime?>("VerifiedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CookingMasterAPI.Models.Entity.UserIngredient", b =>
                {
                    b.Property<int>("UserIngredientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserIngredientId"));

                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UserIngredientId");

                    b.HasIndex("IngredientId");

                    b.HasIndex("UserId");

                    b.ToTable("UserIngredients");
                });

            modelBuilder.Entity("CookingMasterAPI.Models.Entity.CulinaryRecipe", b =>
                {
                    b.HasOne("CookingMasterAPI.Models.Entity.CuisineType", "CuisineType")
                        .WithMany()
                        .HasForeignKey("CuisineTypeId");

                    b.HasOne("CookingMasterAPI.Models.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("CuisineType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CookingMasterAPI.Models.Entity.Ingredient", b =>
                {
                    b.HasOne("CookingMasterAPI.Models.Entity.IngredientCategory", "IngredientCategory")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("CookingMasterAPI.Models.Entity.IngredientNutrient", "IngredientNutrient")
                        .WithMany()
                        .HasForeignKey("IngredientNutrientId");

                    b.Navigation("IngredientCategory");

                    b.Navigation("IngredientNutrient");
                });

            modelBuilder.Entity("CookingMasterAPI.Models.Entity.RecipeIngredient", b =>
                {
                    b.HasOne("CookingMasterAPI.Models.Entity.CulinaryRecipe", "CulinaryRecipe")
                        .WithMany()
                        .HasForeignKey("CulinaryRecipeId");

                    b.HasOne("CookingMasterAPI.Models.Entity.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId");

                    b.Navigation("CulinaryRecipe");

                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("CookingMasterAPI.Models.Entity.UserIngredient", b =>
                {
                    b.HasOne("CookingMasterAPI.Models.Entity.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CookingMasterAPI.Models.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
