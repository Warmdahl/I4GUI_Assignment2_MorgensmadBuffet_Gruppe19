using Microsoft.EntityFrameworkCore.Migrations;

namespace Buffet.Data.Migrations
{
    public partial class GuestSchema04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AgeStatus",
                table: "Guests",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AgeStatus",
                table: "Guests",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 5,
                oldNullable: true);
        }
    }
}
