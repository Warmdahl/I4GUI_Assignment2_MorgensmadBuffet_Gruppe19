using Microsoft.EntityFrameworkCore.Migrations;

namespace Buffet.Data.Migrations
{
    public partial class GuestSchema03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgeStatusID",
                table: "Guests");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AgeStatusID",
                table: "Guests",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);
        }
    }
}
