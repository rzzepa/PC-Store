using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PC_Store.Migrations
{
    public partial class update9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PowerSupplies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Producer = table.Column<string>(nullable: true),
                    ProducerCode = table.Column<string>(nullable: true),
                    Standard = table.Column<string>(nullable: true),
                    Power = table.Column<int>(nullable: false),
                    EfficiencyCertificate = table.Column<string>(nullable: true),
                    PFCSystem = table.Column<bool>(nullable: false),
                    Efficiency = table.Column<int>(nullable: false),
                    CoolingType = table.Column<string>(nullable: true),
                    Diameter = table.Column<int>(nullable: false),
                    Security = table.Column<string>(nullable: true),
                    ModularCabling = table.Column<string>(nullable: true),
                    ATX24pin204 = table.Column<int>(nullable: false),
                    PCIE8pin62 = table.Column<int>(nullable: false),
                    PCIE8pin = table.Column<int>(nullable: false),
                    PCIE6pin = table.Column<int>(nullable: false),
                    CPU44pin8 = table.Column<int>(nullable: false),
                    CPU8pin = table.Column<int>(nullable: false),
                    CPU4pin = table.Column<int>(nullable: false),
                    SATA = table.Column<int>(nullable: false),
                    Molex = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    Width = table.Column<int>(nullable: false),
                    Depth = table.Column<int>(nullable: false),
                    Backlight = table.Column<bool>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PowerSupplies", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PowerSupplies");
        }
    }
}
