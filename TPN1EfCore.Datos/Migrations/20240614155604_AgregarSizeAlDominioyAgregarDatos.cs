using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TPN1EfCore.Datos.Migrations
{
    /// <inheritdoc />
    public partial class AgregarSizeAlDominioyAgregarDatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    SizeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SizeNumber = table.Column<decimal>(type: "decimal(3,1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.SizeId);
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "SizeId", "SizeNumber" },
                values: new object[,]
                {
                    { 1, 28m },
                    { 2, 28.5m },
                    { 3, 29m },
                    { 4, 29.5m },
                    { 5, 30m },
                    { 6, 30.5m },
                    { 7, 31m },
                    { 8, 31.5m },
                    { 9, 32m },
                    { 10, 32.5m },
                    { 11, 33m },
                    { 12, 33.5m },
                    { 13, 34m },
                    { 14, 34.5m },
                    { 15, 35m },
                    { 16, 35.5m },
                    { 17, 36m },
                    { 18, 36.5m },
                    { 19, 37m },
                    { 20, 37.5m },
                    { 21, 38m },
                    { 22, 38.5m },
                    { 23, 39m },
                    { 24, 39.5m },
                    { 25, 40m },
                    { 26, 40.5m },
                    { 27, 41m },
                    { 28, 41.5m },
                    { 29, 42m },
                    { 30, 42.5m },
                    { 31, 43m },
                    { 32, 43.5m },
                    { 33, 44m },
                    { 34, 44.5m },
                    { 35, 45m },
                    { 36, 45.5m },
                    { 37, 46m },
                    { 38, 46.5m },
                    { 39, 47m },
                    { 40, 47.5m },
                    { 41, 48m },
                    { 42, 48.5m },
                    { 43, 49m },
                    { 44, 49.5m },
                    { 45, 50m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sizes");
        }
    }
}
