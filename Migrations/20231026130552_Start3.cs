using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Job_Api.Migrations
{
    /// <inheritdoc />
    public partial class Start3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interview_Applications_ApplicationId",
                table: "Interview");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Interview",
                table: "Interview");

            migrationBuilder.RenameTable(
                name: "Interview",
                newName: "Interviews");

            migrationBuilder.RenameIndex(
                name: "IX_Interview_ApplicationId",
                table: "Interviews",
                newName: "IX_Interviews_ApplicationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Interviews",
                table: "Interviews",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_Applications_ApplicationId",
                table: "Interviews",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_Applications_ApplicationId",
                table: "Interviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Interviews",
                table: "Interviews");

            migrationBuilder.RenameTable(
                name: "Interviews",
                newName: "Interview");

            migrationBuilder.RenameIndex(
                name: "IX_Interviews_ApplicationId",
                table: "Interview",
                newName: "IX_Interview_ApplicationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Interview",
                table: "Interview",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Interview_Applications_ApplicationId",
                table: "Interview",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
