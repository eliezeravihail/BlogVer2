using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogVer2.Migrations
{
    public partial class iupdateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_User_WriterID",
                table: "Post");

            migrationBuilder.RenameColumn(
                name: "WriterID",
                table: "Post",
                newName: "WriterId");

            migrationBuilder.RenameIndex(
                name: "IX_Post_WriterID",
                table: "Post",
                newName: "IX_Post_WriterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_User_WriterId",
                table: "Post",
                column: "WriterId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_User_WriterId",
                table: "Post");

            migrationBuilder.RenameColumn(
                name: "WriterId",
                table: "Post",
                newName: "WriterID");

            migrationBuilder.RenameIndex(
                name: "IX_Post_WriterId",
                table: "Post",
                newName: "IX_Post_WriterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_User_WriterID",
                table: "Post",
                column: "WriterID",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
