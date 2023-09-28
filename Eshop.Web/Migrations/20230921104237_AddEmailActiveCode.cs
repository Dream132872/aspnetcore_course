using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eshop.Web.Migrations
{
    public partial class AddEmailActiveCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailActiveCode",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailActiveCode",
                table: "Users");
        }
    }
}
