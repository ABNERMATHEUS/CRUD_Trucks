using Microsoft.EntityFrameworkCore.Migrations;

namespace TruncksProject.Infra.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ModelTrunck",
                column: "Name",
                value: "FH");

            migrationBuilder.InsertData(
                table: "ModelTrunck",
                column: "Name",
                value: "FM");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ModelTrunck",
                keyColumn: "Name",
                keyValue: "FH");

            migrationBuilder.DeleteData(
                table: "ModelTrunck",
                keyColumn: "Name",
                keyValue: "FM");
        }
    }
}
