using Microsoft.EntityFrameworkCore.Migrations;

namespace jevtest.Migrations
{
    public partial class rollsmig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyUsers_UserRolls_Rollid",
                table: "MyUsers");

            migrationBuilder.AlterColumn<int>(
                name: "Rollid",
                table: "MyUsers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MyUsers_UserRolls_Rollid",
                table: "MyUsers",
                column: "Rollid",
                principalTable: "UserRolls",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyUsers_UserRolls_Rollid",
                table: "MyUsers");

            migrationBuilder.AlterColumn<int>(
                name: "Rollid",
                table: "MyUsers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_MyUsers_UserRolls_Rollid",
                table: "MyUsers",
                column: "Rollid",
                principalTable: "UserRolls",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
