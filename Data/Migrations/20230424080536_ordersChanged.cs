using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreCet.Data.Migrations
{
    /// <inheritdoc />
    public partial class ordersChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CetUserId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CetUserId",
                table: "Orders",
                column: "CetUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_CetUserId",
                table: "Orders",
                column: "CetUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_CetUserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CetUserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CetUserId",
                table: "Orders");
        }
    }
}
