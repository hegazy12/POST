using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectEweis.Migrations
{
    public partial class Love_On_POST : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LOVE_ON_Post_users_ReactorId",
                table: "LOVE_ON_Post");

            migrationBuilder.AlterColumn<string>(
                name: "ReactorId",
                table: "LOVE_ON_Post",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LOVE_ON_Post_users_ReactorId",
                table: "LOVE_ON_Post",
                column: "ReactorId",
                principalSchema: "Login",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LOVE_ON_Post_users_ReactorId",
                table: "LOVE_ON_Post");

            migrationBuilder.AlterColumn<string>(
                name: "ReactorId",
                table: "LOVE_ON_Post",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_LOVE_ON_Post_users_ReactorId",
                table: "LOVE_ON_Post",
                column: "ReactorId",
                principalSchema: "Login",
                principalTable: "users",
                principalColumn: "Id");
        }
    }
}
