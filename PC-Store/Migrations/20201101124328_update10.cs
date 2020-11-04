using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PC_Store.Migrations
{
    public partial class update10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.RenameColumn(
                name: "unlockedMultiplier",
                table: "processors",
                newName: "UnlockedMultiplier");

            migrationBuilder.RenameColumn(
                name: "typesOfSupportedMemory",
                table: "processors",
                newName: "TypesOfSupportedMemory");

            migrationBuilder.RenameColumn(
                name: "turboMaximumFrequency",
                table: "processors",
                newName: "TurboMaximumFrequency");

            migrationBuilder.RenameColumn(
                name: "sockerType",
                table: "processors",
                newName: "SocketType");

            migrationBuilder.RenameColumn(
                name: "producer",
                table: "processors",
                newName: "Producer");

            migrationBuilder.RenameColumn(
                name: "processorClockFrequency",
                table: "processors",
                newName: "ProcessorClockFrequency");

            migrationBuilder.RenameColumn(
                name: "numberOfThreads",
                table: "processors",
                newName: "NumberOfThreads");

            migrationBuilder.RenameColumn(
                name: "numberOfCores",
                table: "processors",
                newName: "NumberOfCores");

            migrationBuilder.RenameColumn(
                name: "line",
                table: "processors",
                newName: "Line");

            migrationBuilder.RenameColumn(
                name: "integratedGraphics",
                table: "processors",
                newName: "IntegratedGraphics");

            migrationBuilder.RenameColumn(
                name: "cooling",
                table: "processors",
                newName: "Cooling");

            migrationBuilder.RenameColumn(
                name: "architecture",
                table: "processors",
                newName: "Architecture");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnlockedMultiplier",
                table: "processors",
                newName: "unlockedMultiplier");

            migrationBuilder.RenameColumn(
                name: "TypesOfSupportedMemory",
                table: "processors",
                newName: "typesOfSupportedMemory");

            migrationBuilder.RenameColumn(
                name: "TurboMaximumFrequency",
                table: "processors",
                newName: "turboMaximumFrequency");

            migrationBuilder.RenameColumn(
                name: "SocketType",
                table: "processors",
                newName: "sockerType");

            migrationBuilder.RenameColumn(
                name: "Producer",
                table: "processors",
                newName: "producer");

            migrationBuilder.RenameColumn(
                name: "ProcessorClockFrequency",
                table: "processors",
                newName: "processorClockFrequency");

            migrationBuilder.RenameColumn(
                name: "NumberOfThreads",
                table: "processors",
                newName: "numberOfThreads");

            migrationBuilder.RenameColumn(
                name: "NumberOfCores",
                table: "processors",
                newName: "numberOfCores");

            migrationBuilder.RenameColumn(
                name: "Line",
                table: "processors",
                newName: "line");

            migrationBuilder.RenameColumn(
                name: "IntegratedGraphics",
                table: "processors",
                newName: "integratedGraphics");

            migrationBuilder.RenameColumn(
                name: "Cooling",
                table: "processors",
                newName: "cooling");

            migrationBuilder.RenameColumn(
                name: "Architecture",
                table: "processors",
                newName: "architecture");

            migrationBuilder.CreateTable(
                name: "people",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_people", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                });
        }
    }
}
