using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingCart.Migrations
{
    public partial class seed_category_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "DisplayOrder", "Name" },
                values: new object[] { 1, 1, "Comedy" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "DisplayOrder", "Name" },
                values: new object[] { 2, 2, "Action" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "DisplayOrder", "Name" },
                values: new object[] { 3, 3, "Fiction" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3);
        }
    }
}
