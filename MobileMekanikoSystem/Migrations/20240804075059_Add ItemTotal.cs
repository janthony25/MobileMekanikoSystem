using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobileMekanikoSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddItemTotal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ItemTotal",
                table: "tblInvoiceItem",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemTotal",
                table: "tblInvoiceItem");
        }
    }
}
