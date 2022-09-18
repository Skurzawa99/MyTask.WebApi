using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTasks.WebApi.Migrations
{
    public partial class ChangeUserIdTypeFromIntToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_ApplicationUsers_UserId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId1",
                table: "Tasks",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_ApplicationUsers_UserId1",
                table: "Tasks",
                column: "UserId1",
                principalTable: "ApplicationUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_ApplicationUsers_UserId1",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_UserId1",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Tasks");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_ApplicationUsers_UserId",
                table: "Tasks",
                column: "UserId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
