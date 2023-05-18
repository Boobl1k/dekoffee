using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

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

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "OrderProduct",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0c3a4ac7-6fa2-4aad-a576-48ef57b1c999"),
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEJOgntNisa6noQ5FEsejcr3zBW22KMZ0mOZ4x/TNwsVnwAn4sk7T7lLYd3isj9c/YA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1799c9f1-e377-45fe-8858-d909d0c2f7a7"),
                columns: new[] { "NormalizedEmail", "PasswordHash" },
                values: new object[] { "ADEL@DEKOFF.EE", "AQAAAAIAAYagAAAAEC7zoQIndEW89NVT3Ojbdhjhgjgp9FiliD3MXesbeOTdGqxIuwxmWc9JFHc5r1WU5w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("780c9e97-6564-4a35-8195-9544ba50d904"),
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEMUnq4egla3ZebXoZuhCspPa9LcCpb1bGbhV2U08JfE8j55/31Isyu0xvBxQnZ+rKw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a969812b-4fc3-4ffc-b739-2a467117f64e"),
                columns: new[] { "NormalizedEmail", "PasswordHash" },
                values: new object[] { "COURIER.DMITRY@DEKOFF.EE", "AQAAAAIAAYagAAAAEBMXjHo207pzXoNuZAH/i8yTRDJnqoorsWZZwzEqBIraJrykB036QrADeCne5rnCiA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b1f872ed-1a8b-4d71-8694-e9273287f8ec"),
                columns: new[] { "NormalizedEmail", "PasswordHash" },
                values: new object[] { "COURIER.RUSLAN@DEKOFF.EE", "AQAAAAIAAYagAAAAEHSb8NHQSShqTu6Ts5fG4kVIeC7+U8TlMpuE6KwUoT6E7kNfDX15ai6ZdOOFesK0TQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e58a4734-d89c-48eb-a65d-e0e192bdda7c"),
                columns: new[] { "NormalizedEmail", "PasswordHash" },
                values: new object[] { "ADMIN@DEKOFF.EE", "AQAAAAIAAYagAAAAEMj0B6u7Yc0rbFbf1OuCYC+gdoy8nZveGcbW86aopehOF9V84KC1HnM/WriMKppbDg==" });

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

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "OrderProduct",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0c3a4ac7-6fa2-4aad-a576-48ef57b1c999"),
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAENmUGtwOY7Ut9EUiAUxQyDMKbUrImirmDpv18CwWGO++XSp19PwN65tTRi0DfLiw3Q==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1799c9f1-e377-45fe-8858-d909d0c2f7a7"),
                columns: new[] { "NormalizedEmail", "PasswordHash" },
                values: new object[] { "ADEL@DEFOFF.EE", "AQAAAAIAAYagAAAAEN9vIszn3vMDBijPE09ncS4sIfSz3/QJVQ64CtX//yV2kEO4O9zaHcw/GcJqGxmKHA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("780c9e97-6564-4a35-8195-9544ba50d904"),
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEEEOVIjCLuRoF3iESCH5PTC3eADekDi26kEcCHkzH0z61UvFg6oCDNCuyO7ppzJlFg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a969812b-4fc3-4ffc-b739-2a467117f64e"),
                columns: new[] { "NormalizedEmail", "PasswordHash" },
                values: new object[] { "COURIER.DMITRY@DEFOFF.EE", "AQAAAAIAAYagAAAAEFP61C1SSl6cxkWDLo/6AuUA3YF/J0ENRCbdtoiRt4arfm1gGY3mCzvcd9PQQF896g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b1f872ed-1a8b-4d71-8694-e9273287f8ec"),
                columns: new[] { "NormalizedEmail", "PasswordHash" },
                values: new object[] { "COURIER.RUSLAN@DEFOFF.EE", "AQAAAAIAAYagAAAAEGJtq/sjFcy7hNQZrxk4afWyTMSLgtPM4F4S0fVgfJvRFs52aTHLWmM+HPamnp8B1A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e58a4734-d89c-48eb-a65d-e0e192bdda7c"),
                columns: new[] { "NormalizedEmail", "PasswordHash" },
                values: new object[] { "ADMIN@DEFOFF.EE", "AQAAAAIAAYagAAAAEL2uqcJoPLAhCgVbiS7eSJP7k3KP+mKYyMYphy7qEhISToFUOp8TwA8E6dG1PjtqqQ==" });
        }
    }
}
