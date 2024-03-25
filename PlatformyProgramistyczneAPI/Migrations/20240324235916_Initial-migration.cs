using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlatformyProgramistyczneAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    driver_number = table.Column<int>(type: "INTEGER", nullable: false),
                    broadcast_name = table.Column<string>(type: "TEXT", nullable: false),
                    full_name = table.Column<string>(type: "TEXT", nullable: false),
                    name_acronym = table.Column<string>(type: "TEXT", nullable: false),
                    team_name = table.Column<string>(type: "TEXT", nullable: false),
                    team_colour = table.Column<string>(type: "TEXT", nullable: false),
                    first_name = table.Column<string>(type: "TEXT", nullable: false),
                    last_name = table.Column<string>(type: "TEXT", nullable: false),
                    headshot_url = table.Column<string>(type: "TEXT", nullable: false),
                    country_code = table.Column<string>(type: "TEXT", nullable: false),
                    session_key = table.Column<int>(type: "INTEGER", nullable: false),
                    meeting_key = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "id", "broadcast_name", "country_code", "driver_number", "first_name", "full_name", "headshot_url", "last_name", "meeting_key", "name_acronym", "session_key", "team_colour", "team_name" },
                values: new object[] { 1, "F GRZYWACZ", "PL", 7, "Filip", "Filip Grzywacz", "https://ecsmedia.pl/c/niepowstrzymany-w-iext132429663.jpg", "Grzywacz", 1219, "GRZ", 9158, "F91536", "Ferrari" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drivers");
        }
    }
}
