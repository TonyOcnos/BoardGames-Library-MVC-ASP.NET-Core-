using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BoardGamesLibrary.Migrations
{
    public partial class CreateDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BoardGame",
                columns: table => new
                {
                    IdGame = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Publisher = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true),
                    Weight = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    NPlayers = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGame", x => x.IdGame);
                });

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    IdMatch = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdGameRef = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    Duration = table.Column<string>(nullable: true),
                    Winner = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.IdMatch);
                });

            migrationBuilder.CreateTable(
                name: "MatchRELPlayer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdMatchRef = table.Column<int>(nullable: false),
                    NameRef = table.Column<string>(nullable: true),
                    Winner = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchRELPlayer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    WonMatches = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Name);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoardGame");

            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "MatchRELPlayer");

            migrationBuilder.DropTable(
                name: "Player");
        }
    }
}
