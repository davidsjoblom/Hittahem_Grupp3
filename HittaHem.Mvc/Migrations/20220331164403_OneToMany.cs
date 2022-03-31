using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HittaHem.Mvc.Migrations
{
    public partial class OneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "HomeImages",
                newName: "HomeImageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HomeImageId",
                table: "HomeImages",
                newName: "Id");
        }
    }
}
