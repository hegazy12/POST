using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectEweis.Migrations
{
    public partial class notifacation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notifacations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotifyType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotifyText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifacations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifacations");
        }
    }
}
