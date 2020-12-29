﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PC_Store.Data;

namespace PC_Store.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201218161343_update31")]
    partial class update31
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("PC_Store.Models.ComputerCase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Backlit")
                        .HasColumnType("text");

                    b.Property<string>("Color")
                        .HasColumnType("text");

                    b.Property<string>("Compatibility")
                        .HasColumnType("text");

                    b.Property<string>("ComputerCaseType")
                        .HasColumnType("text");

                    b.Property<float>("Depth")
                        .HasColumnType("real");

                    b.Property<float>("Height")
                        .HasColumnType("real");

                    b.Property<bool>("MemoryCardReader")
                        .HasColumnType("boolean");

                    b.Property<bool>("MicrophoneConnector")
                        .HasColumnType("boolean");

                    b.Property<bool>("Muted")
                        .HasColumnType("boolean");

                    b.Property<string>("Producer")
                        .HasColumnType("text");

                    b.Property<string>("ProducerCode")
                        .HasColumnType("text");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<bool>("SpeakerConnector")
                        .HasColumnType("boolean");

                    b.Property<int>("USBC")
                        .HasColumnType("integer");

                    b.Property<int>("Usb20")
                        .HasColumnType("integer");

                    b.Property<int>("Usb30")
                        .HasColumnType("integer");

                    b.Property<int>("Usb31")
                        .HasColumnType("integer");

                    b.Property<int>("Usb32")
                        .HasColumnType("integer");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.Property<float>("Width")
                        .HasColumnType("real");

                    b.Property<bool>("Window")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("ComputerCases");
                });

            modelBuilder.Entity("PC_Store.Models.Dictionary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CodeDict")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CodeItem")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CodeValue")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Ext1")
                        .HasColumnType("text");

                    b.Property<string>("Ext2")
                        .HasColumnType("text");

                    b.Property<int>("ExtN1")
                        .HasColumnType("integer");

                    b.Property<int>("ExtN2")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Dictionary");
                });

            modelBuilder.Entity("PC_Store.Models.GraphicCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AmountOfRAM")
                        .HasColumnType("integer");

                    b.Property<int>("CardLength")
                        .HasColumnType("integer");

                    b.Property<string>("ChipsetType")
                        .HasColumnType("text");

                    b.Property<string>("ConnectorType")
                        .HasColumnType("text");

                    b.Property<string>("CoolingType")
                        .HasColumnType("text");

                    b.Property<int>("CoreClock")
                        .HasColumnType("integer");

                    b.Property<int>("CoreClockBoost")
                        .HasColumnType("integer");

                    b.Property<int>("DSub")
                        .HasColumnType("integer");

                    b.Property<int>("DVI")
                        .HasColumnType("integer");

                    b.Property<int>("DataBus")
                        .HasColumnType("integer");

                    b.Property<int>("DisplayPort")
                        .HasColumnType("integer");

                    b.Property<int>("HDMI")
                        .HasColumnType("integer");

                    b.Property<bool>("Led")
                        .HasColumnType("boolean");

                    b.Property<int>("MemoryClock")
                        .HasColumnType("integer");

                    b.Property<int>("NumberOfFans")
                        .HasColumnType("integer");

                    b.Property<string>("Producer")
                        .HasColumnType("text");

                    b.Property<string>("ProducerChipset")
                        .HasColumnType("text");

                    b.Property<string>("ProducerCode")
                        .HasColumnType("text");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<string>("RecommendedPSUPower")
                        .HasColumnType("text");

                    b.Property<string>("Resolution")
                        .HasColumnType("text");

                    b.Property<string>("TypeOfRAM")
                        .HasColumnType("text");

                    b.Property<string>("VerConnectorType")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("GraphicCards");
                });

            modelBuilder.Entity("PC_Store.Models.Motherboard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AudioChannels")
                        .HasColumnType("text");

                    b.Property<string>("Chipset")
                        .HasColumnType("text");

                    b.Property<string>("CombiningCards")
                        .HasColumnType("text");

                    b.Property<string>("ConnectorType")
                        .HasColumnType("text");

                    b.Property<string>("GraphicsChipset")
                        .HasColumnType("text");

                    b.Property<bool>("IntegratedGraphicsCardSupport")
                        .HasColumnType("boolean");

                    b.Property<string>("IntegratedNetworkCard")
                        .HasColumnType("text");

                    b.Property<int>("MaximumAmountOfMemory")
                        .HasColumnType("integer");

                    b.Property<string>("MultiChannelArchitecture")
                        .HasColumnType("text");

                    b.Property<string>("NetworkCardChipset")
                        .HasColumnType("text");

                    b.Property<int>("NumberOfMemorySlots")
                        .HasColumnType("integer");

                    b.Property<int>("PCIExpressx1")
                        .HasColumnType("integer");

                    b.Property<int>("PCIExpressx16")
                        .HasColumnType("integer");

                    b.Property<int>("PCIExpressx4")
                        .HasColumnType("integer");

                    b.Property<string>("Producer")
                        .HasColumnType("text");

                    b.Property<string>("ProducerCode")
                        .HasColumnType("text");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<string>("SocketType")
                        .HasColumnType("text");

                    b.Property<string>("SoundChipset")
                        .HasColumnType("text");

                    b.Property<string>("Standard")
                        .HasColumnType("text");

                    b.Property<string>("StandardMemory")
                        .HasColumnType("text");

                    b.Property<string>("Technologies")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Motherboards");
                });

            modelBuilder.Entity("PC_Store.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AddressLine")
                        .IsRequired()
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("OrderPlaced")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("OrderTotal")
                        .HasColumnType("numeric");

                    b.Property<string>("Payment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("character varying(25)")
                        .HasMaxLength(25);

                    b.Property<bool>("Regulations")
                        .HasColumnType("boolean");

                    b.Property<string>("StatusOrder")
                        .HasColumnType("text");

                    b.Property<string>("User")
                        .HasColumnType("text");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("character varying(10)")
                        .HasMaxLength(10);

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PC_Store.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("ProdId")
                        .HasColumnType("integer");

                    b.Property<int?>("ProductId")
                        .HasColumnType("integer");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("PC_Store.Models.PowerSupply", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ATX24pin204")
                        .HasColumnType("integer");

                    b.Property<bool>("Backlight")
                        .HasColumnType("boolean");

                    b.Property<int>("CPU44pin8")
                        .HasColumnType("integer");

                    b.Property<int>("CPU4pin")
                        .HasColumnType("integer");

                    b.Property<int>("CPU8pin")
                        .HasColumnType("integer");

                    b.Property<string>("CoolingType")
                        .HasColumnType("text");

                    b.Property<int>("Depth")
                        .HasColumnType("integer");

                    b.Property<int>("Diameter")
                        .HasColumnType("integer");

                    b.Property<int>("Efficiency")
                        .HasColumnType("integer");

                    b.Property<string>("EfficiencyCertificate")
                        .HasColumnType("text");

                    b.Property<int>("Height")
                        .HasColumnType("integer");

                    b.Property<string>("ModularCabling")
                        .HasColumnType("text");

                    b.Property<int>("Molex")
                        .HasColumnType("integer");

                    b.Property<int>("PCIE6pin")
                        .HasColumnType("integer");

                    b.Property<int>("PCIE8pin")
                        .HasColumnType("integer");

                    b.Property<int>("PCIE8pin62")
                        .HasColumnType("integer");

                    b.Property<bool>("PFCSystem")
                        .HasColumnType("boolean");

                    b.Property<int>("Power")
                        .HasColumnType("integer");

                    b.Property<string>("Producer")
                        .HasColumnType("text");

                    b.Property<string>("ProducerCode")
                        .HasColumnType("text");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("SATA")
                        .HasColumnType("integer");

                    b.Property<string>("Security")
                        .HasColumnType("text");

                    b.Property<string>("Standard")
                        .HasColumnType("text");

                    b.Property<int>("Width")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("PowerSupplies");
                });

            modelBuilder.Entity("PC_Store.Models.Processor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Architecture")
                        .HasColumnType("integer");

                    b.Property<bool>("Cooling")
                        .HasColumnType("boolean");

                    b.Property<string>("IntegratedGraphics")
                        .HasColumnType("text");

                    b.Property<string>("Line")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("NumberOfCores")
                        .HasColumnType("integer");

                    b.Property<int>("NumberOfThreads")
                        .HasColumnType("integer");

                    b.Property<float>("ProcessorClockFrequency")
                        .HasColumnType("real");

                    b.Property<string>("Producer")
                        .IsRequired()
                        .HasColumnType("character varying(20)")
                        .HasMaxLength(20);

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<string>("SocketType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("TurboMaximumFrequency")
                        .HasColumnType("real");

                    b.Property<string>("TypesOfSupportedMemory")
                        .HasColumnType("text");

                    b.Property<bool>("UnlockedMultiplier")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Processors");
                });

            modelBuilder.Entity("PC_Store.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Act")
                        .HasColumnType("boolean");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("InsertBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifyBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Picture")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("ProductType")
                        .HasColumnType("text");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("PC_Store.Models.Ram", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Backlight")
                        .HasColumnType("boolean");

                    b.Property<string>("ConnectorType")
                        .HasColumnType("text");

                    b.Property<string>("Cooling")
                        .HasColumnType("text");

                    b.Property<string>("Delay")
                        .HasColumnType("text");

                    b.Property<int>("Frequency")
                        .HasColumnType("integer");

                    b.Property<string>("Line")
                        .HasColumnType("text");

                    b.Property<bool>("LowProfile")
                        .HasColumnType("boolean");

                    b.Property<string>("MemoryType")
                        .HasColumnType("text");

                    b.Property<int>("NumberOfModules")
                        .HasColumnType("integer");

                    b.Property<string>("Producer")
                        .HasColumnType("text");

                    b.Property<string>("ProducerCode")
                        .HasColumnType("text");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("TotalCapacity")
                        .HasColumnType("integer");

                    b.Property<float>("Voltage")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Rams");
                });

            modelBuilder.Entity("PC_Store.Models.ShoppingCardItem", b =>
                {
                    b.Property<int>("ShoppingCarditemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<int?>("ProductId")
                        .HasColumnType("integer");

                    b.Property<string>("ShoppingCardId")
                        .HasColumnType("text");

                    b.HasKey("ShoppingCarditemId");

                    b.HasIndex("ProductId");

                    b.ToTable("ShoppingCardItems");
                });

            modelBuilder.Entity("PC_Store.Models.UserPCCreator", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("ComputerCaseProductId")
                        .HasColumnType("integer");

                    b.Property<int?>("GraphicCardProductId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("MotherboardProductId")
                        .HasColumnType("integer");

                    b.Property<int?>("PowerSupplyProductId")
                        .HasColumnType("integer");

                    b.Property<int?>("ProcessorProductId")
                        .HasColumnType("integer");

                    b.Property<int?>("RamProductId")
                        .HasColumnType("integer");

                    b.Property<string>("User")
                        .HasColumnType("text");

                    b.HasKey("Name");

                    b.HasIndex("ComputerCaseProductId");

                    b.HasIndex("GraphicCardProductId");

                    b.HasIndex("MotherboardProductId");

                    b.HasIndex("PowerSupplyProductId");

                    b.HasIndex("ProcessorProductId");

                    b.HasIndex("RamProductId");

                    b.ToTable("userPCCreators");
                });

            modelBuilder.Entity("PC_Store.Views.ViewModels.PCCreator", b =>
                {
                    b.Property<string>("PcCreatorId")
                        .HasColumnType("text");

                    b.Property<int?>("ComputerCaseProductId")
                        .HasColumnType("integer");

                    b.Property<int?>("GraphicCardProductId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("MotherboardProductId")
                        .HasColumnType("integer");

                    b.Property<int?>("PowerSupplyProductId")
                        .HasColumnType("integer");

                    b.Property<int?>("ProcessorProductId")
                        .HasColumnType("integer");

                    b.Property<int?>("RamProductId")
                        .HasColumnType("integer");

                    b.HasKey("PcCreatorId");

                    b.HasIndex("ComputerCaseProductId");

                    b.HasIndex("GraphicCardProductId");

                    b.HasIndex("MotherboardProductId");

                    b.HasIndex("PowerSupplyProductId");

                    b.HasIndex("ProcessorProductId");

                    b.HasIndex("RamProductId");

                    b.ToTable("pCCreators");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PC_Store.Models.OrderDetail", b =>
                {
                    b.HasOne("PC_Store.Models.Order", "Order")
                        .WithMany("OrderLines")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PC_Store.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("PC_Store.Models.ShoppingCardItem", b =>
                {
                    b.HasOne("PC_Store.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("PC_Store.Models.UserPCCreator", b =>
                {
                    b.HasOne("PC_Store.Models.Product", "ComputerCaseProduct")
                        .WithMany()
                        .HasForeignKey("ComputerCaseProductId");

                    b.HasOne("PC_Store.Models.Product", "GraphicCardProduct")
                        .WithMany()
                        .HasForeignKey("GraphicCardProductId");

                    b.HasOne("PC_Store.Models.Product", "MotherboardProduct")
                        .WithMany()
                        .HasForeignKey("MotherboardProductId");

                    b.HasOne("PC_Store.Models.Product", "PowerSupplyProduct")
                        .WithMany()
                        .HasForeignKey("PowerSupplyProductId");

                    b.HasOne("PC_Store.Models.Product", "ProcessorProduct")
                        .WithMany()
                        .HasForeignKey("ProcessorProductId");

                    b.HasOne("PC_Store.Models.Product", "RamProduct")
                        .WithMany()
                        .HasForeignKey("RamProductId");
                });

            modelBuilder.Entity("PC_Store.Views.ViewModels.PCCreator", b =>
                {
                    b.HasOne("PC_Store.Models.Product", "ComputerCaseProduct")
                        .WithMany()
                        .HasForeignKey("ComputerCaseProductId");

                    b.HasOne("PC_Store.Models.Product", "GraphicCardProduct")
                        .WithMany()
                        .HasForeignKey("GraphicCardProductId");

                    b.HasOne("PC_Store.Models.Product", "MotherboardProduct")
                        .WithMany()
                        .HasForeignKey("MotherboardProductId");

                    b.HasOne("PC_Store.Models.Product", "PowerSupplyProduct")
                        .WithMany()
                        .HasForeignKey("PowerSupplyProductId");

                    b.HasOne("PC_Store.Models.Product", "ProcessorProduct")
                        .WithMany()
                        .HasForeignKey("ProcessorProductId");

                    b.HasOne("PC_Store.Models.Product", "RamProduct")
                        .WithMany()
                        .HasForeignKey("RamProductId");
                });
#pragma warning restore 612, 618
        }
    }
}
