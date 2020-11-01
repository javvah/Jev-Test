using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace jevtest.Migrations
{
    public partial class rollsmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rollid",
                table: "MyUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserRolls",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Roll = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRolls", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyUsers_Rollid",
                table: "MyUsers",
                column: "Rollid");

            migrationBuilder.AddForeignKey(
                name: "FK_MyUsers_UserRolls_Rollid",
                table: "MyUsers",
                column: "Rollid",
                principalTable: "UserRolls",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyUsers_UserRolls_Rollid",
                table: "MyUsers");

            migrationBuilder.DropTable(
                name: "UserRolls");

            migrationBuilder.DropIndex(
                name: "IX_MyUsers_Rollid",
                table: "MyUsers");

            migrationBuilder.DropColumn(
                name: "Rollid",
                table: "MyUsers");
        }
    }
}
