using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyTravel.Core.Migrations
{
    public partial class ModifiedMonitoringField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MinPlaces",
                table: "RailwayMonitoring",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PlacesType",
                table: "RailwayMonitoring",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinPlaces",
                table: "BlaBlaCarMonitoring",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinPlaces",
                table: "RailwayMonitoring");

            migrationBuilder.DropColumn(
                name: "PlacesType",
                table: "RailwayMonitoring");

            migrationBuilder.DropColumn(
                name: "MinPlaces",
                table: "BlaBlaCarMonitoring");
        }
    }
}
