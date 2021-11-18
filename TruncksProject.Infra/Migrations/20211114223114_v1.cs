using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TruncksProject.Infra.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ModelTrunck",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelTrunck", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Trunck",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    YearFabrication = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    YearModel = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    IdModelTrunck = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trunck", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trunck_ModelTrunck_IdModelTrunck",
                        column: x => x.IdModelTrunck,
                        principalTable: "ModelTrunck",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trunck_IdModelTrunck",
                table: "Trunck",
                column: "IdModelTrunck");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trunck");

            migrationBuilder.DropTable(
                name: "ModelTrunck");
        }
    }
}
