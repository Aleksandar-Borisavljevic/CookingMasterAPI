﻿// <auto-generated />
using System;
using CookingMasterAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CookingMasterAPI.Migrations
{
    [DbContext(typeof(APIDbContext))]
    partial class APIDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

                    b.Property<string>("Uid")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IngredientId");

                    b.HasIndex("CategoryId");

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
                        .HasColumnType("decimal(4, 2)");

                    b.Property<decimal>("Carbohydrates")
                        .HasColumnType("decimal(4, 2)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Fat")
                        .HasColumnType("decimal(4, 2)");

                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.Property<decimal>("Protein")
                        .HasColumnType("decimal(4, 2)");

                    b.Property<decimal>("Sugar")
                        .HasColumnType("decimal(4, 2)");

                    b.Property<string>("Uid")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IngredientNutrientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("IngredientNutrients");
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

            modelBuilder.Entity("CookingMasterAPI.Models.Entity.Ingredient", b =>
                {
                    b.HasOne("CookingMasterAPI.Models.Entity.IngredientCategory", "IngredientCategory")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.Navigation("IngredientCategory");
                });

            modelBuilder.Entity("CookingMasterAPI.Models.Entity.IngredientNutrient", b =>
                {
                    b.HasOne("CookingMasterAPI.Models.Entity.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
