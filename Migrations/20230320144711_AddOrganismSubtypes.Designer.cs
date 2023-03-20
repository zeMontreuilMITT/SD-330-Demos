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
    [Migration("20230320144711_AddOrganismSubtypes")]
    partial class AddOrganismSubtypes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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
#pragma warning restore 612, 618
        }
    }
}