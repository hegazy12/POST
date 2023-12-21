using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectEweis.Migrations
{
    public partial class lovestring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LOVE_ON_Post_commercial_commercialID",
                table: "LOVE_ON_Post");

            migrationBuilder.DropForeignKey(
                name: "FK_LOVE_ON_Post_real_estate_no_real_estate_noID",
                table: "LOVE_ON_Post");

            migrationBuilder.DropForeignKey(
                name: "FK_LOVE_ON_Post_real_estate_yes_real_estate_yesID",
                table: "LOVE_ON_Post");

            migrationBuilder.DropIndex(
                name: "IX_LOVE_ON_Post_commercialID",
                table: "LOVE_ON_Post");

            migrationBuilder.DropIndex(
                name: "IX_LOVE_ON_Post_real_estate_noID",
                table: "LOVE_ON_Post");

            migrationBuilder.DropIndex(
                name: "IX_LOVE_ON_Post_real_estate_yesID",
                table: "LOVE_ON_Post");

            migrationBuilder.AlterColumn<string>(
                name: "real_estate_yesID",
                table: "LOVE_ON_Post",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "real_estate_noID",
                table: "LOVE_ON_Post",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "commercialID",
                table: "LOVE_ON_Post",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "real_estate_yesID",
                table: "LOVE_ON_Post",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "real_estate_noID",
                table: "LOVE_ON_Post",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "commercialID",
                table: "LOVE_ON_Post",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_LOVE_ON_Post_commercialID",
                table: "LOVE_ON_Post",
                column: "commercialID");

            migrationBuilder.CreateIndex(
                name: "IX_LOVE_ON_Post_real_estate_noID",
                table: "LOVE_ON_Post",
                column: "real_estate_noID");

            migrationBuilder.CreateIndex(
                name: "IX_LOVE_ON_Post_real_estate_yesID",
                table: "LOVE_ON_Post",
                column: "real_estate_yesID");

            migrationBuilder.AddForeignKey(
                name: "FK_LOVE_ON_Post_commercial_commercialID",
                table: "LOVE_ON_Post",
                column: "commercialID",
                principalSchema: "Post",
                principalTable: "commercial",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LOVE_ON_Post_real_estate_no_real_estate_noID",
                table: "LOVE_ON_Post",
                column: "real_estate_noID",
                principalSchema: "Post",
                principalTable: "real_estate_no",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LOVE_ON_Post_real_estate_yes_real_estate_yesID",
                table: "LOVE_ON_Post",
                column: "real_estate_yesID",
                principalSchema: "Post",
                principalTable: "real_estate_yes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
