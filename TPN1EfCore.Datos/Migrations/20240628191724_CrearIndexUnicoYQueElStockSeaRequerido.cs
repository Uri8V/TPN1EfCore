using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPN1EfCore.Datos.Migrations
{
    /// <inheritdoc />
    public partial class CrearIndexUnicoYQueElStockSeaRequerido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ShoeSizes_SizeId",
                table: "ShoeSizes");

            migrationBuilder.CreateIndex(
                name: "IX_ShoeSizes_ShoeSizeId",
                table: "ShoeSizes",
                column: "ShoeSizeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoeSizes_SizeId_ShoeId",
                table: "ShoeSizes",
                columns: new[] { "SizeId", "ShoeId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ShoeSizes_ShoeSizeId",
                table: "ShoeSizes");

            migrationBuilder.DropIndex(
                name: "IX_ShoeSizes_SizeId_ShoeId",
                table: "ShoeSizes");

            migrationBuilder.CreateIndex(
                name: "IX_ShoeSizes_SizeId",
                table: "ShoeSizes",
                column: "SizeId");
        }
    }
}
