using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectEweis.Migrations
{
    public partial class dd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LOVE_ON_Post",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReactorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<int>(type: "int", nullable: false),
                    commercialID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    real_estate_yesID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    real_estate_noID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOVE_ON_Post", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LOVE_ON_Post_commercial_commercialID",
                        column: x => x.commercialID,
                        principalSchema: "Post",
                        principalTable: "commercial",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LOVE_ON_Post_real_estate_no_real_estate_noID",
                        column: x => x.real_estate_noID,
                        principalSchema: "Post",
                        principalTable: "real_estate_no",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LOVE_ON_Post_real_estate_yes_real_estate_yesID",
                        column: x => x.real_estate_yesID,
                        principalSchema: "Post",
                        principalTable: "real_estate_yes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LOVE_ON_Post_users_ReactorId",
                        column: x => x.ReactorId,
                        principalSchema: "Login",
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LOVE_ON_Post_commercialID",
                table: "LOVE_ON_Post",
                column: "commercialID");

            migrationBuilder.CreateIndex(
                name: "IX_LOVE_ON_Post_ReactorId",
                table: "LOVE_ON_Post",
                column: "ReactorId");

            migrationBuilder.CreateIndex(
                name: "IX_LOVE_ON_Post_real_estate_noID",
                table: "LOVE_ON_Post",
                column: "real_estate_noID");

            migrationBuilder.CreateIndex(
                name: "IX_LOVE_ON_Post_real_estate_yesID",
                table: "LOVE_ON_Post",
                column: "real_estate_yesID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LOVE_ON_Post");
        }
    }
}
