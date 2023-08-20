using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace example.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updateUserProductView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProducts_AspNetUsers_UserId",
                table: "UserProducts");

            migrationBuilder.DropIndex(
                name: "IX_UserProducts_UserId",
                table: "UserProducts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserProducts");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "UserProducts",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_UserProducts_ApplicationUserId",
                table: "UserProducts",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProducts_AspNetUsers_ApplicationUserId",
                table: "UserProducts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProducts_AspNetUsers_ApplicationUserId",
                table: "UserProducts");

            migrationBuilder.DropIndex(
                name: "IX_UserProducts_ApplicationUserId",
                table: "UserProducts");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "UserProducts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserProducts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserProducts_UserId",
                table: "UserProducts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProducts_AspNetUsers_UserId",
                table: "UserProducts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
