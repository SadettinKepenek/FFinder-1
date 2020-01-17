using Microsoft.EntityFrameworkCore.Migrations;

namespace FFinder.Migrations
{
    public partial class Initial_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Followers_User",
                table: "Follower");

            migrationBuilder.CreateIndex(
                name: "IX_Follower_User2Id",
                table: "Follower",
                column: "User2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Followers_User",
                table: "Follower",
                column: "User1Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Follower_AspNetUsers_User2Id",
                table: "Follower",
                column: "User2Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Followers_User",
                table: "Follower");

            migrationBuilder.DropForeignKey(
                name: "FK_Follower_AspNetUsers_User2Id",
                table: "Follower");

            migrationBuilder.DropIndex(
                name: "IX_Follower_User2Id",
                table: "Follower");

            migrationBuilder.AddForeignKey(
                name: "FK_Followers_User",
                table: "Follower",
                column: "User1Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
