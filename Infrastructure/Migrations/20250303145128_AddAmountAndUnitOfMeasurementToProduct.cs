using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAmountAndUnitOfMeasurementToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_details_invoice_product_product_id",
                table: "details_invoice");

            migrationBuilder.AddColumn<int>(
                name: "amount",
                table: "product",
                type: "integer",
                maxLength: 10,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "unit_of_measurement",
                table: "product",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "fk_details_invoice_products_product_id",
                table: "details_invoice",
                column: "id_product",
                principalTable: "product",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_details_invoice_products_product_id",
                table: "details_invoice");

            migrationBuilder.DropColumn(
                name: "amount",
                table: "product");

            migrationBuilder.DropColumn(
                name: "unit_of_measurement",
                table: "product");

            migrationBuilder.AddForeignKey(
                name: "fk_details_invoice_product_product_id",
                table: "details_invoice",
                column: "id_product",
                principalTable: "product",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
