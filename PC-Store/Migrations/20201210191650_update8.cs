using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PC_Store.Migrations
{
    public partial class update8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Producer = table.Column<string>(nullable: true),
                    ProducerCode = table.Column<string>(nullable: true),
                    Line = table.Column<string>(nullable: true),
                    ConnectorType = table.Column<string>(nullable: true),
                    MemoryType = table.Column<string>(nullable: true),
                    Cooling = table.Column<string>(nullable: true),
                    LowProfile = table.Column<bool>(nullable: false),
                    TotalCapacity = table.Column<int>(nullable: false),
                    NumberOfModules = table.Column<int>(nullable: false),
                    Frequency = table.Column<int>(nullable: false),
                    Delay = table.Column<string>(nullable: true),
                    Voltage = table.Column<float>(nullable: false),
                    Backlight = table.Column<bool>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rams", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rams");
        }
    }
}
