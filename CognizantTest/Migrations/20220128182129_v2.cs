using Microsoft.EntityFrameworkCore.Migrations;

namespace CognizantTest.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OuterId",
                table: "Warehouses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "Vehicles",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "OuterId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OuterId",
                table: "Models",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OuterId",
                table: "Brands",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_OuterId",
                table: "Warehouses",
                column: "OuterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_OuterId",
                table: "Vehicles",
                column: "OuterId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Warehouses_OuterId",
                table: "Warehouses");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_OuterId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "OuterId",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "OuterId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "OuterId",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "OuterId",
                table: "Brands");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Vehicles",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
