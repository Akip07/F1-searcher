using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlatformyProgramistyczneAPI.Migrations
{
    /// <inheritdoc />
    public partial class addedsessiondb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    session_key = table.Column<int>(type: "INTEGER", nullable: false),
                    session_name = table.Column<string>(type: "TEXT", nullable: false),
                    date_start = table.Column<DateTime>(type: "TEXT", nullable: false),
                    date_end = table.Column<DateTime>(type: "TEXT", nullable: false),
                    gmt_offset = table.Column<string>(type: "TEXT", nullable: false),
                    session_type = table.Column<string>(type: "TEXT", nullable: false),
                    meeting_key = table.Column<int>(type: "INTEGER", nullable: false),
                    location = table.Column<string>(type: "TEXT", nullable: false),
                    country_key = table.Column<int>(type: "INTEGER", nullable: false),
                    country_code = table.Column<string>(type: "TEXT", nullable: false),
                    country_name = table.Column<string>(type: "TEXT", nullable: false),
                    circuit_key = table.Column<int>(type: "INTEGER", nullable: false),
                    circuit_short_name = table.Column<string>(type: "TEXT", nullable: false),
                    year = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sessions");
        }
    }
}
