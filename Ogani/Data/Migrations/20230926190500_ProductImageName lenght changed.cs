using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ogani.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProductImageNamelenghtchanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_products_tbl_categories_ProductCategoryCategoryID",
                table: "tbl_products");

            migrationBuilder.AlterColumn<string>(
                name: "ProductImageName",
                table: "tbl_products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductCategoryCategoryID",
                table: "tbl_products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_products_tbl_categories_ProductCategoryCategoryID",
                table: "tbl_products",
                column: "ProductCategoryCategoryID",
                principalTable: "tbl_categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_products_tbl_categories_ProductCategoryCategoryID",
                table: "tbl_products");

            migrationBuilder.AlterColumn<string>(
                name: "ProductImageName",
                table: "tbl_products",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductCategoryCategoryID",
                table: "tbl_products",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_products_tbl_categories_ProductCategoryCategoryID",
                table: "tbl_products",
                column: "ProductCategoryCategoryID",
                principalTable: "tbl_categories",
                principalColumn: "CategoryID");
        }
    }
}
