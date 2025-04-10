using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_Demo_1.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlayerName = table.Column<string>(nullable: false),
                    PlayerAge = table.Column<int>(nullable: false),
                    PlayerAddress = table.Column<string>(nullable: false),
                    PlayerScore = table.Column<int>(nullable: false),
                    PlayerNoOfMatches = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
