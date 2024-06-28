using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPN1EfCore.Datos.Migrations
{
    /// <inheritdoc />
    public partial class ResolviendoErrordeNombreColourIdEnSHoe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shoes_Colors_ColorId",
                table: "Shoes");

            migrationBuilder.RenameColumn(
                name: "ColorId",
                table: "Shoes",
                newName: "ColourId");

            migrationBuilder.RenameIndex(
                name: "IX_Shoes_ColorId",
                table: "Shoes",
                newName: "IX_Shoes_ColourId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shoes_Colors_ColourId",
                table: "Shoes",
                column: "ColourId",
                principalTable: "Colors",
                principalColumn: "ColourId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shoes_Colors_ColourId",
                table: "Shoes");

            migrationBuilder.RenameColumn(
                name: "ColourId",
                table: "Shoes",
                newName: "ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_Shoes_ColourId",
                table: "Shoes",
                newName: "IX_Shoes_ColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shoes_Colors_ColorId",
                table: "Shoes",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "ColourId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
