using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectEweis.Migrations
{
    public partial class dd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notifyobject",
                table: "Notifacationse",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notifyobject",
                table: "Notifacationse");
        }
    }
}
