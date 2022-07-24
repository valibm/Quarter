using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddedProductSubCatagoryRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "ProductDetails");

            migrationBuilder.AddColumn<int>(
                name: "ProductStatusId",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProductStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductSubCatagories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: true),
                    SubCatagoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSubCatagories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductSubCatagories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductSubCatagories_SubCatagories_SubCatagoryId",
                        column: x => x.SubCatagoryId,
                        principalTable: "SubCatagories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductStatusId",
                table: "Products",
                column: "ProductStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSubCatagories_ProductId",
                table: "ProductSubCatagories",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSubCatagories_SubCatagoryId",
                table: "ProductSubCatagories",
                column: "SubCatagoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductStatus_ProductStatusId",
                table: "Products",
                column: "ProductStatusId",
                principalTable: "ProductStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductStatus_ProductStatusId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProductStatus");

            migrationBuilder.DropTable(
                name: "ProductSubCatagories");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductStatusId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductStatusId",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "PropertyId",
                table: "ProductDetails",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
