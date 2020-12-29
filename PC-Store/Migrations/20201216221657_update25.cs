using Microsoft.EntityFrameworkCore.Migrations;

namespace PC_Store.Migrations
{
    public partial class update25 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CoolingType",
                table: "GraphicCards",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "CardLength",
                table: "GraphicCards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ChipsetType",
                table: "GraphicCards",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Led",
                table: "GraphicCards",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardLength",
                table: "GraphicCards");

            migrationBuilder.DropColumn(
                name: "ChipsetType",
                table: "GraphicCards");

            migrationBuilder.DropColumn(
                name: "Led",
                table: "GraphicCards");

            migrationBuilder.AlterColumn<int>(
                name: "CoolingType",
                table: "GraphicCards",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
