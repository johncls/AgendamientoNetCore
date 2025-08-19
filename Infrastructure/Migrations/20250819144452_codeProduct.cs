using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class codeProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "code_product",
                table: "product",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            // Convertir la columna deposit de boolean a numeric usando SQL raw
            migrationBuilder.Sql("ALTER TABLE details_invoice ALTER COLUMN deposit TYPE numeric USING CASE WHEN deposit THEN 1 ELSE 0 END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "code_product",
                table: "product");

            // Revertir la conversión de numeric a boolean
            migrationBuilder.Sql("ALTER TABLE details_invoice ALTER COLUMN deposit TYPE boolean USING CASE WHEN deposit > 0 THEN true ELSE false END");
        }
    }
}
