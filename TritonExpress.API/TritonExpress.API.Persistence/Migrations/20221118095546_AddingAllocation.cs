using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TritonExpress.API.Persistence.Migrations
{
    public partial class AddingAllocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Vehicles_VehicleId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_WayBills_WayBillId",
                table: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locations",
                table: "Locations");

            migrationBuilder.RenameTable(
                name: "Locations",
                newName: "AllLocations");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_WayBillId",
                table: "AllLocations",
                newName: "IX_AllLocations_WayBillId");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_VehicleId",
                table: "AllLocations",
                newName: "IX_AllLocations_VehicleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AllLocations",
                table: "AllLocations",
                column: "AllocationId");

            //migrationBuilder.CreateTable(
            //    name: "AspNetUsers",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
            //        PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
            //        TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
            //        LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
            //        LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
            //        AccessFailedCount = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUsers", x => x.Id);
            //    });

            migrationBuilder.AddForeignKey(
                name: "FK_AllLocations_Vehicles_VehicleId",
                table: "AllLocations",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "VehicleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AllLocations_WayBills_WayBillId",
                table: "AllLocations",
                column: "WayBillId",
                principalTable: "WayBills",
                principalColumn: "WayBillId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllLocations_Vehicles_VehicleId",
                table: "AllLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_AllLocations_WayBills_WayBillId",
                table: "AllLocations");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AllLocations",
                table: "AllLocations");

            migrationBuilder.RenameTable(
                name: "AllLocations",
                newName: "Locations");

            migrationBuilder.RenameIndex(
                name: "IX_AllLocations_WayBillId",
                table: "Locations",
                newName: "IX_Locations_WayBillId");

            migrationBuilder.RenameIndex(
                name: "IX_AllLocations_VehicleId",
                table: "Locations",
                newName: "IX_Locations_VehicleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locations",
                table: "Locations",
                column: "AllocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Vehicles_VehicleId",
                table: "Locations",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "VehicleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_WayBills_WayBillId",
                table: "Locations",
                column: "WayBillId",
                principalTable: "WayBills",
                principalColumn: "WayBillId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
