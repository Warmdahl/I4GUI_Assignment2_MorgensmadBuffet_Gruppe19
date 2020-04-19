using Microsoft.EntityFrameworkCore.Migrations;

namespace Buffet.Data.Migrations
{
    public partial class GuestSchema02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AgeStatusID",
                table: "Guests",
                maxLength: 450,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgeStatusID",
                table: "Guests");
        }
    }
}
