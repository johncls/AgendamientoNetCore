using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddInventoryTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_details_invoice_invoice_invoice_id",
                table: "details_invoice");

            migrationBuilder.CreateTable(
                name: "inventory",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    id_product = table.Column<Guid>(type: "uuid", nullable: false),
                    quantity = table.Column<int>(type: "integer", maxLength: 10, nullable: false),
                    last_update = table.Column<DateTime>(type: "timestamp with time zone", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_inventory", x => x.id);
                    table.ForeignKey(
                        name: "fk_inventory_products_product_id",
                        column: x => x.id_product,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_inventory_id_product",
                table: "inventory",
                column: "id_product");

            migrationBuilder.AddForeignKey(
                name: "fk_details_invoice_invoices_invoice_id",
                table: "details_invoice",
                column: "id_invoice",
                principalTable: "invoice",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_details_invoice_invoices_invoice_id",
                table: "details_invoice");

            migrationBuilder.DropTable(
                name: "inventory");

            migrationBuilder.AddForeignKey(
                name: "fk_details_invoice_invoice_invoice_id",
                table: "details_invoice",
                column: "id_invoice",
                principalTable: "invoice",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
