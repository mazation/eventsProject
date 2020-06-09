using Microsoft.EntityFrameworkCore.Migrations;

namespace EventsApp.Migrations
{
    public partial class Itinitial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserEvents_AspNetUsers_ApplicationUserId1",
                table: "ApplicationUserEvents");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUserEvents_ApplicationUserId1",
                table: "ApplicationUserEvents");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "ApplicationUserEvents");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ApplicationUserEvents",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserEvents_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserEvents",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserEvents_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserEvents");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "ApplicationUserEvents",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "ApplicationUserEvents",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserEvents_ApplicationUserId1",
                table: "ApplicationUserEvents",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserEvents_AspNetUsers_ApplicationUserId1",
                table: "ApplicationUserEvents",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
