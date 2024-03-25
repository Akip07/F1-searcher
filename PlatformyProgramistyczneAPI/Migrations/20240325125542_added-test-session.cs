using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlatformyProgramistyczneAPI.Migrations
{
    /// <inheritdoc />
    public partial class addedtestsession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "id", "circuit_key", "circuit_short_name", "country_code", "country_key", "country_name", "date_end", "date_start", "gmt_offset", "location", "meeting_key", "session_key", "session_name", "session_type", "year" },
                values: new object[] { 1, 1, "test", "test", 1, "test", new DateTime(2024, 3, 25, 13, 55, 42, 647, DateTimeKind.Local).AddTicks(392), new DateTime(2024, 3, 25, 13, 55, 42, 647, DateTimeKind.Local).AddTicks(337), "test", "test", 1, 1, "test", "test", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "id",
                keyValue: 1);
        }
    }
}
