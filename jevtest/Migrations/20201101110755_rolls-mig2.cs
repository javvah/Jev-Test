using Microsoft.EntityFrameworkCore.Migrations;

namespace jevtest.Migrations
{
    public partial class rollsmig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Roll",
                table: "UserRolls",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Roll",
                table: "UserRolls",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
