using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace example.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Sellers",
                columns: new[] { "Id", "ApplicationUserId", "ContactInformation", "Description", "Logo", "Ratings", "ReturnPolicy", "Sales", "ShippingPolicy", "StoreName" },
                values: new object[,]
                {
                    { 1, "2945d2ed-60a9-469e-abe2-648bac284bbd", "Contact Store A", "This is Store A", "logoA.jpg", 4.5, "Return Policy for Store A", 100, "Shipping Policy for Store A", "Store A" },
                    { 2, "5c5bcfbd-1baf-4338-8536-e0d217bbf8df", "Contact Store B", "This is Store B", "logoB.jpg", 4.2000000000000002, "Return Policy for Store B", 200, "Shipping Policy for Store B", "Store B" },
                    { 3, "5fb323ee-dde6-43d8-bcca-1bfeb93a31a2", "Contact Store C", "This is Store C", "logoC.jpg", 4.7000000000000002, "Return Policy for Store C", 150, "Shipping Policy for Store C", "Store C" },
                    { 4, "fd29dc1d-d32e-47ae-94c4-adc13f16cc7b", "Contact Store D", "This is Store D", "logoD.jpg", 4.9000000000000004, "Return Policy for Store D", 300, "Shipping Policy for Store D", "Store D" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sellers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sellers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sellers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sellers",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
