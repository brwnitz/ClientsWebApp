using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientsWebApp.Data.Migrations
{
    public partial class categories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "UsersModel");

            migrationBuilder.CreateTable(
                name: "GainsCategory",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Gain = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GainsCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpendingCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Spending = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpendingCategory", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GainsCategory");

            migrationBuilder.DropTable(
                name: "SpendingCategory");

            migrationBuilder.AddColumn<string>(
                name: "Price",
                table: "UsersModel",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
