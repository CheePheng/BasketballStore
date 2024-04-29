using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BasketballStore.Migrations
{
    /// <inheritdoc />
    public partial class LosAngelesLakers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TeamName",
                columns: new[] { "TeamNameId", "Name" },
                values: new object[,]
                {
                    { 1, "Los Angeles Lakers" },
                    { 2, "LA Clippers" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TeamName",
                keyColumn: "TeamNameId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TeamName",
                keyColumn: "TeamNameId",
                keyValue: 2);
        }
    }
}
