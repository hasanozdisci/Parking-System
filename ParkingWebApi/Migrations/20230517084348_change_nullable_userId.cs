using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingWebApi.Migrations
{
    /// <inheritdoc />
    public partial class change_nullable_userId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parks_Users_UserId",
                table: "Parks");

            migrationBuilder.DropIndex(
                name: "IX_Parks_UserId",
                table: "Parks");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Parks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Parks_UserId",
                table: "Parks",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Parks_Users_UserId",
                table: "Parks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parks_Users_UserId",
                table: "Parks");

            migrationBuilder.DropIndex(
                name: "IX_Parks_UserId",
                table: "Parks");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Parks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parks_UserId",
                table: "Parks",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Parks_Users_UserId",
                table: "Parks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
