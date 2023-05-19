using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Main.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0c3a4ac7-6fa2-4aad-a576-48ef57b1c999"),
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEI1SKtrhlJ1UqNQ3LD9Cp+v374e9a2q+jsGqi/u4WztHCJljN8l+YziFii9xqgrb3Q==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1799c9f1-e377-45fe-8858-d909d0c2f7a7"),
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEHPrSyJRzm97UCNtKFN7W0eCT23mzbEJAcyjU3Y1UuMp8Qgngl8xQkt/wZvLXOe1Wg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("780c9e97-6564-4a35-8195-9544ba50d904"),
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEMQyJ7kVmYarRgp1u0HlGJEXsWd2tlW/clD8VOoKEyebulIhuovQZqwBNMfL1vVb/w==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a969812b-4fc3-4ffc-b739-2a467117f64e"),
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEGwIXjMob/RIvqWotbsbSyKMCX6/mU1UmLPAZcKlGPq0zbo3+l+RtJb/yU6yVfeJ0w==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b1f872ed-1a8b-4d71-8694-e9273287f8ec"),
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEKjzh5IBjIW0CJNcRoEN09pFdKjHxh4TB23Bz26y/Ppj9sXlIsZqdUwjSZnLnoEviw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e58a4734-d89c-48eb-a65d-e0e192bdda7c"),
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEJOdfwFMKxeSdiix/9wi/elzLUlDzs5MBDicXO1bSauJ9UlGg/jWCMhtvhyfc0foxQ==");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("202a5477-ce2d-4824-966a-afdc6422915a"),
                column: "ImageUrl",
                value: "https://i.imgur.com/fE10Rf0.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2c8f1066-892a-4737-9901-286a2127c846"),
                column: "ImageUrl",
                value: "https://i.imgur.com/fE10Rf0.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("403d26f4-5f81-4682-b073-06a507bf9944"),
                column: "ImageUrl",
                value: "https://i.imgur.com/fE10Rf0.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5ef11ced-6193-4116-9de2-0811f2340602"),
                column: "ImageUrl",
                value: "https://i.imgur.com/fE10Rf0.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6eb85d1a-1839-4f07-92e3-8c7d9a281f09"),
                column: "ImageUrl",
                value: "https://i.imgur.com/fE10Rf0.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("71755a93-7c3f-4137-bb5d-11c8b4539556"),
                column: "ImageUrl",
                value: "https://i.imgur.com/fE10Rf0.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7348c294-82c0-4bfb-9072-7afc8bec3d82"),
                column: "ImageUrl",
                value: "https://i.imgur.com/fE10Rf0.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8ba706ab-387f-41d4-9fa0-9f419bc0793e"),
                column: "ImageUrl",
                value: "https://i.imgur.com/fE10Rf0.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ca4f0c3e-67c0-429b-824f-d13a1ad1b4fe"),
                column: "ImageUrl",
                value: "https://i.imgur.com/fE10Rf0.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cfbd118c-51e4-4a29-9ddd-58777d85e0a3"),
                column: "ImageUrl",
                value: "https://i.imgur.com/fE10Rf0.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ebe0fa86-e594-468d-b375-3a281a705f06"),
                column: "ImageUrl",
                value: "https://i.imgur.com/fE10Rf0.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0c3a4ac7-6fa2-4aad-a576-48ef57b1c999"),
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAECVshEbAKWfXpC3fHjHu6L0t2ckpqpjxH9UaIZr6LfDNABQZSPgCtH8HLn/cI1Nt+g==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1799c9f1-e377-45fe-8858-d909d0c2f7a7"),
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEPwPFM0Q7QWHXVnxNXjZIjO305hQIm6DSkdtNgHitRXGh339fKR9uTA6WBqd9LbnFA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("780c9e97-6564-4a35-8195-9544ba50d904"),
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEENryHtMiYrPguBF/0V4xZqjZaYyM6gKD7j6Ch0Ih0SyWi1IFNXGyV0dxDlgHwo7Pg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a969812b-4fc3-4ffc-b739-2a467117f64e"),
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEOzeU6LAxU2Yg65ClqQsN2KbhOQUrIKPW+j3qG9zneV2myP0FxCBDqnlukaHth42DA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b1f872ed-1a8b-4d71-8694-e9273287f8ec"),
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEJdgbd4EEBaEFeYzKmqiI2W9Peh5IaGMie42rtLYQjpH3oR35pm6BqV1qgne3Ws8Bw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e58a4734-d89c-48eb-a65d-e0e192bdda7c"),
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEAS1rdzURPgjIjrCaVEsHaIzTmJ3jknFS6kRYTmj/fLTuaiiyXo6G+ZEIh3n36UWJg==");
        }
    }
}
