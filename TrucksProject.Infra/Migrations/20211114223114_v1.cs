using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrucksProject.Infra.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ModelTruck",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelTruck", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Truck",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    YearFabrication = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    YearModel = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    IdModelTruck = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Truck", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Truck_ModelTruck_IdModelTruck",
                        column: x => x.IdModelTruck,
                        principalTable: "ModelTruck",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Truck_IdModelTruck",
                table: "Truck",
                column: "IdModelTruck");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Truck");

            migrationBuilder.DropTable(
                name: "ModelTruck");
        }
    }
}
