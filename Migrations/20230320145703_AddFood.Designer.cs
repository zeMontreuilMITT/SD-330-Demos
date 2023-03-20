﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SD_330_Demos.Data;

#nullable disable

namespace SD_330_Demos.Migrations
{
    [DbContext(typeof(SD_330_DemosContext))]
    [Migration("20230320145703_AddFood")]
    partial class AddFood
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SD_330_Demos.Models.Diet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.Property<int>("OrganismId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FoodId");

                    b.HasIndex("OrganismId");

                    b.ToTable("Diets");
                });

            modelBuilder.Entity("SD_330_Demos.Models.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("SD_330_Demos.Models.Organism", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AgeDays")
                        .HasColumnType("int");

                    b.Property<string>("BinomialName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("CellCount")
                        .HasColumnType("float");

                    b.Property<string>("EnglishName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeOfReproduction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("organism_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Organism");

                    b.HasDiscriminator<string>("organism_type").HasValue("Organism");
                });

            modelBuilder.Entity("SD_330_Demos.Models.Animal", b =>
                {
                    b.HasBaseType("SD_330_Demos.Models.Organism");

                    b.Property<int>("Legs")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("organism_animal");
                });

            modelBuilder.Entity("SD_330_Demos.Models.Plant", b =>
                {
                    b.HasBaseType("SD_330_Demos.Models.Organism");

                    b.Property<bool>("Photosynthetic")
                        .HasColumnType("bit");

                    b.HasDiscriminator().HasValue("organism_plant");
                });

            modelBuilder.Entity("SD_330_Demos.Models.Diet", b =>
                {
                    b.HasOne("SD_330_Demos.Models.Food", "Food")
                        .WithMany("Diets")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SD_330_Demos.Models.Organism", "Organism")
                        .WithMany("Diets")
                        .HasForeignKey("OrganismId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Food");

                    b.Navigation("Organism");
                });

            modelBuilder.Entity("SD_330_Demos.Models.Food", b =>
                {
                    b.Navigation("Diets");
                });

            modelBuilder.Entity("SD_330_Demos.Models.Organism", b =>
                {
                    b.Navigation("Diets");
                });
#pragma warning restore 612, 618
        }
    }
}