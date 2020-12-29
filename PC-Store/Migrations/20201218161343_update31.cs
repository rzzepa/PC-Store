using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PC_Store.Migrations
{
    public partial class update31 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "userPCCreators",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    ComputerCaseProductId = table.Column<int>(nullable: true),
                    ProcessorProductId = table.Column<int>(nullable: true),
                    RamProductId = table.Column<int>(nullable: true),
                    GraphicCardProductId = table.Column<int>(nullable: true),
                    MotherboardProductId = table.Column<int>(nullable: true),
                    PowerSupplyProductId = table.Column<int>(nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    User = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userPCCreators", x => x.Name);
                    table.ForeignKey(
                        name: "FK_userPCCreators_Products_ComputerCaseProductId",
                        column: x => x.ComputerCaseProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_userPCCreators_Products_GraphicCardProductId",
                        column: x => x.GraphicCardProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_userPCCreators_Products_MotherboardProductId",
                        column: x => x.MotherboardProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_userPCCreators_Products_PowerSupplyProductId",
                        column: x => x.PowerSupplyProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_userPCCreators_Products_ProcessorProductId",
                        column: x => x.ProcessorProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_userPCCreators_Products_RamProductId",
                        column: x => x.RamProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "userPCCreators");

           
        }
    }
}
