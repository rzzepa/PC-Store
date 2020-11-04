using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PC_Store.Migrations
{
    public partial class update18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_processors",
                table: "processors");

            migrationBuilder.RenameTable(
                name: "processors",
                newName: "Processors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Processors",
                table: "Processors",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "GraphicCards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Producer = table.Column<string>(nullable: true),
                    ProducerCode = table.Column<string>(nullable: true),
                    ProducerChipset = table.Column<string>(nullable: true),
                    CoreClock = table.Column<int>(nullable: false),
                    CoreClockBoost = table.Column<int>(nullable: false),
                    ConnectorType = table.Column<string>(nullable: true),
                    Resolution = table.Column<string>(nullable: true),
                    RecommendedPSUPower = table.Column<string>(nullable: true),
                    AmountOfRAM = table.Column<int>(nullable: false),
                    TypeOfRAM = table.Column<string>(nullable: true),
                    DataBus = table.Column<int>(nullable: false),
                    MemoryClock = table.Column<int>(nullable: false),
                    CoolingType = table.Column<int>(nullable: false),
                    NumberOfFans = table.Column<int>(nullable: false),
                    DSub = table.Column<int>(nullable: false),
                    DisplayPort = table.Column<int>(nullable: false),
                    HDMI = table.Column<int>(nullable: false),
                    DVI = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GraphicCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Motherboards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Producer = table.Column<string>(nullable: true),
                    ProducerCode = table.Column<string>(nullable: true),
                    Standard = table.Column<string>(nullable: true),
                    Chipset = table.Column<string>(nullable: true),
                    SocketType = table.Column<string>(nullable: true),
                    Technologies = table.Column<List<string>>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motherboards", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GraphicCards");

            migrationBuilder.DropTable(
                name: "Motherboards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Processors",
                table: "Processors");

            migrationBuilder.RenameTable(
                name: "Processors",
                newName: "processors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_processors",
                table: "processors",
                column: "Id");
        }
    }
}
