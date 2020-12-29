using Microsoft.EntityFrameworkCore.Migrations;

namespace PC_Store.Migrations
{
    public partial class update26 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Payment",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StatusOrder",
                table: "Orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Payment",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "StatusOrder",
                table: "Orders");
        }
    }
}
