using Microsoft.EntityFrameworkCore.Migrations;

namespace ProMusic.Data.Migrations
{
    public partial class ChangesOnAppUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSubCategory",
                table: "Categories",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSubCategory",
                table: "Categories");
        }
    }
}
