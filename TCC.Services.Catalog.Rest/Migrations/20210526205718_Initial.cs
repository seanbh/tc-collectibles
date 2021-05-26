using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCC.Services.Catalog.Rest.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Year = table.Column<DateTime>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    CategoryId = table.Column<Guid>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), "Baseball Cards" },
                    { new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"), "Football Cards" },
                    { new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"), "Basketball Cards" },
                    { new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"), "Hockey Cards" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "ImageUrl", "Name", "Price", "Year" },
                values: new object[,]
                {
                    { new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"), new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/banjo.jpg", "John Egbert Live", 65m, new DateTime(2021, 11, 26, 15, 57, 18, 607, DateTimeKind.Local).AddTicks(92) },
                    { new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"), new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/michael.jpg", "The State of Affairs: Michael Live!", 85m, new DateTime(2022, 2, 26, 15, 57, 18, 608, DateTimeKind.Local).AddTicks(6987) },
                    { new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"), new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/dj.jpg", "Clash of the DJs", 85m, new DateTime(2021, 9, 26, 15, 57, 18, 608, DateTimeKind.Local).AddTicks(7024) },
                    { new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"), new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/guitar.jpg", "Spanish guitar hits with Manuel", 25m, new DateTime(2021, 9, 26, 15, 57, 18, 608, DateTimeKind.Local).AddTicks(7040) },
                    { new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"), new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"), "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/musical.jpg", "To the Moon and Back", 135m, new DateTime(2022, 1, 26, 15, 57, 18, 608, DateTimeKind.Local).AddTicks(7067) },
                    { new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"), new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"), "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/conf.jpg", "Techorama 2021", 400m, new DateTime(2022, 3, 26, 15, 57, 18, 608, DateTimeKind.Local).AddTicks(7052) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
