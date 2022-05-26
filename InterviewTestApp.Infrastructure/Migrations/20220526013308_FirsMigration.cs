using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterviewTestApp.Infrastructure.Migrations
{
    public partial class FirsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "healthCheck",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_healthCheck", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "lstWeatherType",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lstWeatherType", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "weatherForecast",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WeatherTypeId = table.Column<int>(type: "int", nullable: false),
                    tempc = table.Column<double>(type: "float", nullable: false),
                    description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_weatherForecast", x => x.id);
                    table.ForeignKey(
                        name: "FK_weatherForecast_lstWeatherType_WeatherTypeId",
                        column: x => x.WeatherTypeId,
                        principalTable: "lstWeatherType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "healthCheck",
                columns: new[] { "id", "message" },
                values: new object[,]
                {
                    { 1, "OH NO!" },
                    { 2, "Everything is OK!" }
                });

            migrationBuilder.InsertData(
                table: "lstWeatherType",
                columns: new[] { "id", "type" },
                values: new object[,]
                {
                    { 1, "Rain" },
                    { 2, "Snow" },
                    { 3, "Sun" }
                });

            migrationBuilder.InsertData(
                table: "weatherForecast",
                columns: new[] { "id", "date", "description", "tempc", "WeatherTypeId" },
                values: new object[] { new Guid("3f9cd820-0750-4237-8fb9-263cfebe7c84"), new DateTime(2022, 5, 25, 19, 33, 8, 464, DateTimeKind.Local).AddTicks(2108), "Hot Weather!", 40.0, 3 });

            migrationBuilder.InsertData(
                table: "weatherForecast",
                columns: new[] { "id", "date", "description", "tempc", "WeatherTypeId" },
                values: new object[] { new Guid("c2c72824-3313-483b-8648-002ebd14c90e"), new DateTime(2022, 5, 25, 19, 33, 8, 464, DateTimeKind.Local).AddTicks(2054), "Dreary Weather!", 20.0, 1 });

            migrationBuilder.InsertData(
                table: "weatherForecast",
                columns: new[] { "id", "date", "description", "tempc", "WeatherTypeId" },
                values: new object[] { new Guid("cf25592f-8fa4-4ec4-b0da-cf5c120e8cc4"), new DateTime(2022, 5, 25, 19, 33, 8, 464, DateTimeKind.Local).AddTicks(2105), "Cold Weather!", 5.0, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_weatherForecast_WeatherTypeId",
                table: "weatherForecast",
                column: "WeatherTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "healthCheck");

            migrationBuilder.DropTable(
                name: "weatherForecast");

            migrationBuilder.DropTable(
                name: "lstWeatherType");
        }
    }
}
