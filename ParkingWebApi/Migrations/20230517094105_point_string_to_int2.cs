using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingWebApi.Migrations
{
    /// <inheritdoc />
    public partial class point_string_to_int2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Parks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parks_CarId",
                table: "Parks",
                column: "CarId",
                unique: true,
                filter: "[CarId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Parks_Cars_CarId",
                table: "Parks",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parks_Cars_CarId",
                table: "Parks");

            migrationBuilder.DropIndex(
                name: "IX_Parks_CarId",
                table: "Parks");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Parks");
        }
    }
}
