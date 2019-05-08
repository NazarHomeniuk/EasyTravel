using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyTravel.Core.Migrations
{
    public partial class UpdatedMonirotingModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlaBlaCarTrips_BlaBlaCarMonitoring_BlaBlaCarMonitoringId",
                table: "BlaBlaCarTrips");

            migrationBuilder.DropForeignKey(
                name: "FK_BusTrips_BusMonitoring_BusMonitoringId",
                table: "BusTrips");

            migrationBuilder.DropForeignKey(
                name: "FK_RailwayTrips_RailwayMonitoring_RailwayMonitoringId",
                table: "RailwayTrips");

            migrationBuilder.AlterColumn<int>(
                name: "RailwayMonitoringId",
                table: "RailwayTrips",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BusMonitoringId",
                table: "BusTrips",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BlaBlaCarMonitoringId",
                table: "BlaBlaCarTrips",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_BlaBlaCarTrips_BlaBlaCarMonitoring_BlaBlaCarMonitoringId",
                table: "BlaBlaCarTrips",
                column: "BlaBlaCarMonitoringId",
                principalTable: "BlaBlaCarMonitoring",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BusTrips_BusMonitoring_BusMonitoringId",
                table: "BusTrips",
                column: "BusMonitoringId",
                principalTable: "BusMonitoring",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RailwayTrips_RailwayMonitoring_RailwayMonitoringId",
                table: "RailwayTrips",
                column: "RailwayMonitoringId",
                principalTable: "RailwayMonitoring",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlaBlaCarTrips_BlaBlaCarMonitoring_BlaBlaCarMonitoringId",
                table: "BlaBlaCarTrips");

            migrationBuilder.DropForeignKey(
                name: "FK_BusTrips_BusMonitoring_BusMonitoringId",
                table: "BusTrips");

            migrationBuilder.DropForeignKey(
                name: "FK_RailwayTrips_RailwayMonitoring_RailwayMonitoringId",
                table: "RailwayTrips");

            migrationBuilder.AlterColumn<int>(
                name: "RailwayMonitoringId",
                table: "RailwayTrips",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BusMonitoringId",
                table: "BusTrips",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BlaBlaCarMonitoringId",
                table: "BlaBlaCarTrips",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BlaBlaCarTrips_BlaBlaCarMonitoring_BlaBlaCarMonitoringId",
                table: "BlaBlaCarTrips",
                column: "BlaBlaCarMonitoringId",
                principalTable: "BlaBlaCarMonitoring",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BusTrips_BusMonitoring_BusMonitoringId",
                table: "BusTrips",
                column: "BusMonitoringId",
                principalTable: "BusMonitoring",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RailwayTrips_RailwayMonitoring_RailwayMonitoringId",
                table: "RailwayTrips",
                column: "RailwayMonitoringId",
                principalTable: "RailwayMonitoring",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
