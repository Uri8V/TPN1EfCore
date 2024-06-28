﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPN1EfCore.Datos.Migrations
{
    /// <inheritdoc />
    public partial class AgregandoElCampoActiveEnLasTablasMenosEnSizeYGenre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Sports",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Shoes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Colors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Brands",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "BrandId",
                keyValue: 1,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "BrandId",
                keyValue: 2,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "BrandId",
                keyValue: 3,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "ColourId",
                keyValue: 1,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "ColourId",
                keyValue: 2,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "ColourId",
                keyValue: 3,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: 1,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: 2,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: 3,
                column: "Active",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Sports");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Shoes");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Brands");
        }
    }
}
