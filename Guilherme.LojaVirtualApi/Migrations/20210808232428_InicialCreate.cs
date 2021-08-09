using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Guilherme.LojaVirtualApi.Migrations
{
    public partial class InicialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerType = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Telephones",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telephones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Telephones_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryProducts",
                columns: table => new
                {
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProducts", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_CategoryProducts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Complement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Block = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    CityId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Addresses_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryAddressId = table.Column<long>(type: "bigint", nullable: false),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Addresses_DeliveryAddressId",
                        column: x => x.DeliveryAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => new { x.ProductId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_OrderProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PayDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Installments = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2021, 8, 8, 20, 24, 27, 348, DateTimeKind.Local).AddTicks(628), null, "Informatica" },
                    { 2L, new DateTime(2021, 8, 8, 20, 24, 27, 348, DateTimeKind.Local).AddTicks(663), null, "Escritorio" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Cnpj", "Cpf", "CreatedDate", "CustomerType", "Email", "LastModifiedDate", "Name", "Password" },
                values: new object[] { 1L, null, "36378912377", new DateTime(2021, 8, 8, 20, 24, 27, 348, DateTimeKind.Local).AddTicks(3510), 0, "maria@gmail.com", null, "Maria Silva", null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "LastModifiedDate", "Name", "Price" },
                values: new object[,]
                {
                    { 1L, new DateTime(2021, 8, 8, 20, 24, 27, 346, DateTimeKind.Local).AddTicks(5852), null, "Computador", 2000.0 },
                    { 2L, new DateTime(2021, 8, 8, 20, 24, 27, 347, DateTimeKind.Local).AddTicks(9406), null, "Impressora", 800.0 },
                    { 3L, new DateTime(2021, 8, 8, 20, 24, 27, 347, DateTimeKind.Local).AddTicks(9439), null, "Mouse", 80.0 }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "CreatedDate", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2021, 8, 8, 20, 24, 27, 349, DateTimeKind.Local).AddTicks(3477), null, "Minas Gerais" },
                    { 2L, new DateTime(2021, 8, 8, 20, 24, 27, 349, DateTimeKind.Local).AddTicks(3510), null, "São Paulo" }
                });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "CategoryId", "ProductId", "CreatedDate", "Id", "LastModifiedDate" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2021, 8, 8, 20, 24, 27, 350, DateTimeKind.Local).AddTicks(1059), 1L, null },
                    { 1L, 2L, new DateTime(2021, 8, 8, 20, 24, 27, 350, DateTimeKind.Local).AddTicks(1099), 2L, null },
                    { 2L, 2L, new DateTime(2021, 8, 8, 20, 24, 27, 350, DateTimeKind.Local).AddTicks(1103), 3L, null },
                    { 1L, 3L, new DateTime(2021, 8, 8, 20, 24, 27, 350, DateTimeKind.Local).AddTicks(1106), 4L, null }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CreatedDate", "LastModifiedDate", "Name", "StateId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2021, 8, 8, 20, 24, 27, 349, DateTimeKind.Local).AddTicks(5392), null, "Uberlândia", 1L },
                    { 2L, new DateTime(2021, 8, 8, 20, 24, 27, 349, DateTimeKind.Local).AddTicks(5450), null, "São Paulo", 2L },
                    { 3L, new DateTime(2021, 8, 8, 20, 24, 27, 349, DateTimeKind.Local).AddTicks(5454), null, "Campinas", 2L }
                });

            migrationBuilder.InsertData(
                table: "Telephones",
                columns: new[] { "Id", "CreatedDate", "CustomerId", "LastModifiedDate", "Number" },
                values: new object[,]
                {
                    { 1L, new DateTime(2021, 8, 8, 20, 24, 27, 349, DateTimeKind.Local).AddTicks(2363), 1L, null, "27363323" },
                    { 2L, new DateTime(2021, 8, 8, 20, 24, 27, 349, DateTimeKind.Local).AddTicks(2405), 1L, null, "27363323" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "Block", "CityId", "Complement", "CreatedDate", "CustomerId", "LastModifiedDate", "Number", "Street", "ZipCode" },
                values: new object[] { 1L, "Jardim", 1L, "Apto 203", new DateTime(2021, 8, 8, 20, 24, 27, 349, DateTimeKind.Local).AddTicks(9485), 1L, null, "300", "Rua das Flores", "382220834" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "Block", "CityId", "Complement", "CreatedDate", "CustomerId", "LastModifiedDate", "Number", "Street", "ZipCode" },
                values: new object[] { 2L, "Centro", 2L, "Sala 800", new DateTime(2021, 8, 8, 20, 24, 27, 349, DateTimeKind.Local).AddTicks(9576), 1L, null, "105", "Avenida Matos", "38777012" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedDate", "CustomerId", "Date", "DeliveryAddressId", "LastModifiedDate" },
                values: new object[] { 1L, new DateTime(2021, 8, 8, 20, 24, 27, 348, DateTimeKind.Local).AddTicks(5985), 1L, new DateTime(2021, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, null });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedDate", "CustomerId", "Date", "DeliveryAddressId", "LastModifiedDate" },
                values: new object[] { 2L, new DateTime(2021, 8, 8, 20, 24, 27, 348, DateTimeKind.Local).AddTicks(6052), 1L, new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, null });

            migrationBuilder.InsertData(
                table: "OrderProducts",
                columns: new[] { "OrderId", "ProductId", "CreatedDate", "Discount", "Id", "LastModifiedDate", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2021, 8, 8, 20, 24, 27, 350, DateTimeKind.Local).AddTicks(4087), 0.0, 1L, null, 2000.0, 1 },
                    { 1L, 3L, new DateTime(2021, 8, 8, 20, 24, 27, 350, DateTimeKind.Local).AddTicks(4177), 0.0, 2L, null, 80.0, 2 },
                    { 2L, 2L, new DateTime(2021, 8, 8, 20, 24, 27, 350, DateTimeKind.Local).AddTicks(4182), 0.0, 3L, null, 800.0, 1 }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "CreatedDate", "Discriminator", "Installments", "LastModifiedDate", "OrderId", "PaymentStatus" },
                values: new object[] { 1L, new DateTime(2021, 8, 8, 20, 24, 27, 348, DateTimeKind.Local).AddTicks(8942), "PaymentWithCard", 6, null, 1L, 1 });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "CreatedDate", "Discriminator", "DueDate", "LastModifiedDate", "OrderId", "PayDate", "PaymentStatus" },
                values: new object[] { 2L, new DateTime(2021, 8, 8, 20, 24, 27, 349, DateTimeKind.Local).AddTicks(826), "PaymentWithBillet", new DateTime(2021, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2L, null, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CustomerId",
                table: "Addresses",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProducts_CategoryId",
                table: "CategoryProducts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_OrderId",
                table: "OrderProducts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryAddressId",
                table: "Orders",
                column: "DeliveryAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Telephones_CustomerId",
                table: "Telephones",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProducts");

            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Telephones");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
