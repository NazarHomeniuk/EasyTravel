using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyTravel.Core.Migrations
{
    public partial class AddedNewModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlaBlaCarMonitoring",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    From = table.Column<string>(nullable: true),
                    To = table.Column<string>(nullable: true),
                    DepartureDate = table.Column<DateTime>(nullable: false),
                    IsInProcess = table.Column<bool>(nullable: false),
                    IsSuccessful = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlaBlaCarMonitoring", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusMonitoring",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    From = table.Column<string>(nullable: true),
                    To = table.Column<string>(nullable: true),
                    DepartureDate = table.Column<DateTime>(nullable: false),
                    IsInProcess = table.Column<bool>(nullable: false),
                    IsSuccessful = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusMonitoring", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Model = table.Column<string>(nullable: true),
                    Make = table.Column<string>(nullable: true),
                    Comfort = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Child",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MinDate = table.Column<string>(nullable: true),
                    MaxDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Child", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Distance",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<decimal>(nullable: false),
                    Unity = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Duration",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<decimal>(nullable: false),
                    Unity = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duration", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Self = table.Column<string>(nullable: true),
                    Front = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Place",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CityName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    CountryCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Place", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Price",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<decimal>(nullable: false),
                    Currency = table.Column<string>(nullable: true),
                    Symbol = table.Column<string>(nullable: true),
                    StringValue = table.Column<string>(nullable: true),
                    PriceColor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Price", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RailwayMonitoring",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    From = table.Column<string>(nullable: true),
                    To = table.Column<string>(nullable: true),
                    DepartureDate = table.Column<DateTime>(nullable: false),
                    IsInProcess = table.Column<bool>(nullable: false),
                    IsSuccessful = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RailwayMonitoring", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Station",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    StationName = table.Column<string>(nullable: true),
                    StationTrain = table.Column<string>(nullable: true),
                    Date = table.Column<string>(nullable: true),
                    Time = table.Column<TimeSpan>(nullable: false),
                    SortTime = table.Column<string>(nullable: true),
                    SrcDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Station", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusTrips",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    From = table.Column<string>(nullable: true),
                    FromCode = table.Column<string>(nullable: true),
                    ToCode = table.Column<string>(nullable: true),
                    BusCode = table.Column<string>(nullable: true),
                    LocalPointFrom = table.Column<string>(nullable: true),
                    LocalPointTo = table.Column<string>(nullable: true),
                    RoundNum = table.Column<string>(nullable: true),
                    To = table.Column<string>(nullable: true),
                    DepartureTime = table.Column<TimeSpan>(nullable: false),
                    ArrivalTime = table.Column<TimeSpan>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    DepartureDate = table.Column<DateTime>(nullable: false),
                    ArrivalDate = table.Column<DateTime>(nullable: false),
                    Distance = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    BusName = table.Column<string>(nullable: true),
                    BookingLink = table.Column<string>(nullable: true),
                    BusMonitoringId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusTrips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusTrips_BusMonitoring_BusMonitoringId",
                        column: x => x.BusMonitoringId,
                        principalTable: "BusMonitoring",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlaBlaCarTrips",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LinksId = table.Column<int>(nullable: true),
                    DepartureDate = table.Column<DateTime>(nullable: false),
                    ArrivalDate = table.Column<DateTime>(nullable: false),
                    DeparturePlaceId = table.Column<int>(nullable: true),
                    ArrivalPlaceId = table.Column<int>(nullable: true),
                    PriceId = table.Column<int>(nullable: true),
                    SeatsLeft = table.Column<int>(nullable: false),
                    Seats = table.Column<int>(nullable: false),
                    DurationId = table.Column<int>(nullable: true),
                    DistanceId = table.Column<int>(nullable: true),
                    CarId = table.Column<string>(nullable: true),
                    BlaBlaCarMonitoringId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlaBlaCarTrips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlaBlaCarTrips_Place_ArrivalPlaceId",
                        column: x => x.ArrivalPlaceId,
                        principalTable: "Place",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BlaBlaCarTrips_BlaBlaCarMonitoring_BlaBlaCarMonitoringId",
                        column: x => x.BlaBlaCarMonitoringId,
                        principalTable: "BlaBlaCarMonitoring",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlaBlaCarTrips_Car_CarId",
                        column: x => x.CarId,
                        principalTable: "Car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BlaBlaCarTrips_Place_DeparturePlaceId",
                        column: x => x.DeparturePlaceId,
                        principalTable: "Place",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BlaBlaCarTrips_Distance_DistanceId",
                        column: x => x.DistanceId,
                        principalTable: "Distance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BlaBlaCarTrips_Duration_DurationId",
                        column: x => x.DurationId,
                        principalTable: "Duration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BlaBlaCarTrips_Links_LinksId",
                        column: x => x.LinksId,
                        principalTable: "Links",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BlaBlaCarTrips_Price_PriceId",
                        column: x => x.PriceId,
                        principalTable: "Price",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RailwayTrips",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Num = table.Column<string>(nullable: true),
                    Category = table.Column<int>(nullable: false),
                    DepartureDate = table.Column<DateTime>(nullable: false),
                    ArrivalDate = table.Column<DateTime>(nullable: false),
                    IsTransformer = table.Column<int>(nullable: false),
                    TravelTime = table.Column<string>(nullable: true),
                    FromId = table.Column<int>(nullable: true),
                    ToId = table.Column<int>(nullable: true),
                    ChildId = table.Column<int>(nullable: true),
                    AllowStudent = table.Column<int>(nullable: false),
                    AllowBooking = table.Column<int>(nullable: false),
                    IsCis = table.Column<int>(nullable: false),
                    IsEurope = table.Column<int>(nullable: false),
                    AllowPrivilege = table.Column<int>(nullable: false),
                    NoReserve = table.Column<int>(nullable: false),
                    BookingLink = table.Column<string>(nullable: true),
                    RailwayMonitoringId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RailwayTrips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RailwayTrips_Child_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Child",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RailwayTrips_Station_FromId",
                        column: x => x.FromId,
                        principalTable: "Station",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RailwayTrips_RailwayMonitoring_RailwayMonitoringId",
                        column: x => x.RailwayMonitoringId,
                        principalTable: "RailwayMonitoring",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RailwayTrips_Station_ToId",
                        column: x => x.ToId,
                        principalTable: "Station",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeId = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Letter = table.Column<string>(nullable: true),
                    Places = table.Column<long>(nullable: false),
                    TrainId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Type_RailwayTrips_TrainId",
                        column: x => x.TrainId,
                        principalTable: "RailwayTrips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlaBlaCarTrips_ArrivalPlaceId",
                table: "BlaBlaCarTrips",
                column: "ArrivalPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_BlaBlaCarTrips_BlaBlaCarMonitoringId",
                table: "BlaBlaCarTrips",
                column: "BlaBlaCarMonitoringId");

            migrationBuilder.CreateIndex(
                name: "IX_BlaBlaCarTrips_CarId",
                table: "BlaBlaCarTrips",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_BlaBlaCarTrips_DeparturePlaceId",
                table: "BlaBlaCarTrips",
                column: "DeparturePlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_BlaBlaCarTrips_DistanceId",
                table: "BlaBlaCarTrips",
                column: "DistanceId");

            migrationBuilder.CreateIndex(
                name: "IX_BlaBlaCarTrips_DurationId",
                table: "BlaBlaCarTrips",
                column: "DurationId");

            migrationBuilder.CreateIndex(
                name: "IX_BlaBlaCarTrips_LinksId",
                table: "BlaBlaCarTrips",
                column: "LinksId");

            migrationBuilder.CreateIndex(
                name: "IX_BlaBlaCarTrips_PriceId",
                table: "BlaBlaCarTrips",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_BusTrips_BusMonitoringId",
                table: "BusTrips",
                column: "BusMonitoringId");

            migrationBuilder.CreateIndex(
                name: "IX_RailwayTrips_ChildId",
                table: "RailwayTrips",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_RailwayTrips_FromId",
                table: "RailwayTrips",
                column: "FromId");

            migrationBuilder.CreateIndex(
                name: "IX_RailwayTrips_RailwayMonitoringId",
                table: "RailwayTrips",
                column: "RailwayMonitoringId");

            migrationBuilder.CreateIndex(
                name: "IX_RailwayTrips_ToId",
                table: "RailwayTrips",
                column: "ToId");

            migrationBuilder.CreateIndex(
                name: "IX_Type_TrainId",
                table: "Type",
                column: "TrainId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlaBlaCarTrips");

            migrationBuilder.DropTable(
                name: "BusTrips");

            migrationBuilder.DropTable(
                name: "Type");

            migrationBuilder.DropTable(
                name: "Place");

            migrationBuilder.DropTable(
                name: "BlaBlaCarMonitoring");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Distance");

            migrationBuilder.DropTable(
                name: "Duration");

            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "Price");

            migrationBuilder.DropTable(
                name: "BusMonitoring");

            migrationBuilder.DropTable(
                name: "RailwayTrips");

            migrationBuilder.DropTable(
                name: "Child");

            migrationBuilder.DropTable(
                name: "Station");

            migrationBuilder.DropTable(
                name: "RailwayMonitoring");
        }
    }
}
