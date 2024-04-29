using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasketballStore.Migrations
{
    /// <inheritdoc />
    public partial class BasketballStoreDataBasketballStoreContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeamName",
                columns: table => new
                {
                    TeamNameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamName", x => x.TeamNameId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamName");
        }
    }
}
