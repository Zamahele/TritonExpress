using Microsoft.EntityFrameworkCore.Migrations;

namespace TritonExpress.API.Persistence.Migrations
{
    public partial class UpdatingTheVehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Vehicles");
        }
    }
}
