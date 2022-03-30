using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HittaHem.Mvc.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HousingTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HousingTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Municipalities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipalities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OwnershipTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnershipTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Streets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Homes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MunicipalityId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomAmount = table.Column<int>(type: "int", nullable: false),
                    LivingArea = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    UninhabitableArea = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    GardenArea = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    HousingTypeId = table.Column<int>(type: "int", nullable: false),
                    OwnershipTypeId = table.Column<int>(type: "int", nullable: false),
                    BuildYear = table.Column<DateTime>(type: "date", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    StreetId = table.Column<int>(type: "int", nullable: false),
                    StreetNr = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Homes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Homes_HousingTypes_HousingTypeId",
                        column: x => x.HousingTypeId,
                        principalTable: "HousingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Homes_Municipalities_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalTable: "Municipalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Homes_OwnershipTypes_OwnershipTypeId",
                        column: x => x.OwnershipTypeId,
                        principalTable: "OwnershipTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Homes_Streets_StreetId",
                        column: x => x.StreetId,
                        principalTable: "Streets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favourite",
                columns: table => new
                {
                    HomeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favourite", x => x.HomeId);
                    table.ForeignKey(
                        name: "FK_Favourite_Homes_HomeId",
                        column: x => x.HomeId,
                        principalTable: "Homes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HomeImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    HomeId = table.Column<int>(type: "int", nullable: false),
                    UploadingDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeImages_Homes_HomeId",
                        column: x => x.HomeId,
                        principalTable: "Homes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HomeViewings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HomeId = table.Column<int>(type: "int", nullable: false),
                    ViewingDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeViewings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeViewings_Homes_HomeId",
                        column: x => x.HomeId,
                        principalTable: "Homes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InterestedUser",
                columns: table => new
                {
                    HomeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestedUser", x => x.HomeId);
                    table.ForeignKey(
                        name: "FK_InterestedUser_Homes_HomeId",
                        column: x => x.HomeId,
                        principalTable: "Homes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HomeImages_HomeId",
                table: "HomeImages",
                column: "HomeId");

            migrationBuilder.CreateIndex(
                name: "IX_Homes_HousingTypeId",
                table: "Homes",
                column: "HousingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Homes_MunicipalityId",
                table: "Homes",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Homes_OwnershipTypeId",
                table: "Homes",
                column: "OwnershipTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Homes_StreetId",
                table: "Homes",
                column: "StreetId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeViewings_HomeId",
                table: "HomeViewings",
                column: "HomeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favourite");

            migrationBuilder.DropTable(
                name: "HomeImages");

            migrationBuilder.DropTable(
                name: "HomeViewings");

            migrationBuilder.DropTable(
                name: "InterestedUser");

            migrationBuilder.DropTable(
                name: "Homes");

            migrationBuilder.DropTable(
                name: "HousingTypes");

            migrationBuilder.DropTable(
                name: "Municipalities");

            migrationBuilder.DropTable(
                name: "OwnershipTypes");

            migrationBuilder.DropTable(
                name: "Streets");
        }
    }
}
