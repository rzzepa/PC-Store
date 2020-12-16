using Microsoft.EntityFrameworkCore.Migrations;

namespace PC_Store.Migrations
{
    public partial class update10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pCCreators",
                columns: table => new
                {
                    PcCreatorId = table.Column<string>(nullable: false),
                    ComputerCaseProductId = table.Column<int>(nullable: true),
                    ProcessorProductId = table.Column<int>(nullable: true),
                    RamProductId = table.Column<int>(nullable: true),
                    GraphicCardProductId = table.Column<int>(nullable: true),
                    MotherboardProductId = table.Column<int>(nullable: true),
                    PowerSupplyProductId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pCCreators", x => x.PcCreatorId);
                    table.ForeignKey(
                        name: "FK_pCCreators_Products_ComputerCaseProductId",
                        column: x => x.ComputerCaseProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pCCreators_Products_GraphicCardProductId",
                        column: x => x.GraphicCardProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pCCreators_Products_MotherboardProductId",
                        column: x => x.MotherboardProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pCCreators_Products_PowerSupplyProductId",
                        column: x => x.PowerSupplyProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pCCreators_Products_ProcessorProductId",
                        column: x => x.ProcessorProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pCCreators_Products_RamProductId",
                        column: x => x.RamProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pCCreators_ComputerCaseProductId",
                table: "pCCreators",
                column: "ComputerCaseProductId");

            migrationBuilder.CreateIndex(
                name: "IX_pCCreators_GraphicCardProductId",
                table: "pCCreators",
                column: "GraphicCardProductId");

            migrationBuilder.CreateIndex(
                name: "IX_pCCreators_MotherboardProductId",
                table: "pCCreators",
                column: "MotherboardProductId");

            migrationBuilder.CreateIndex(
                name: "IX_pCCreators_PowerSupplyProductId",
                table: "pCCreators",
                column: "PowerSupplyProductId");

            migrationBuilder.CreateIndex(
                name: "IX_pCCreators_ProcessorProductId",
                table: "pCCreators",
                column: "ProcessorProductId");

            migrationBuilder.CreateIndex(
                name: "IX_pCCreators_RamProductId",
                table: "pCCreators",
                column: "RamProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pCCreators");
        }
    }
}
