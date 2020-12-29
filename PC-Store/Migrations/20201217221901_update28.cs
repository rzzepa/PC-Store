using Microsoft.EntityFrameworkCore.Migrations;

namespace PC_Store.Migrations
{
    public partial class update28 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Regulations",
                table: "Orders",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Regulations",
                table: "Orders");
        }
    }
}
