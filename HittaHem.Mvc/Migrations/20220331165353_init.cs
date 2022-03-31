using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HittaHem.Mvc.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeImages_Homes_HomeId",
                table: "HomeImages");

            migrationBuilder.RenameColumn(
                name: "HomeImageId",
                table: "HomeImages",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "HomeId",
                table: "HomeImages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeImages_Homes_HomeId",
                table: "HomeImages",
                column: "HomeId",
                principalTable: "Homes",
                principalColumn: "HomeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeImages_Homes_HomeId",
                table: "HomeImages");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "HomeImages",
                newName: "HomeImageId");

            migrationBuilder.AlterColumn<int>(
                name: "HomeId",
                table: "HomeImages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeImages_Homes_HomeId",
                table: "HomeImages",
                column: "HomeId",
                principalTable: "Homes",
                principalColumn: "HomeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
