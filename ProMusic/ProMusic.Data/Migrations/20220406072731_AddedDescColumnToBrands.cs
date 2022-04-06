using Microsoft.EntityFrameworkCore.Migrations;

namespace ProMusic.Data.Migrations
{
    public partial class AddedDescColumnToBrands : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "Brands",
                maxLength: 400,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desc",
                table: "Brands");
        }
    }
}
