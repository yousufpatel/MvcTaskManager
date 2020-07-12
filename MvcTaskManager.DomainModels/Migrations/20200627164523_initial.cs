using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcTaskManager.DomainModels.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "countryID",
                table: "Users",
                newName: "CountryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CountryID",
                table: "Users",
                newName: "countryID");
        }
    }
}
