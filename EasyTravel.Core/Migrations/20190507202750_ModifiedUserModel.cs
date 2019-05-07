using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyTravel.Core.Migrations
{
    public partial class ModifiedUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Guid",
                table: "RailwayMonitoring",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "RailwayMonitoring",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Guid",
                table: "BusMonitoring",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "BusMonitoring",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Guid",
                table: "BlaBlaCarMonitoring",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "BlaBlaCarMonitoring",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RailwayMonitoring_UserId",
                table: "RailwayMonitoring",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BusMonitoring_UserId",
                table: "BusMonitoring",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BlaBlaCarMonitoring_UserId",
                table: "BlaBlaCarMonitoring",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlaBlaCarMonitoring_AspNetUsers_UserId",
                table: "BlaBlaCarMonitoring",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BusMonitoring_AspNetUsers_UserId",
                table: "BusMonitoring",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RailwayMonitoring_AspNetUsers_UserId",
                table: "RailwayMonitoring",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlaBlaCarMonitoring_AspNetUsers_UserId",
                table: "BlaBlaCarMonitoring");

            migrationBuilder.DropForeignKey(
                name: "FK_BusMonitoring_AspNetUsers_UserId",
                table: "BusMonitoring");

            migrationBuilder.DropForeignKey(
                name: "FK_RailwayMonitoring_AspNetUsers_UserId",
                table: "RailwayMonitoring");

            migrationBuilder.DropIndex(
                name: "IX_RailwayMonitoring_UserId",
                table: "RailwayMonitoring");

            migrationBuilder.DropIndex(
                name: "IX_BusMonitoring_UserId",
                table: "BusMonitoring");

            migrationBuilder.DropIndex(
                name: "IX_BlaBlaCarMonitoring_UserId",
                table: "BlaBlaCarMonitoring");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "RailwayMonitoring");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "RailwayMonitoring");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "BusMonitoring");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BusMonitoring");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "BlaBlaCarMonitoring");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BlaBlaCarMonitoring");
        }
    }
}
