using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESPDumpsterWebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class OrganisationsTAGColor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LevelStringColor",
                table: "ESPPostViewModel",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OrgsTag",
                table: "ESPPostViewModel",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrganisationViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    OrgsTag = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganisationViewModel", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrganisationViewModel");

            migrationBuilder.DropColumn(
                name: "LevelStringColor",
                table: "ESPPostViewModel");

            migrationBuilder.DropColumn(
                name: "OrgsTag",
                table: "ESPPostViewModel");
        }
    }
}
