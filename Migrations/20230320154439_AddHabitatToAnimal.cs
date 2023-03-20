using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SD_330_Demos.Migrations
{
    public partial class AddHabitatToAnimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Habitat",
                table: "Organism",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Habitat",
                table: "Organism");
        }
    }
}
