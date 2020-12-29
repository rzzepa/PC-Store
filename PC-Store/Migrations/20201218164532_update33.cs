using Microsoft.EntityFrameworkCore.Migrations;

namespace PC_Store.Migrations
{
    public partial class update33 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userPCCreators_Products_ComputerCaseProductId",
                table: "userPCCreators");

            migrationBuilder.DropForeignKey(
                name: "FK_userPCCreators_Products_GraphicCardProductId",
                table: "userPCCreators");

            migrationBuilder.DropForeignKey(
                name: "FK_userPCCreators_Products_MotherboardProductId",
                table: "userPCCreators");

            migrationBuilder.DropForeignKey(
                name: "FK_userPCCreators_Products_PowerSupplyProductId",
                table: "userPCCreators");

            migrationBuilder.DropForeignKey(
                name: "FK_userPCCreators_Products_ProcessorProductId",
                table: "userPCCreators");

            migrationBuilder.DropForeignKey(
                name: "FK_userPCCreators_Products_RamProductId",
                table: "userPCCreators");

            migrationBuilder.DropIndex(
                name: "IX_userPCCreators_ComputerCaseProductId",
                table: "userPCCreators");

            migrationBuilder.DropIndex(
                name: "IX_userPCCreators_GraphicCardProductId",
                table: "userPCCreators");

            migrationBuilder.DropIndex(
                name: "IX_userPCCreators_MotherboardProductId",
                table: "userPCCreators");

            migrationBuilder.DropIndex(
                name: "IX_userPCCreators_PowerSupplyProductId",
                table: "userPCCreators");

            migrationBuilder.DropIndex(
                name: "IX_userPCCreators_ProcessorProductId",
                table: "userPCCreators");

            migrationBuilder.DropIndex(
                name: "IX_userPCCreators_RamProductId",
                table: "userPCCreators");

            migrationBuilder.DropColumn(
                name: "ComputerCaseProductId",
                table: "userPCCreators");

            migrationBuilder.DropColumn(
                name: "GraphicCardProductId",
                table: "userPCCreators");

            migrationBuilder.DropColumn(
                name: "MotherboardProductId",
                table: "userPCCreators");

            migrationBuilder.DropColumn(
                name: "PowerSupplyProductId",
                table: "userPCCreators");

            migrationBuilder.DropColumn(
                name: "ProcessorProductId",
                table: "userPCCreators");

            migrationBuilder.DropColumn(
                name: "RamProductId",
                table: "userPCCreators");

            migrationBuilder.AddColumn<int>(
                name: "ComputerCaseProduct",
                table: "userPCCreators",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GraphicCardProduct",
                table: "userPCCreators",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MotherboardProduct",
                table: "userPCCreators",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PowerSupplyProduct",
                table: "userPCCreators",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProcessorProduct",
                table: "userPCCreators",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RamProduct",
                table: "userPCCreators",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComputerCaseProduct",
                table: "userPCCreators");

            migrationBuilder.DropColumn(
                name: "GraphicCardProduct",
                table: "userPCCreators");

            migrationBuilder.DropColumn(
                name: "MotherboardProduct",
                table: "userPCCreators");

            migrationBuilder.DropColumn(
                name: "PowerSupplyProduct",
                table: "userPCCreators");

            migrationBuilder.DropColumn(
                name: "ProcessorProduct",
                table: "userPCCreators");

            migrationBuilder.DropColumn(
                name: "RamProduct",
                table: "userPCCreators");

            migrationBuilder.AddColumn<int>(
                name: "ComputerCaseProductId",
                table: "userPCCreators",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GraphicCardProductId",
                table: "userPCCreators",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MotherboardProductId",
                table: "userPCCreators",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PowerSupplyProductId",
                table: "userPCCreators",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProcessorProductId",
                table: "userPCCreators",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RamProductId",
                table: "userPCCreators",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_userPCCreators_ComputerCaseProductId",
                table: "userPCCreators",
                column: "ComputerCaseProductId");

            migrationBuilder.CreateIndex(
                name: "IX_userPCCreators_GraphicCardProductId",
                table: "userPCCreators",
                column: "GraphicCardProductId");

            migrationBuilder.CreateIndex(
                name: "IX_userPCCreators_MotherboardProductId",
                table: "userPCCreators",
                column: "MotherboardProductId");

            migrationBuilder.CreateIndex(
                name: "IX_userPCCreators_PowerSupplyProductId",
                table: "userPCCreators",
                column: "PowerSupplyProductId");

            migrationBuilder.CreateIndex(
                name: "IX_userPCCreators_ProcessorProductId",
                table: "userPCCreators",
                column: "ProcessorProductId");

            migrationBuilder.CreateIndex(
                name: "IX_userPCCreators_RamProductId",
                table: "userPCCreators",
                column: "RamProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_userPCCreators_Products_ComputerCaseProductId",
                table: "userPCCreators",
                column: "ComputerCaseProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_userPCCreators_Products_GraphicCardProductId",
                table: "userPCCreators",
                column: "GraphicCardProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_userPCCreators_Products_MotherboardProductId",
                table: "userPCCreators",
                column: "MotherboardProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_userPCCreators_Products_PowerSupplyProductId",
                table: "userPCCreators",
                column: "PowerSupplyProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_userPCCreators_Products_ProcessorProductId",
                table: "userPCCreators",
                column: "ProcessorProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_userPCCreators_Products_RamProductId",
                table: "userPCCreators",
                column: "RamProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
