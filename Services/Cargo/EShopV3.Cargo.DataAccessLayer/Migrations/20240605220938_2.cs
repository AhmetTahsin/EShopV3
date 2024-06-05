using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EShopV3.Cargo.DataAccessLayer.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CargoCampanyName",
                table: "CargoCompanies",
                newName: "CargoCompanyName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CargoCompanyName",
                table: "CargoCompanies",
                newName: "CargoCampanyName");
        }
    }
}
