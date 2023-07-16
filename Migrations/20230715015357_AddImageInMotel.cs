using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NganHangNhaTro.Migrations
{
    /// <inheritdoc />
    public partial class AddImageInMotel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "image",
                table: "motels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image",
                table: "motels");
        }
    }
}
