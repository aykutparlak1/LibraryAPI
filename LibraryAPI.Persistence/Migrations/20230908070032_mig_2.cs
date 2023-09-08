using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordSalt",
                table: "Users",
                type: "varbinary(500)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordHash",
                table: "Users",
                type: "varbinary(500)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordSalt",
                table: "Users",
                type: "varbinary",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(500)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordHash",
                table: "Users",
                type: "varbinary",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(500)");
        }
    }
}
