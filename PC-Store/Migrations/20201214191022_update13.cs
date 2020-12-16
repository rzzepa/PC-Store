using Microsoft.EntityFrameworkCore.Migrations;

namespace PC_Store.Migrations
{
    public partial class update13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "motherboardCreatorLists");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "motherboardCreatorLists",
                columns: table => new
                {
                    AudioChannels = table.Column<string>(type: "text", nullable: true),
                    Chipset = table.Column<string>(type: "text", nullable: true),
                    CombiningCards = table.Column<string>(type: "text", nullable: true),
                    ConnectorType = table.Column<string>(type: "text", nullable: true),
                    GraphicsChipset = table.Column<string>(type: "text", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IntegratedGraphicsCardSupport = table.Column<bool>(type: "boolean", nullable: false),
                    IntegratedNetworkCard = table.Column<string>(type: "text", nullable: true),
                    MaximumAmountOfMemory = table.Column<int>(type: "integer", nullable: false),
                    MultiChannelArchitecture = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NetworkCardChipset = table.Column<string>(type: "text", nullable: true),
                    NumberOfMemorySlots = table.Column<int>(type: "integer", nullable: false),
                    PcCreatorId = table.Column<string>(type: "text", nullable: true),
                    Picture = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Producer = table.Column<string>(type: "text", nullable: true),
                    ProducerCode = table.Column<string>(type: "text", nullable: true),
                    SocketType = table.Column<string>(type: "text", nullable: true),
                    SoundChipset = table.Column<string>(type: "text", nullable: true),
                    Standard = table.Column<string>(type: "text", nullable: true),
                    StandardMemory = table.Column<string>(type: "text", nullable: true),
                    Technologies = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });
        }
    }
}
