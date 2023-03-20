using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SD_330_Demos.Migrations
{
    public partial class AddOrganismSubtypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgeDays",
                table: "Organism",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "CellCount",
                table: "Organism",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Legs",
                table: "Organism",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Photosynthetic",
                table: "Organism",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeOfReproduction",
                table: "Organism",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "organism_type",
                table: "Organism",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgeDays",
                table: "Organism");

            migrationBuilder.DropColumn(
                name: "CellCount",
                table: "Organism");

            migrationBuilder.DropColumn(
                name: "Legs",
                table: "Organism");

            migrationBuilder.DropColumn(
                name: "Photosynthetic",
                table: "Organism");

            migrationBuilder.DropColumn(
                name: "TypeOfReproduction",
                table: "Organism");

            migrationBuilder.DropColumn(
                name: "organism_type",
                table: "Organism");
        }
    }
}
