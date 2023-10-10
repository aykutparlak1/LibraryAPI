using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserType",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5,
                oldDefaultValue: "0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserType",
                table: "Users",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "0",
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);
        }
    }
}
