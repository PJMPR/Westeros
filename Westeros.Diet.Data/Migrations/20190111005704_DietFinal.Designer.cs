﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Westeros.Diet.Data.Repositories;

namespace Westeros.Diet.Data.Migrations
{
    [DbContext(typeof(DietDbContext))]
    [Migration("20190111005704_DietFinal")]
    partial class DietFinal
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Westeros.Diet.Data.Model.Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Devices");

                    b.HasData(
                        new { Id = 1, Name = "Mikrofalówka" },
                        new { Id = 2, Name = "Talerz" },
                        new { Id = 3, Name = "Widelec" },
                        new { Id = 4, Name = "Garnek" },
                        new { Id = 5, Name = "Patelnia" },
                        new { Id = 6, Name = "Wok" }
                    );
                });

            modelBuilder.Entity("Westeros.Diet.Data.Model.DietPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Calories");

                    b.Property<double>("Carbohydrates");

                    b.Property<double>("Fats");

                    b.Property<string>("Name");

                    b.Property<double>("Proteins");

                    b.Property<int>("UserProfileId");

                    b.HasKey("Id");

                    b.HasIndex("UserProfileId");

                    b.ToTable("DietPlans");

                    b.HasData(
                        new { Id = 1, Calories = 2656, Carbohydrates = 295.8, Fats = 111.5, Name = "Masa plan", Proteins = 117.1, UserProfileId = 1 },
                        new { Id = 2, Calories = 1528, Carbohydrates = 299.8, Fats = 31.5, Name = "Redukcja plan", Proteins = 81.1, UserProfileId = 1 },
                        new { Id = 3, Calories = 2161, Carbohydrates = 24.8, Fats = 84.6, Name = "Utrzymanie plan", Proteins = 19.1, UserProfileId = 1 }
                    );
                });

            modelBuilder.Entity("Westeros.Diet.Data.Model.Entry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<int>("UserProfileId");

                    b.Property<double>("Weight");

                    b.HasKey("Id");

                    b.HasIndex("UserProfileId");

                    b.ToTable("Entries");

                    b.HasData(
                        new { Id = 1, Date = new DateTime(2019, 1, 10, 1, 57, 3, 913, DateTimeKind.Local), UserProfileId = 1, Weight = 90.0 },
                        new { Id = 2, Date = new DateTime(2019, 1, 10, 1, 57, 3, 915, DateTimeKind.Local), UserProfileId = 1, Weight = 89.0 },
                        new { Id = 3, Date = new DateTime(2019, 1, 11, 1, 57, 3, 915, DateTimeKind.Local), UserProfileId = 1, Weight = 88.0 },
                        new { Id = 4, Date = new DateTime(2019, 1, 10, 22, 57, 3, 915, DateTimeKind.Local), UserProfileId = 2, Weight = 45.0 },
                        new { Id = 5, Date = new DateTime(2019, 1, 11, 0, 57, 3, 915, DateTimeKind.Local), UserProfileId = 2, Weight = 46.0 },
                        new { Id = 6, Date = new DateTime(2019, 1, 11, 1, 57, 3, 915, DateTimeKind.Local), UserProfileId = 2, Weight = 44.0 }
                    );
                });

            modelBuilder.Entity("Westeros.Diet.Data.Model.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("AveragePrice");

                    b.Property<int>("Calories");

                    b.Property<double>("Carbohydrates");

                    b.Property<int>("Category");

                    b.Property<double>("Fats");

                    b.Property<string>("Name");

                    b.Property<string>("PhotoPath");

                    b.Property<double>("Proteins");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new { Id = 1, AveragePrice = 3.5, Calories = 250, Carbohydrates = 0.0, Category = 2, Fats = 15.0, Name = "Wołowina", Proteins = 26.0 },
                        new { Id = 2, AveragePrice = 1.0, Calories = 402, Carbohydrates = 1.3, Category = 4, Fats = 33.0, Name = "Ser", Proteins = 25.0 },
                        new { Id = 3, AveragePrice = 1.5, Calories = 272, Carbohydrates = 0.0, Category = 2, Fats = 25.0, Name = "Drób", Proteins = 11.0 },
                        new { Id = 4, AveragePrice = 4.0, Calories = 208, Carbohydrates = 0.0, Category = 3, Fats = 12.0, Name = "Łosoś", Proteins = 20.0 },
                        new { Id = 5, AveragePrice = 0.8, Calories = 66, Carbohydrates = 17.0, Category = 1, Fats = 0.4, Name = "Winogrona", Proteins = 0.6 }
                    );
                });

            modelBuilder.Entity("Westeros.Diet.Data.Model.IngredientEntry", b =>
                {
                    b.Property<int>("IngredientId");

                    b.Property<int>("EntryId");

                    b.Property<double>("IngredientQuantity");

                    b.HasKey("IngredientId", "EntryId");

                    b.HasAlternateKey("EntryId", "IngredientId");

                    b.ToTable("EntryIngredients");

                    b.HasData(
                        new { IngredientId = 1, EntryId = 1, IngredientQuantity = 5.0 },
                        new { IngredientId = 5, EntryId = 2, IngredientQuantity = 0.5 },
                        new { IngredientId = 5, EntryId = 4, IngredientQuantity = 0.15 },
                        new { IngredientId = 2, EntryId = 4, IngredientQuantity = 1.5 },
                        new { IngredientId = 4, EntryId = 6, IngredientQuantity = 8.5 }
                    );
                });

            modelBuilder.Entity("Westeros.Diet.Data.Model.RecipeDevice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DeviceId");

                    b.Property<int>("RecipeId");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipeDevices");

                    b.HasData(
                        new { Id = 1, DeviceId = 1, RecipeId = 1 },
                        new { Id = 2, DeviceId = 2, RecipeId = 1 },
                        new { Id = 3, DeviceId = 3, RecipeId = 1 },
                        new { Id = 4, DeviceId = 5, RecipeId = 2 },
                        new { Id = 5, DeviceId = 3, RecipeId = 2 },
                        new { Id = 6, DeviceId = 6, RecipeId = 3 },
                        new { Id = 7, DeviceId = 2, RecipeId = 3 },
                        new { Id = 8, DeviceId = 1, RecipeId = 3 },
                        new { Id = 9, DeviceId = 4, RecipeId = 3 }
                    );
                });

            modelBuilder.Entity("Westeros.Diet.Data.Model.RecipeEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EntryId");

                    b.Property<int>("RecipeId");

                    b.HasKey("Id");

                    b.HasIndex("EntryId");

                    b.HasIndex("RecipeId");

                    b.ToTable("EntryRecipes");

                    b.HasData(
                        new { Id = 1, EntryId = 1, RecipeId = 2 },
                        new { Id = 2, EntryId = 1, RecipeId = 2 },
                        new { Id = 3, EntryId = 2, RecipeId = 2 },
                        new { Id = 4, EntryId = 2, RecipeId = 3 },
                        new { Id = 5, EntryId = 3, RecipeId = 3 },
                        new { Id = 6, EntryId = 4, RecipeId = 1 },
                        new { Id = 7, EntryId = 4, RecipeId = 1 },
                        new { Id = 8, EntryId = 5, RecipeId = 2 },
                        new { Id = 9, EntryId = 6, RecipeId = 2 }
                    );
                });

            modelBuilder.Entity("Westeros.Diet.Data.Model.RecipeIngredient", b =>
                {
                    b.Property<int>("IngredientId");

                    b.Property<int>("RecipeId");

                    b.Property<double>("IngredientQuantity");

                    b.HasKey("IngredientId", "RecipeId");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipeIngredients");

                    b.HasData(
                        new { IngredientId = 1, RecipeId = 1, IngredientQuantity = 5.0 },
                        new { IngredientId = 2, RecipeId = 1, IngredientQuantity = 1.0 },
                        new { IngredientId = 4, RecipeId = 1, IngredientQuantity = 2.0 },
                        new { IngredientId = 2, RecipeId = 2, IngredientQuantity = 8.0 },
                        new { IngredientId = 5, RecipeId = 2, IngredientQuantity = 8.0 },
                        new { IngredientId = 1, RecipeId = 3, IngredientQuantity = 1.0 },
                        new { IngredientId = 2, RecipeId = 3, IngredientQuantity = 0.5 },
                        new { IngredientId = 3, RecipeId = 3, IngredientQuantity = 8.0 },
                        new { IngredientId = 4, RecipeId = 3, IngredientQuantity = 2.0 },
                        new { IngredientId = 5, RecipeId = 3, IngredientQuantity = 1.5 }
                    );
                });

            modelBuilder.Entity("Westeros.Diet.Data.Model.UserProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age");

                    b.Property<string>("Email");

                    b.Property<double>("Height");

                    b.Property<string>("Login");

                    b.Property<string>("Name");

                    b.Property<int>("Sex");

                    b.Property<string>("Surname");

                    b.Property<double>("Weight");

                    b.HasKey("Id");

                    b.ToTable("UserProfiles");

                    b.HasData(
                        new { Id = 1, Age = 18, Email = "a@a.pl", Height = 175.0, Login = "xXxDragonSlayerxXx", Name = "Jan", Sex = 0, Surname = "Sikora", Weight = 90.0 },
                        new { Id = 2, Age = 22, Email = "b@b.pl", Height = 165.0, Login = "KsIeZnIcZkA69", Name = "Marta", Sex = 1, Surname = "Kawecik", Weight = 45.0 }
                    );
                });

            modelBuilder.Entity("Westeros.Diet.Data.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cuisine");

                    b.Property<string>("Description");

                    b.Property<int>("Difficulty");

                    b.Property<bool>("IsNew");

                    b.Property<string>("Name");

                    b.Property<string>("PhotoPath");

                    b.Property<int>("PrepTime");

                    b.HasKey("Id");

                    b.ToTable("Recipes");

                    b.HasData(
                        new { Id = 1, Cuisine = 0, Difficulty = 0, IsNew = true, Name = "Masa", PrepTime = 0 },
                        new { Id = 2, Cuisine = 0, Difficulty = 0, IsNew = true, Name = "Redukcja", PrepTime = 0 },
                        new { Id = 3, Cuisine = 0, Difficulty = 0, IsNew = true, Name = "Utrzymanie", PrepTime = 0 }
                    );
                });

            modelBuilder.Entity("Westeros.Diet.Data.Model.DietPlan", b =>
                {
                    b.HasOne("Westeros.Diet.Data.Model.UserProfile", "UserProfile")
                        .WithMany()
                        .HasForeignKey("UserProfileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Westeros.Diet.Data.Model.Entry", b =>
                {
                    b.HasOne("Westeros.Diet.Data.Model.UserProfile", "UserProfile")
                        .WithMany("Entries")
                        .HasForeignKey("UserProfileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Westeros.Diet.Data.Model.IngredientEntry", b =>
                {
                    b.HasOne("Westeros.Diet.Data.Model.Entry", "Entry")
                        .WithMany("EntryIngredients")
                        .HasForeignKey("EntryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Westeros.Diet.Data.Model.Ingredient", "Ingredient")
                        .WithMany("IngredientEntries")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Westeros.Diet.Data.Model.RecipeDevice", b =>
                {
                    b.HasOne("Westeros.Diet.Data.Model.Device", "Device")
                        .WithMany("RecipeDevices")
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Westeros.Diet.Data.Recipe", "Recipe")
                        .WithMany("RecipeDevices")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Westeros.Diet.Data.Model.RecipeEntry", b =>
                {
                    b.HasOne("Westeros.Diet.Data.Model.Entry", "Entry")
                        .WithMany("EntryRecipes")
                        .HasForeignKey("EntryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Westeros.Diet.Data.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Westeros.Diet.Data.Model.RecipeIngredient", b =>
                {
                    b.HasOne("Westeros.Diet.Data.Model.Ingredient", "Ingredient")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Westeros.Diet.Data.Recipe", "Recipe")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
