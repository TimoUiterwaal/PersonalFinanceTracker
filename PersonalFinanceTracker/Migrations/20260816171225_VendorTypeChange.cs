using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalFinanceTracker.Migrations
{
    /// <inheritdoc />
    public partial class VendorTypeChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Vendor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Vendor",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
