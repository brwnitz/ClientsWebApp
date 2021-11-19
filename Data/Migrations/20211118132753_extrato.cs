using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientsWebApp.Data.Migrations
{
    public partial class extrato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Price",
                table: "UsersModel",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "UsersModel");
        }
    }
}
