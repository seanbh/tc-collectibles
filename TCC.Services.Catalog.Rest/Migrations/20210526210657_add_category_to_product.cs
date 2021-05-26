using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCC.Services.Catalog.Rest.Migrations
{
    public partial class add_category_to_product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Year",
                value: new DateTime(2022, 3, 26, 16, 6, 57, 475, DateTimeKind.Local).AddTicks(781));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Year",
                value: new DateTime(2022, 2, 26, 16, 6, 57, 475, DateTimeKind.Local).AddTicks(714));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Year",
                value: new DateTime(2021, 9, 26, 16, 6, 57, 475, DateTimeKind.Local).AddTicks(768));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Year",
                value: new DateTime(2022, 1, 26, 16, 6, 57, 475, DateTimeKind.Local).AddTicks(795));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Year",
                value: new DateTime(2021, 9, 26, 16, 6, 57, 475, DateTimeKind.Local).AddTicks(753));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Year",
                value: new DateTime(2021, 11, 26, 16, 6, 57, 473, DateTimeKind.Local).AddTicks(3768));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Year",
                value: new DateTime(2022, 3, 26, 15, 57, 18, 608, DateTimeKind.Local).AddTicks(7052));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Year",
                value: new DateTime(2022, 2, 26, 15, 57, 18, 608, DateTimeKind.Local).AddTicks(6987));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Year",
                value: new DateTime(2021, 9, 26, 15, 57, 18, 608, DateTimeKind.Local).AddTicks(7040));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Year",
                value: new DateTime(2022, 1, 26, 15, 57, 18, 608, DateTimeKind.Local).AddTicks(7067));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Year",
                value: new DateTime(2021, 9, 26, 15, 57, 18, 608, DateTimeKind.Local).AddTicks(7024));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Year",
                value: new DateTime(2021, 11, 26, 15, 57, 18, 607, DateTimeKind.Local).AddTicks(92));
        }
    }
}
