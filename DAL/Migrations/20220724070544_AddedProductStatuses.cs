using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddedProductStatuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductStatus_ProductStatusId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProductCatagories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductStatus",
                table: "ProductStatus");

            migrationBuilder.RenameTable(
                name: "ProductStatus",
                newName: "ProductStatuses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductStatuses",
                table: "ProductStatuses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductStatuses_ProductStatusId",
                table: "Products",
                column: "ProductStatusId",
                principalTable: "ProductStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductStatuses_ProductStatusId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductStatuses",
                table: "ProductStatuses");

            migrationBuilder.RenameTable(
                name: "ProductStatuses",
                newName: "ProductStatus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductStatus",
                table: "ProductStatus",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ProductCatagories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SubCatagoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCatagories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCatagories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCatagories_SubCatagories_SubCatagoryId",
                        column: x => x.SubCatagoryId,
                        principalTable: "SubCatagories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCatagories_ProductId",
                table: "ProductCatagories",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCatagories_SubCatagoryId",
                table: "ProductCatagories",
                column: "SubCatagoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductStatus_ProductStatusId",
                table: "Products",
                column: "ProductStatusId",
                principalTable: "ProductStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
