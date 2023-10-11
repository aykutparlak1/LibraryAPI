using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LeaveTime",
                table: "Employees",
                newName: "LeaveDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LeaveDate",
                table: "Employees",
                newName: "LeaveTime");
        }
    }
}
