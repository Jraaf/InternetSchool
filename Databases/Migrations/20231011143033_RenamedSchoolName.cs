using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Databases.Migrations
{
    /// <inheritdoc />
    public partial class RenamedSchoolName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SchoolName",
                table: "Schools",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Schools",
                newName: "SchoolName");
        }
    }
}
