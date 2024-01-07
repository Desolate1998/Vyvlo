using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class metatag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "StoreId",
                table: "ProductMetaTags",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ProductMetaTags_StoreId",
                table: "ProductMetaTags",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "fk_Store_ProductMetaTag",
                table: "ProductMetaTags",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_Store_ProductMetaTag",
                table: "ProductMetaTags");

            migrationBuilder.DropIndex(
                name: "IX_ProductMetaTags_StoreId",
                table: "ProductMetaTags");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "ProductMetaTags");
        }
    }
}
