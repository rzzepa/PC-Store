using Microsoft.EntityFrameworkCore.Migrations;

namespace PC_Store.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCardItems_Processors_ProductId",
                table: "ShoppingCardItems");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCardItems_Products_ProductId",
                table: "ShoppingCardItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCardItems_Products_ProductId",
                table: "ShoppingCardItems");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCardItems_Processors_ProductId",
                table: "ShoppingCardItems",
                column: "ProductId",
                principalTable: "Processors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
