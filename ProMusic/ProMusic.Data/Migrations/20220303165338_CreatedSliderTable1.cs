using Microsoft.EntityFrameworkCore.Migrations;

namespace ProMusic.Data.Migrations
{
    public partial class CreatedSliderTable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title1 = table.Column<string>(maxLength: 30, nullable: true),
                    Title2 = table.Column<string>(maxLength: 30, nullable: true),
                    Desc = table.Column<string>(maxLength: 100, nullable: true),
                    BtnText = table.Column<string>(maxLength: 30, nullable: true),
                    BtnUrl = table.Column<string>(maxLength: 100, nullable: true),
                    Order = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sliders");
        }
    }
}
