﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzeriaProjekt.Dbo;

#nullable disable

namespace PizzeriaProjekt.Migrations
{
    [DbContext(typeof(MainDbContext))]
    [Migration("20220405200957_UsersAndMealsMerge")]
    partial class UsersAndMealsMerge
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PizzeriaProjekt.Meals.Meal", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("MealId");

                    b.Property<decimal>("BasePrice")
                        .HasColumnType("decimal(15,2)")
                        .HasColumnName("BasePrice");

                    b.Property<int>("Category")
                        .HasColumnType("int")
                        .HasColumnName("Category");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("longtext")
                        .HasColumnName("ImageUrl");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Meals", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("Meal");
                });

            modelBuilder.Entity("PizzeriaProjekt.Meals.Model.PizzaCrust", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("CrustId");

                    b.Property<decimal>("BasePrice")
                        .HasColumnType("decimal(15,2)")
                        .HasColumnName("BasePrice");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("PizzaCrust");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            BasePrice = 0.0m,
                            Name = "Thin"
                        },
                        new
                        {
                            Id = 2L,
                            BasePrice = 2.0m,
                            Name = "Thick"
                        });
                });

            modelBuilder.Entity("PizzeriaProjekt.Meals.Model.PizzaSize", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("PizzaSizeId");

                    b.Property<decimal>("BasePrice")
                        .HasColumnType("decimal(15,2)")
                        .HasColumnName("BasePrice");

                    b.Property<int>("DiameterCentimeters")
                        .HasColumnType("int")
                        .HasColumnName("Diameter");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("PizzaSize");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            BasePrice = 0.0m,
                            DiameterCentimeters = 20,
                            Name = "Small"
                        },
                        new
                        {
                            Id = 2L,
                            BasePrice = 8.0m,
                            DiameterCentimeters = 30,
                            Name = "Medium"
                        },
                        new
                        {
                            Id = 3L,
                            BasePrice = 18.0m,
                            DiameterCentimeters = 45,
                            Name = "Large"
                        });
                });

            modelBuilder.Entity("PizzeriaProjekt.Meals.PizzaTopping", b =>
                {
                    b.Property<long>("MealId")
                        .HasColumnType("bigint")
                        .HasColumnName("MealId");

                    b.Property<long>("ToppingId")
                        .HasColumnType("bigint")
                        .HasColumnName("ToppingId");

                    b.HasKey("MealId", "ToppingId");

                    b.HasIndex("ToppingId");

                    b.ToTable("PizzaToppings", (string)null);

                    b.HasData(
                        new
                        {
                            MealId = 1L,
                            ToppingId = 1L
                        },
                        new
                        {
                            MealId = 2L,
                            ToppingId = 1L
                        },
                        new
                        {
                            MealId = 2L,
                            ToppingId = 2L
                        },
                        new
                        {
                            MealId = 3L,
                            ToppingId = 1L
                        },
                        new
                        {
                            MealId = 3L,
                            ToppingId = 4L
                        },
                        new
                        {
                            MealId = 3L,
                            ToppingId = 5L
                        },
                        new
                        {
                            MealId = 4L,
                            ToppingId = 1L
                        },
                        new
                        {
                            MealId = 4L,
                            ToppingId = 3L
                        },
                        new
                        {
                            MealId = 4L,
                            ToppingId = 5L
                        });
                });

            modelBuilder.Entity("PizzeriaProjekt.Meals.Topping", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ToppingId");

                    b.Property<decimal>("BasePrice")
                        .HasColumnType("decimal(15,2)")
                        .HasColumnName("BasePrice");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Toppings", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            BasePrice = 2.00m,
                            Name = "Mozzarella"
                        },
                        new
                        {
                            Id = 2L,
                            BasePrice = 2.00m,
                            Name = "Ham"
                        },
                        new
                        {
                            Id = 3L,
                            BasePrice = 2.00m,
                            Name = "Japanelo"
                        },
                        new
                        {
                            Id = 4L,
                            BasePrice = 2.00m,
                            Name = "Pepperoni"
                        },
                        new
                        {
                            Id = 5L,
                            BasePrice = 2.00m,
                            Name = "Pineapple"
                        });
                });

            modelBuilder.Entity("PizzeriaProjekt.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Birthday = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Default",
                            FirstName = "Jan",
                            LastName = "Nowak",
                            Login = "test",
                            Password = "test",
                            PhoneNumber = "732121245",
                            PostCode = "Default",
                            Street = "Default"
                        });
                });

            modelBuilder.Entity("PizzeriaProjekt.Meals.Pizza", b =>
                {
                    b.HasBaseType("PizzeriaProjekt.Meals.Meal");

                    b.HasDiscriminator().HasValue("Pizza");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            BasePrice = 20.00m,
                            Category = 3,
                            Name = "Margherita"
                        },
                        new
                        {
                            Id = 2L,
                            BasePrice = 23.00m,
                            Category = 3,
                            Name = "Capricciosa"
                        },
                        new
                        {
                            Id = 3L,
                            BasePrice = 23.00m,
                            Category = 3,
                            Name = "Japanelo"
                        },
                        new
                        {
                            Id = 4L,
                            BasePrice = 24.00m,
                            Category = 3,
                            Name = "Hawaii"
                        });
                });

            modelBuilder.Entity("PizzeriaProjekt.Meals.PizzaTopping", b =>
                {
                    b.HasOne("PizzeriaProjekt.Meals.Pizza", "Pizza")
                        .WithMany("PizzaToppings")
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzeriaProjekt.Meals.Topping", "Topping")
                        .WithMany("PizzaToppings")
                        .HasForeignKey("ToppingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pizza");

                    b.Navigation("Topping");
                });

            modelBuilder.Entity("PizzeriaProjekt.Meals.Topping", b =>
                {
                    b.Navigation("PizzaToppings");
                });

            modelBuilder.Entity("PizzeriaProjekt.Meals.Pizza", b =>
                {
                    b.Navigation("PizzaToppings");
                });
#pragma warning restore 612, 618
        }
    }
}
