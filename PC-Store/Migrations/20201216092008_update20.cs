using Microsoft.EntityFrameworkCore.Migrations;

namespace PC_Store.Migrations
{
    public partial class update20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PCIExpressx1",
                table: "Motherboards",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PCIExpressx16",
                table: "Motherboards",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PCIExpressx4",
                table: "Motherboards",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VerConnectorType",
                table: "GraphicCards",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PCIExpressx1",
                table: "Motherboards");

            migrationBuilder.DropColumn(
                name: "PCIExpressx16",
                table: "Motherboards");

            migrationBuilder.DropColumn(
                name: "PCIExpressx4",
                table: "Motherboards");

            migrationBuilder.DropColumn(
                name: "VerConnectorType",
                table: "GraphicCards");
        }
    }
}
