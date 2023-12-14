using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_InventoryManagement.Migrations
{
    public partial class v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OutputDetails",
                table: "OutputDetails");

            migrationBuilder.AlterColumn<string>(
                name: "InputId",
                table: "OutputDetails",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OutputDetails",
                table: "OutputDetails",
                columns: new[] { "OutputId", "ProductId", "InputId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OutputDetails",
                table: "OutputDetails");

            migrationBuilder.AlterColumn<string>(
                name: "InputId",
                table: "OutputDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OutputDetails",
                table: "OutputDetails",
                columns: new[] { "OutputId", "ProductId" });
        }
    }
}
