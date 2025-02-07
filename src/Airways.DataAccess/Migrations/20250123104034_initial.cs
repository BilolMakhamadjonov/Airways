using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Airways.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrgPasword",
                table: "AirwaysUser",
                newName: "Pasword2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Pasword2",
                table: "AirwaysUser",
                newName: "OrgPasword");
        }
    }
}
