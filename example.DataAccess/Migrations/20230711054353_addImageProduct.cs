using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace example.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addImageProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { 1, "\\images\\products\\product-9\\6a3b031e-913f-41c3-ae4d-56f26ed1b012.webp", 9 },
                    { 2, "\\images\\products\\product-25\\af2a2496-0285-4d87-bc71-7d57d1f3cc2c.webp", 25 },
                    { 3, "\\images\\products\\product-25\\fdfe36de-6b0c-441e-8fb6-80616053206c.webp", 25 },
                    { 4, "\\images\\products\\product-25\\5509b98c-2ade-4312-9e4f-be503540d05f.webp", 25 },
                    { 5, "\\images\\products\\product-20\\6ef0f90a-3d2a-46a7-86b4-7a71111e3b55.webp", 20 },
                    { 6, "\\images\\products\\product-20\\7c4e8d7e-617d-492f-b391-bf94bdf15c91.webp", 20 },
                    { 7, "\\images\\products\\product-20\\6387af00-bb50-430d-a9ff-c45d915a095e.webp", 20 },
                    { 8, "\\images\\products\\product-6\\df6c760e-56b9-4f25-9273-205932e0b8c8.webp", 6 },
                    { 9, "\\images\\products\\product-6\\ae1bf008-03b3-4dc3-951c-757b1bd23de6.webp", 6 },
                    { 10, "\\images\\products\\product-6\\5c8b2ad6-4fc4-4192-af58-602629825dad.webp", 6 },
                    { 11, "\\images\\products\\product-1\\7c414b43-c48e-4796-8f36-e2adb9d88b08.webp", 1 },
                    { 12, "\\images\\products\\product-1\\c4cd093a-44b5-4ef9-9979-c4323296724b.webp", 1 },
                    { 13, "\\images\\products\\product-1\\2b4fd892-903b-439a-8af5-d488714ed6cc.webp", 1 },
                    { 14, "\\images\\products\\product-1\\d5546660-a4c9-4ede-9b32-ff886b01f05f.webp", 1 },
                    { 15, "\\images\\products\\product-15\\e97e660a-a113-455f-af8a-53caf7778568.webp", 15 },
                    { 16, "\\images\\products\\product-15\\4cff905f-55aa-4e1b-ae5c-dc6af214eb6e.webp", 15 },
                    { 17, "\\images\\products\\product-15\\e04b3453-8254-4ea9-ac14-6f471c1c2de9.webp", 15 },
                    { 18, "\\images\\products\\product-15\\4cb5b0e3-1653-49b7-a093-82f3fecb4458.webp", 15 },
                    { 19, "\\images\\products\\product-17\\076e1ba2-0465-42f4-82e9-84a9ddcda0dc.webp", 17 },
                    { 20, "\\images\\products\\product-17\\a49c7b0f-7119-4a52-81e9-e2ea49fa937e.webp", 17 },
                    { 21, "\\images\\products\\product-17\\e6a25651-8c54-4832-83f0-f40170b399b7.webp", 17 },
                    { 22, "\\images\\products\\product-17\\958b189a-77ed-4aad-8403-bd67d27fbf35.webp", 17 },
                    { 23, "\\images\\products\\product-17\\a5360b37-4bf0-46d0-acf2-7d8f12e46cbe.webp", 17 },
                    { 24, "\\images\\products\\product-16\\3819694a-0942-455f-af44-697038045a86.webp", 16 },
                    { 25, "\\images\\products\\product-16\\c3fb3f44-e5da-499f-98d6-ee4de2ba7fef.webp", 16 },
                    { 26, "\\images\\products\\product-16\\f6fbf3cc-c09e-4006-b0dc-e6990eaec2e6.webp", 16 },
                    { 27, "\\images\\products\\product-16\\b9030674-5103-4f34-9cf1-f4a170ab168f.webp", 16 },
                    { 28, "\\images\\products\\product-16\\dd71477e-66ca-4e1b-94c5-be5e625d5db7.webp", 16 },
                    { 29, "\\images\\products\\product-2\\2fe7c4c6-424e-4d63-9d5b-20bb4cddd616.webp", 2 },
                    { 30, "\\images\\products\\product-2\\449292d6-b966-4547-9f92-6715d391b69e.webp", 2 },
                    { 31, "\\images\\products\\product-28\\111ec959-2922-45f4-b2bc-48a435c2b0c2.webp", 28 },
                    { 32, "\\images\\products\\product-28\\56bd2a33-e165-4e40-a9f7-6d126e28cd78.webp", 28 },
                    { 33, "\\images\\products\\product-28\\5cf78129-5fdc-4519-a1f1-75dd11030687.webp", 28 },
                    { 34, "\\images\\products\\product-21\\23852e78-f06f-4c97-95db-aca1be4e9958.webp", 21 },
                    { 35, "\\images\\products\\product-21\\1d3c8769-787e-432b-9ee1-6453580b944f.webp", 21 },
                    { 36, "\\images\\products\\product-22\\2ac439cf-3bf5-43f4-af52-9d59bb94a720.webp", 22 },
                    { 37, "\\images\\products\\product-22\\2c678008-9681-4516-bef7-1b73201e4328.webp", 22 },
                    { 38, "\\images\\products\\product-22\\f84b02bb-68d5-4dbd-bdde-6e708223c9fa.webp", 22 },
                    { 39, "\\images\\products\\product-3\\92319f44-cbbd-42ad-9779-625efe67fc41.webp", 3 },
                    { 40, "\\images\\products\\product-3\\578f225f-b099-4bba-bc0b-62bd4ffb5340.webp", 3 },
                    { 41, "\\images\\products\\product-3\\7b98a53f-4e60-40ce-884e-93d7bffaf706.webp", 3 },
                    { 42, "\\images\\products\\product-11\\cfc3c44d-7bab-4b15-b0c4-7def2ff65c42.webp", 11 },
                    { 43, "\\images\\products\\product-11\\aef7ba7d-caae-45f6-a6ba-9f61288576ec.webp", 11 },
                    { 44, "\\images\\products\\product-11\\b4ca8db9-f051-4153-b9c3-ef489a286faa.webp", 11 },
                    { 45, "\\images\\products\\product-27\\295f6f26-a2d6-493e-b8e6-e503d63053f1.webp", 27 },
                    { 46, "\\images\\products\\product-27\\e253cd28-13ea-4da9-b9f9-89ae440ff857.webp", 27 },
                    { 47, "\\images\\products\\product-27\\fd1acd1c-dcb5-4814-b719-e344bf4b96e8.webp", 27 },
                    { 48, "\\images\\products\\product-27\\13e33754-18fc-4cda-ba2c-ffbb1314dbb0.webp", 27 },
                    { 49, "\\images\\products\\product-24\\95437905-c6ca-4a6a-b2b3-3591a580d7c8.webp", 24 },
                    { 50, "\\images\\products\\product-24\\5b6b9372-d84a-436d-a56b-f53b32c4d4ba.webp", 24 },
                    { 51, "\\images\\products\\product-24\\3c002ef5-1f8f-420c-8eed-35a43c022cc4.webp", 24 },
                    { 52, "\\images\\products\\product-5\\f4288e1c-4b08-4232-ae80-313b4c84ed69.webp", 5 },
                    { 53, "\\images\\products\\product-5\\fd18765c-26fd-45ff-8a5c-0d2865a3678e.webp", 5 },
                    { 54, "\\images\\products\\product-5\\603bcd22-85f6-4e86-b3a0-518c57147bd2.webp", 5 },
                    { 55, "\\images\\products\\product-13\\09909a52-f1c0-4f47-950b-91be8c252a1c.webp", 13 },
                    { 56, "\\images\\products\\product-13\\d9006759-d310-4c33-a27b-5ad7ccfd8d0b.webp", 13 },
                    { 57, "\\images\\products\\product-14\\0d2f2cd0-4665-4965-9991-5cfb90955dd9.webp", 14 },
                    { 58, "\\images\\products\\product-14\\cecfb590-16e6-40f6-9a56-7afc85811229.webp", 14 },
                    { 59, "\\images\\products\\product-14\\28decc9f-e45f-4970-9b5b-c4b0f6aafa23.webp", 14 },
                    { 60, "\\images\\products\\product-4\\9c2b9884-c9e1-43df-9374-e86a43f40903.webp", 4 },
                    { 61, "\\images\\products\\product-4\\83805c0c-29b1-4114-97d4-2500906b5a27.webp", 4 },
                    { 62, "\\images\\products\\product-19\\7a245411-bc7b-45ee-bb57-12a8c6b11337.webp", 19 },
                    { 63, "\\images\\products\\product-10\\5fb1efbd-fbea-4d6b-b821-179d6e176fa0.webp", 10 },
                    { 64, "\\images\\products\\product-26\\64c244c5-bf35-4b4c-a59d-d4cd9c4ef77d.webp", 26 },
                    { 65, "\\images\\products\\product-23\\002482c5-fb95-4db5-8a7b-2fc97fb5c7c7.webp", 23 },
                    { 66, "\\images\\products\\product-23\\b23387fa-da6a-445b-a4e0-a603c9e72f83.webp", 23 },
                    { 67, "\\images\\products\\product-18\\0c96e46b-0dd5-44b6-b6d0-83daee4627fe.webp", 18 },
                    { 68, "\\images\\products\\product-18\\2bef06cc-061a-4e5f-8ba9-0c85ba1162eb.webp", 18 },
                    { 69, "\\images\\products\\product-18\\89093186-cd35-4362-9040-ab62bb622c58.webp", 18 },
                    { 70, "\\images\\products\\product-12\\c5291d69-430b-4f59-90c2-3f91fa0f28d4.webp", 12 },
                    { 71, "\\images\\products\\product-12\\703c6bb3-3fe5-4d21-8d5e-dd434563c474.webp", 12 },
                    { 72, "\\images\\products\\product-12\\169a2119-7e05-4d35-9371-eecdf9cbe584.webp", 12 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 72);
        }
    }
}
