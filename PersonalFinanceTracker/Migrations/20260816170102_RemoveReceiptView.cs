using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalFinanceTracker.Migrations
{
    /// <inheritdoc />
    public partial class RemoveReceiptView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Receipt");

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_VendorId",
                table: "Receipt",
                column: "VendorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipt_Vendor_VendorId",
                table: "Receipt",
                column: "VendorId",
                principalTable: "Vendor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipt_Vendor_VendorId",
                table: "Receipt");

            migrationBuilder.DropIndex(
                name: "IX_Receipt_VendorId",
                table: "Receipt");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Receipt",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
