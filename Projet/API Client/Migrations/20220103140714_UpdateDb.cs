using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Client.Migrations
{
    public partial class UpdateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "dataInscription",
                table: "Users",
                newName: "dateInscription");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "dateInscription",
                table: "Users",
                newName: "dataInscription");
        }
    }
}
