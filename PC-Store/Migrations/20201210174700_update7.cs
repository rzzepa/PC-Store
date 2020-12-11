using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PC_Store.Migrations
{
    public partial class update7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComputerCases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Producer = table.Column<string>(nullable: true),
                    ProducerCode = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Backlit = table.Column<string>(nullable: true),
                    Height = table.Column<float>(nullable: false),
                    Width = table.Column<float>(nullable: false),
                    Depth = table.Column<float>(nullable: false),
                    Weight = table.Column<float>(nullable: false),
                    ComputerCaseType = table.Column<string>(nullable: true),
                    Compatibility = table.Column<string>(nullable: true),
                    Window = table.Column<bool>(nullable: false),
                    Muted = table.Column<bool>(nullable: false),
                    Usb20 = table.Column<int>(nullable: false),
                    Usb30 = table.Column<int>(nullable: false),
                    Usb31 = table.Column<int>(nullable: false),
                    Usb32 = table.Column<int>(nullable: false),
                    USBC = table.Column<int>(nullable: false),
                    MemoryCardReader = table.Column<bool>(nullable: false),
                    SpeakerConnector = table.Column<bool>(nullable: false),
                    MicrophoneConnector = table.Column<bool>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerCases", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComputerCases");
        }
    }
}
