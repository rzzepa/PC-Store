using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PC_Store.Migrations
{
    public partial class update19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SocketType",
                table: "Processors",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Producer",
                table: "Processors",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Line",
                table: "Processors",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Processors",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Technologies",
                table: "Motherboards",
                nullable: true,
                oldClrType: typeof(string[]),
                oldType: "text[]",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AudioChannels",
                table: "Motherboards",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CombiningCards",
                table: "Motherboards",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConnectorType",
                table: "Motherboards",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GraphicsChipset",
                table: "Motherboards",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IntegratedGraphicsCardSupport",
                table: "Motherboards",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IntegratedNetworkCard",
                table: "Motherboards",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaximumAmountOfMemory",
                table: "Motherboards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MultiChannelArchitecture",
                table: "Motherboards",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NetworkCardChipset",
                table: "Motherboards",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfMemorySlots",
                table: "Motherboards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SoundChipset",
                table: "Motherboards",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StandardMemory",
                table: "Motherboards",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Processors");

            migrationBuilder.DropColumn(
                name: "AudioChannels",
                table: "Motherboards");

            migrationBuilder.DropColumn(
                name: "CombiningCards",
                table: "Motherboards");

            migrationBuilder.DropColumn(
                name: "ConnectorType",
                table: "Motherboards");

            migrationBuilder.DropColumn(
                name: "GraphicsChipset",
                table: "Motherboards");

            migrationBuilder.DropColumn(
                name: "IntegratedGraphicsCardSupport",
                table: "Motherboards");

            migrationBuilder.DropColumn(
                name: "IntegratedNetworkCard",
                table: "Motherboards");

            migrationBuilder.DropColumn(
                name: "MaximumAmountOfMemory",
                table: "Motherboards");

            migrationBuilder.DropColumn(
                name: "MultiChannelArchitecture",
                table: "Motherboards");

            migrationBuilder.DropColumn(
                name: "NetworkCardChipset",
                table: "Motherboards");

            migrationBuilder.DropColumn(
                name: "NumberOfMemorySlots",
                table: "Motherboards");

            migrationBuilder.DropColumn(
                name: "SoundChipset",
                table: "Motherboards");

            migrationBuilder.DropColumn(
                name: "StandardMemory",
                table: "Motherboards");

            migrationBuilder.AlterColumn<string>(
                name: "SocketType",
                table: "Processors",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Producer",
                table: "Processors",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Line",
                table: "Processors",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string[]>(
                name: "Technologies",
                table: "Motherboards",
                type: "text[]",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
