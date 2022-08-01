using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class ModifiedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductFeatures_Products_ProductId",
                table: "ProductFeatures");

            migrationBuilder.DropTable(
                name: "FloorFeatures");

            migrationBuilder.DropIndex(
                name: "IX_ProductFeatures_ProductId",
                table: "ProductFeatures");

            migrationBuilder.DropIndex(
                name: "IX_FloorPlansImages_FloorPlanId",
                table: "FloorPlansImages");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProductFeatures");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductFeatures");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "ProductFeatures");

            migrationBuilder.AddColumn<int>(
                name: "ProductFeatureId",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Bathroom",
                table: "ProductFeatures",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Bedroom",
                table: "ProductFeatures",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "DiningArea",
                table: "ProductFeatures",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Garage",
                table: "ProductFeatures",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Garden",
                table: "ProductFeatures",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "GymArea",
                table: "ProductFeatures",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "LivingRoom",
                table: "ProductFeatures",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Parking",
                table: "ProductFeatures",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalArea",
                table: "FloorPlans",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductFeatureId",
                table: "Products",
                column: "ProductFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_FloorPlansImages_FloorPlanId",
                table: "FloorPlansImages",
                column: "FloorPlanId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductFeatures_ProductFeatureId",
                table: "Products",
                column: "ProductFeatureId",
                principalTable: "ProductFeatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductFeatures_ProductFeatureId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductFeatureId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_FloorPlansImages_FloorPlanId",
                table: "FloorPlansImages");

            migrationBuilder.DropColumn(
                name: "ProductFeatureId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Bathroom",
                table: "ProductFeatures");

            migrationBuilder.DropColumn(
                name: "Bedroom",
                table: "ProductFeatures");

            migrationBuilder.DropColumn(
                name: "DiningArea",
                table: "ProductFeatures");

            migrationBuilder.DropColumn(
                name: "Garage",
                table: "ProductFeatures");

            migrationBuilder.DropColumn(
                name: "Garden",
                table: "ProductFeatures");

            migrationBuilder.DropColumn(
                name: "GymArea",
                table: "ProductFeatures");

            migrationBuilder.DropColumn(
                name: "LivingRoom",
                table: "ProductFeatures");

            migrationBuilder.DropColumn(
                name: "Parking",
                table: "ProductFeatures");

            migrationBuilder.DropColumn(
                name: "TotalArea",
                table: "FloorPlans");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProductFeatures",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ProductFeatures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Size",
                table: "ProductFeatures",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "FloorFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FloorPlanId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FloorFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FloorFeatures_FloorPlans_FloorPlanId",
                        column: x => x.FloorPlanId,
                        principalTable: "FloorPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductFeatures_ProductId",
                table: "ProductFeatures",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_FloorPlansImages_FloorPlanId",
                table: "FloorPlansImages",
                column: "FloorPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_FloorFeatures_FloorPlanId",
                table: "FloorFeatures",
                column: "FloorPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFeatures_Products_ProductId",
                table: "ProductFeatures",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
