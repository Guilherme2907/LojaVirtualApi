using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Guilherme.LojaVirtualApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cnpj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerType = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "states",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_states", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "telephones",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_telephones", x => x.id);
                    table.ForeignKey(
                        name: "FK_telephones_customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "category-products",
                columns: table => new
                {
                    CategoriesId = table.Column<long>(type: "bigint", nullable: false),
                    ProductsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category-products", x => new { x.CategoriesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_category-products_categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_category-products_products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StateId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cities", x => x.id);
                    table.ForeignKey(
                        name: "FK_cities_states_StateId",
                        column: x => x.StateId,
                        principalTable: "states",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    complement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    block = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    zipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    CityId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresses", x => x.id);
                    table.ForeignKey(
                        name: "FK_addresses_cities_CityId",
                        column: x => x.CityId,
                        principalTable: "cities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_addresses_customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryAddressId = table.Column<long>(type: "bigint", nullable: false),
                    PaymentId = table.Column<long>(type: "bigint", nullable: false),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_orders_addresses_DeliveryAddressId",
                        column: x => x.DeliveryAddressId,
                        principalTable: "addresses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orders_customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "order-Items",
                columns: table => new
                {
                    orderId = table.Column<long>(type: "bigint", nullable: false),
                    productId = table.Column<long>(type: "bigint", nullable: false),
                    discount = table.Column<double>(type: "float", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order-Items", x => new { x.orderId, x.productId });
                    table.ForeignKey(
                        name: "FK_order-Items_orders_orderId",
                        column: x => x.orderId,
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_order-Items_products_productId",
                        column: x => x.productId,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    paymentStatus = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    payDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    installments = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.id);
                    table.ForeignKey(
                        name: "FK_payments_orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "CreatedDate", "LastModifiedDate", "name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2021, 8, 11, 0, 20, 15, 291, DateTimeKind.Local).AddTicks(4992), null, "Informatica" },
                    { 2L, new DateTime(2021, 8, 11, 0, 20, 15, 291, DateTimeKind.Local).AddTicks(5034), null, "Escritorio" }
                });

            migrationBuilder.InsertData(
                table: "customers",
                columns: new[] { "id", "cnpj", "cpf", "CreatedDate", "CustomerType", "email", "LastModifiedDate", "name", "Password" },
                values: new object[] { 1L, null, "36378912377", new DateTime(2021, 8, 11, 0, 20, 15, 291, DateTimeKind.Local).AddTicks(7766), 0, "maria@gmail.com", null, "Maria Silva", null });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "id", "CreatedDate", "LastModifiedDate", "name", "price" },
                values: new object[,]
                {
                    { 1L, new DateTime(2021, 8, 11, 0, 20, 15, 289, DateTimeKind.Local).AddTicks(9399), null, "Computador", 2000.0 },
                    { 2L, new DateTime(2021, 8, 11, 0, 20, 15, 291, DateTimeKind.Local).AddTicks(3762), null, "Impressora", 800.0 },
                    { 3L, new DateTime(2021, 8, 11, 0, 20, 15, 291, DateTimeKind.Local).AddTicks(3796), null, "Mouse", 80.0 }
                });

            migrationBuilder.InsertData(
                table: "states",
                columns: new[] { "id", "CreatedDate", "LastModifiedDate", "name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2021, 8, 11, 0, 20, 15, 292, DateTimeKind.Local).AddTicks(8007), null, "Minas Gerais" },
                    { 2L, new DateTime(2021, 8, 11, 0, 20, 15, 292, DateTimeKind.Local).AddTicks(8042), null, "São Paulo" }
                });

            migrationBuilder.InsertData(
                table: "cities",
                columns: new[] { "id", "CreatedDate", "LastModifiedDate", "name", "StateId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2021, 8, 11, 0, 20, 15, 292, DateTimeKind.Local).AddTicks(9713), null, "Uberlândia", 1L },
                    { 2L, new DateTime(2021, 8, 11, 0, 20, 15, 292, DateTimeKind.Local).AddTicks(9774), null, "São Paulo", 2L },
                    { 3L, new DateTime(2021, 8, 11, 0, 20, 15, 292, DateTimeKind.Local).AddTicks(9778), null, "Campinas", 2L }
                });

            migrationBuilder.InsertData(
                table: "telephones",
                columns: new[] { "id", "CreatedDate", "CustomerId", "LastModifiedDate", "number" },
                values: new object[,]
                {
                    { 1L, new DateTime(2021, 8, 11, 0, 20, 15, 292, DateTimeKind.Local).AddTicks(6868), 1L, null, "27363323" },
                    { 2L, new DateTime(2021, 8, 11, 0, 20, 15, 292, DateTimeKind.Local).AddTicks(6919), 1L, null, "27363323" }
                });

            migrationBuilder.InsertData(
                table: "addresses",
                columns: new[] { "id", "block", "CityId", "complement", "CreatedDate", "CustomerId", "LastModifiedDate", "number", "street", "zipCode" },
                values: new object[] { 1L, "Jardim", 1L, "Apto 203", new DateTime(2021, 8, 11, 0, 20, 15, 293, DateTimeKind.Local).AddTicks(3994), 1L, null, "300", "Rua das Flores", "382220834" });

            migrationBuilder.InsertData(
                table: "addresses",
                columns: new[] { "id", "block", "CityId", "complement", "CreatedDate", "CustomerId", "LastModifiedDate", "number", "street", "zipCode" },
                values: new object[] { 2L, "Centro", 2L, "Sala 800", new DateTime(2021, 8, 11, 0, 20, 15, 293, DateTimeKind.Local).AddTicks(4137), 1L, null, "105", "Avenida Matos", "38777012" });

            migrationBuilder.InsertData(
                table: "orders",
                columns: new[] { "id", "CreatedDate", "CustomerId", "date", "DeliveryAddressId", "LastModifiedDate", "PaymentId" },
                values: new object[] { 1L, new DateTime(2021, 8, 11, 0, 20, 15, 292, DateTimeKind.Local).AddTicks(199), 1L, new DateTime(2021, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, null, 0L });

            migrationBuilder.InsertData(
                table: "orders",
                columns: new[] { "id", "CreatedDate", "CustomerId", "date", "DeliveryAddressId", "LastModifiedDate", "PaymentId" },
                values: new object[] { 2L, new DateTime(2021, 8, 11, 0, 20, 15, 292, DateTimeKind.Local).AddTicks(302), 1L, new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, null, 0L });

            migrationBuilder.InsertData(
                table: "order-Items",
                columns: new[] { "orderId", "productId", "discount", "price", "quantity" },
                values: new object[,]
                {
                    { 1L, 1L, 0.0, 2000.0, 1 },
                    { 1L, 3L, 0.0, 80.0, 2 },
                    { 2L, 2L, 0.0, 800.0, 1 }
                });

            migrationBuilder.InsertData(
                table: "payments",
                columns: new[] { "id", "CreatedDate", "Discriminator", "installments", "LastModifiedDate", "OrderId", "paymentStatus" },
                values: new object[] { 1L, new DateTime(2021, 8, 11, 0, 20, 15, 292, DateTimeKind.Local).AddTicks(3296), "PaymentWithCard", 6, null, 1L, 1 });

            migrationBuilder.InsertData(
                table: "payments",
                columns: new[] { "id", "CreatedDate", "Discriminator", "dueDate", "LastModifiedDate", "OrderId", "payDate", "paymentStatus" },
                values: new object[] { 2L, new DateTime(2021, 8, 11, 0, 20, 15, 292, DateTimeKind.Local).AddTicks(5157), "PaymentWithBillet", new DateTime(2021, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2L, null, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_addresses_CityId",
                table: "addresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_addresses_CustomerId",
                table: "addresses",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_category-products_ProductsId",
                table: "category-products",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_cities_StateId",
                table: "cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_order-Items_productId",
                table: "order-Items",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_CustomerId",
                table: "orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_DeliveryAddressId",
                table: "orders",
                column: "DeliveryAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_payments_OrderId",
                table: "payments",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_telephones_CustomerId",
                table: "telephones",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "category-products");

            migrationBuilder.DropTable(
                name: "order-Items");

            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DropTable(
                name: "telephones");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "addresses");

            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "states");
        }
    }
}
