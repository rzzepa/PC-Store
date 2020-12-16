using Microsoft.EntityFrameworkCore.Migrations;

namespace PC_Store.Migrations
{
    public partial class update12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "motherboardCreatorLists",
                columns: table => new
                {
                    PcCreatorId = table.Column<string>(nullable: true),
                    Producer = table.Column<string>(nullable: true),
                    ProducerCode = table.Column<string>(nullable: true),
                    Standard = table.Column<string>(nullable: true),
                    Chipset = table.Column<string>(nullable: true),
                    SocketType = table.Column<string>(nullable: true),
                    Technologies = table.Column<string>(nullable: true),
                    StandardMemory = table.Column<string>(nullable: true),
                    ConnectorType = table.Column<string>(nullable: true),
                    NumberOfMemorySlots = table.Column<int>(nullable: false),
                    MaximumAmountOfMemory = table.Column<int>(nullable: false),
                    MultiChannelArchitecture = table.Column<string>(nullable: true),
                    IntegratedGraphicsCardSupport = table.Column<bool>(nullable: false),
                    GraphicsChipset = table.Column<string>(nullable: true),
                    CombiningCards = table.Column<string>(nullable: true),
                    SoundChipset = table.Column<string>(nullable: true),
                    AudioChannels = table.Column<string>(nullable: true),
                    IntegratedNetworkCard = table.Column<string>(nullable: true),
                    NetworkCardChipset = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Picture = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "motherboardCreatorLists");
        }
    }
}
