using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NganHangNhaTro.Migrations
{
    /// <inheritdoc />
    public partial class AddDetailInMotel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "detail",
                table: "motels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "detail",
                table: "motels");
        }
    }
}
