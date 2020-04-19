using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Buffet.Data.Migrations
{
    public partial class GuestSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    GuestId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgeStatus = table.Column<int>(maxLength: 2000, nullable: false),
                    RoomNr = table.Column<int>(maxLength: 2000, nullable: false),
                    Date = table.Column<DateTime>(maxLength: 2000, nullable: false),
                    Checked = table.Column<bool>(maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.GuestId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Guests");
        }
    }
}
