using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Client.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameRole = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    roleDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    city = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    postalCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    dataInscription = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Userid = table.Column<int>(type: "int", nullable: false),
                    IBAN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    balance = table.Column<int>(type: "int", nullable: false),
                    dateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Users_Userid",
                        column: x => x.Userid,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankTransfers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiverAccountId = table.Column<int>(type: "int", nullable: false),
                    ExpeditorAccountId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Communication = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DateExpedition = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankTransfers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankTransfers_Accounts_ExpeditorAccountId",
                        column: x => x.ExpeditorAccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BankTransfers_Accounts_ReceiverAccountId",
                        column: x => x.ReceiverAccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Userid",
                table: "Accounts",
                column: "Userid");

            migrationBuilder.CreateIndex(
                name: "IX_BankTransfers_ExpeditorAccountId",
                table: "BankTransfers",
                column: "ExpeditorAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_BankTransfers_ReceiverAccountId",
                table: "BankTransfers",
                column: "ReceiverAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankTransfers");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
