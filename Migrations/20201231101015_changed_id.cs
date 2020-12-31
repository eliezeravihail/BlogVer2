using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogVer2.Migrations
{
    public partial class changed_id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Post_PostID",
                table: "Tag");

            migrationBuilder.RenameColumn(
                name: "PostID",
                table: "Tag",
                newName: "PostId");

            migrationBuilder.RenameIndex(
                name: "IX_Tag_PostID",
                table: "Tag",
                newName: "IX_Tag_PostId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Post",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Post_PostId",
                table: "Tag",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Post_PostId",
                table: "Tag");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "Tag",
                newName: "PostID");

            migrationBuilder.RenameIndex(
                name: "IX_Tag_PostId",
                table: "Tag",
                newName: "IX_Tag_PostID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Post",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Post_PostID",
                table: "Tag",
                column: "PostID",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
