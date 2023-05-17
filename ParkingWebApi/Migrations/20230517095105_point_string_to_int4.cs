using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingWebApi.Migrations
{
    /// <inheritdoc />
    public partial class point_string_to_int4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Parks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Parks",
                type: "int",
                nullable: true);
        }
    }
}
