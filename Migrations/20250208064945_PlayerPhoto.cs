using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_Demo_1.Migrations
{
    public partial class PlayerPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlayerPhotopath",
                table: "Players",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlayerPhotopath",
                table: "Players");
        }
    }
}
