using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cricket.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "matches",
                columns: table => new
                {
                    MatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeamA = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamB = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoOfOvers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_matches", x => x.MatchId);
                });

            migrationBuilder.CreateTable(
                name: "players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Wickets = table.Column<int>(type: "int", nullable: false),
                    Runs = table.Column<int>(type: "int", nullable: false),
                    NoOfMatches = table.Column<int>(type: "int", nullable: false),
                    JerseyNo = table.Column<int>(type: "int", nullable: false),
                    PlayerType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Team = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeamPlayerMap",
                columns: table => new
                {
                    TeamMapId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamPlayerMap", x => x.TeamMapId);
                });

            migrationBuilder.CreateTable(
                name: "teams",
                columns: table => new
                {
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teams", x => x.TeamId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "matches");

            migrationBuilder.DropTable(
                name: "players");

            migrationBuilder.DropTable(
                name: "TeamPlayerMap");

            migrationBuilder.DropTable(
                name: "teams");
        }
    }
}
