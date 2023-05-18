using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Main.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InvoicesFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Invoice_OperationTime",
                table: "Orders",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Invoice_Sum",
                table: "Orders",
                type: "numeric",
                nullable: true);

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
                value: "AQAAAAIAAYagAAAAECVshEbAKWfXpC3fHjHu6L0t2ckpqpjxH9UaIZr6LfDNABQZSPgCtH8HLn/cI1Nt+g==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1799c9f1-e377-45fe-8858-d909d0c2f7a7"),
                columns: new[] { "NormalizedEmail", "PasswordHash" },
                values: new object[] { "ADEL@DEKOFF.EE", "AQAAAAIAAYagAAAAEPwPFM0Q7QWHXVnxNXjZIjO305hQIm6DSkdtNgHitRXGh339fKR9uTA6WBqd9LbnFA==" });

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
                columns: new[] { "NormalizedEmail", "PasswordHash" },
                values: new object[] { "COURIER.DMITRY@DEKOFF.EE", "AQAAAAIAAYagAAAAEOzeU6LAxU2Yg65ClqQsN2KbhOQUrIKPW+j3qG9zneV2myP0FxCBDqnlukaHth42DA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b1f872ed-1a8b-4d71-8694-e9273287f8ec"),
                columns: new[] { "NormalizedEmail", "PasswordHash" },
                values: new object[] { "COURIER.RUSLAN@DEKOFF.EE", "AQAAAAIAAYagAAAAEJdgbd4EEBaEFeYzKmqiI2W9Peh5IaGMie42rtLYQjpH3oR35pm6BqV1qgne3Ws8Bw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e58a4734-d89c-48eb-a65d-e0e192bdda7c"),
                columns: new[] { "NormalizedEmail", "PasswordHash" },
                values: new object[] { "ADMIN@DEKOFF.EE", "AQAAAAIAAYagAAAAEAS1rdzURPgjIjrCaVEsHaIzTmJ3jknFS6kRYTmj/fLTuaiiyXo6G+ZEIh3n36UWJg==" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("964d25df-c2ac-4511-b43f-6588394afd52"),
                columns: new[] { "Invoice_OperationTime", "Invoice_Sum" },
                values: new object[] { new DateTime(2023, 5, 12, 13, 0, 0, 0, DateTimeKind.Unspecified), 1000000m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("f1bc39f8-0434-4c23-ab66-0db72ac81b14"),
                columns: new[] { "Invoice_OperationTime", "Invoice_Sum" },
                values: new object[] { new DateTime(2023, 5, 12, 13, 0, 0, 0, DateTimeKind.Unspecified), 8600m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Invoice_OperationTime",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Invoice_Sum",
                table: "Orders");

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
