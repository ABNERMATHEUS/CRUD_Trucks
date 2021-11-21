using Microsoft.EntityFrameworkCore.Migrations;

namespace TrucksProject.Infra.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ModelTruck",
                column: "Name",
                value: "FH");

            migrationBuilder.InsertData(
                table: "ModelTruck",
                column: "Name",
                value: "FM");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ModelTruck",
                keyColumn: "Name",
                keyValue: "FH");

            migrationBuilder.DeleteData(
                table: "ModelTruck",
                keyColumn: "Name",
                keyValue: "FM");
        }
    }
}
