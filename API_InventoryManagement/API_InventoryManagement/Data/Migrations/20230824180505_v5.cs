using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_InventoryManagement.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InputId",
                table: "OutputDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InputId",
                table: "OutputDetails");
        }
    }
}
