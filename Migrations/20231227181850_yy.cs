using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectEweis.Migrations
{
    public partial class yy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Post");

            migrationBuilder.EnsureSchema(
                name: "Notifacations");

            migrationBuilder.EnsureSchema(
                name: "Login");

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiverId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    When = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    RequestId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifacationse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotifyType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotifyText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Usr_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Post_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Request_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifacationse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "Login",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "Login",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaim",
                schema: "Login",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaim_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Login",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "commercial",
                schema: "Post",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    partner_type = table.Column<int>(type: "int", nullable: false),
                    city_id = table.Column<int>(type: "int", nullable: false),
                    investment_cost = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    partners_count = table.Column<int>(type: "int", nullable: false),
                    project_status = table.Column<int>(type: "int", nullable: false),
                    user_contribution = table.Column<int>(type: "int", nullable: false),
                    other_contribution = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_commercial", x => x.ID);
                    table.ForeignKey(
                        name: "FK_commercial_users_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "Login",
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LOVE_ON_Post",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReactorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<int>(type: "int", nullable: false),
                    commercialID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    real_estate_yesID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    real_estate_noID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOVE_ON_Post", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LOVE_ON_Post_users_ReactorId",
                        column: x => x.ReactorId,
                        principalSchema: "Login",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Partnership_Proposals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Islocation_suitable = table.Column<bool>(type: "bit", nullable: false),
                    Ispartnership_amount_appropriate = table.Column<bool>(type: "bit", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partnership_Proposals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partnership_Proposals_users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Login",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "real_estate_no",
                schema: "Post",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    purpose = table.Column<int>(type: "int", nullable: false),
                    property_type = table.Column<int>(type: "int", nullable: false),
                    property_area = table.Column<int>(type: "int", nullable: false),
                    directions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    street_width = table.Column<int>(type: "int", nullable: false),
                    negotiable = table.Column<int>(type: "int", nullable: false),
                    Neighborhood = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    needs_money = table.Column<int>(type: "int", nullable: false),
                    partner_type = table.Column<int>(type: "int", nullable: false),
                    city_id = table.Column<int>(type: "int", nullable: false),
                    investment_cost = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    partners_count = table.Column<int>(type: "int", nullable: false),
                    partnerNeighborhoods = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_real_estate_no", x => x.ID);
                    table.ForeignKey(
                        name: "FK_real_estate_no_users_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "Login",
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "real_estate_yes",
                schema: "Post",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    purpose = table.Column<int>(type: "int", nullable: false),
                    property_type = table.Column<int>(type: "int", nullable: false),
                    property_area = table.Column<int>(type: "int", nullable: false),
                    directions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    street_width = table.Column<int>(type: "int", nullable: false),
                    negotiable = table.Column<int>(type: "int", nullable: false),
                    partnerNeighborhoods = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    needs_money = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    partner_type = table.Column<int>(type: "int", nullable: false),
                    city_id = table.Column<int>(type: "int", nullable: false),
                    investment_cost = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    partners_count = table.Column<int>(type: "int", nullable: false),
                    images = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    plan_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    property_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    property_age = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_real_estate_yes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_real_estate_yes_users_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "Login",
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserClaim",
                schema: "Login",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaim_users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Login",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                schema: "Login",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogin_users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Login",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                schema: "Login",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Login",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Login",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                schema: "Login",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserToken_users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Login",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifacation",
                schema: "Notifacations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequesterId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ISpecificationsOK = table.Column<int>(type: "int", nullable: false),
                    ISAmountofMoneyOK = table.Column<int>(type: "int", nullable: false),
                    SuggestedAmount = table.Column<int>(type: "int", nullable: false),
                    commercialID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    real_estate_yesID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    real_estate_noID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<int>(type: "int", nullable: false),
                    Approvalstate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifacation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifacation_commercial_commercialID",
                        column: x => x.commercialID,
                        principalSchema: "Post",
                        principalTable: "commercial",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notifacation_real_estate_no_real_estate_noID",
                        column: x => x.real_estate_noID,
                        principalSchema: "Post",
                        principalTable: "real_estate_no",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notifacation_real_estate_yes_real_estate_yesID",
                        column: x => x.real_estate_yesID,
                        principalSchema: "Post",
                        principalTable: "real_estate_yes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notifacation_users_RequesterId",
                        column: x => x.RequesterId,
                        principalSchema: "Login",
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_commercial_OwnerId",
                schema: "Post",
                table: "commercial",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_LOVE_ON_Post_ReactorId",
                table: "LOVE_ON_Post",
                column: "ReactorId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifacation_commercialID",
                schema: "Notifacations",
                table: "Notifacation",
                column: "commercialID");

            migrationBuilder.CreateIndex(
                name: "IX_Notifacation_real_estate_noID",
                schema: "Notifacations",
                table: "Notifacation",
                column: "real_estate_noID");

            migrationBuilder.CreateIndex(
                name: "IX_Notifacation_real_estate_yesID",
                schema: "Notifacations",
                table: "Notifacation",
                column: "real_estate_yesID");

            migrationBuilder.CreateIndex(
                name: "IX_Notifacation_RequesterId",
                schema: "Notifacations",
                table: "Notifacation",
                column: "RequesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Partnership_Proposals_UserId",
                table: "Partnership_Proposals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_real_estate_no_OwnerId",
                schema: "Post",
                table: "real_estate_no",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_real_estate_yes_OwnerId",
                schema: "Post",
                table: "real_estate_yes",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Login",
                table: "Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaim_RoleId",
                schema: "Login",
                table: "RoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaim_UserId",
                schema: "Login",
                table: "UserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogin_UserId",
                schema: "Login",
                table: "UserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                schema: "Login",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Login",
                table: "users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Login",
                table: "users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LOVE_ON_Post");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Notifacation",
                schema: "Notifacations");

            migrationBuilder.DropTable(
                name: "Notifacationse");

            migrationBuilder.DropTable(
                name: "Partnership_Proposals");

            migrationBuilder.DropTable(
                name: "RoleClaim",
                schema: "Login");

            migrationBuilder.DropTable(
                name: "UserClaim",
                schema: "Login");

            migrationBuilder.DropTable(
                name: "UserLogin",
                schema: "Login");

            migrationBuilder.DropTable(
                name: "UserRole",
                schema: "Login");

            migrationBuilder.DropTable(
                name: "UserToken",
                schema: "Login");

            migrationBuilder.DropTable(
                name: "commercial",
                schema: "Post");

            migrationBuilder.DropTable(
                name: "real_estate_no",
                schema: "Post");

            migrationBuilder.DropTable(
                name: "real_estate_yes",
                schema: "Post");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "Login");

            migrationBuilder.DropTable(
                name: "users",
                schema: "Login");
        }
    }
}
