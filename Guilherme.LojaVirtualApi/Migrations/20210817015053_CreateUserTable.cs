using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Guilherme.LojaVirtualApi.Migrations
{
    public partial class CreateUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "customers");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "customers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    refreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    refreshTokenExpireTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.UpdateData(
                table: "addresses",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 8, 16, 22, 50, 52, 491, DateTimeKind.Local).AddTicks(3077));

            migrationBuilder.UpdateData(
                table: "addresses",
                keyColumn: "id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 8, 16, 22, 50, 52, 491, DateTimeKind.Local).AddTicks(3182));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 8, 16, 22, 50, 52, 489, DateTimeKind.Local).AddTicks(1480));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 8, 16, 22, 50, 52, 489, DateTimeKind.Local).AddTicks(1533));

            migrationBuilder.UpdateData(
                table: "cities",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 8, 16, 22, 50, 52, 490, DateTimeKind.Local).AddTicks(8714));

            migrationBuilder.UpdateData(
                table: "cities",
                keyColumn: "id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 8, 16, 22, 50, 52, 490, DateTimeKind.Local).AddTicks(8774));

            migrationBuilder.UpdateData(
                table: "cities",
                keyColumn: "id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2021, 8, 16, 22, 50, 52, 490, DateTimeKind.Local).AddTicks(8779));

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 8, 16, 22, 50, 52, 489, DateTimeKind.Local).AddTicks(8982));

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumn: "id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 8, 16, 22, 50, 52, 489, DateTimeKind.Local).AddTicks(9077));

            migrationBuilder.UpdateData(
                table: "payments",
                keyColumn: "id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 8, 16, 22, 50, 52, 490, DateTimeKind.Local).AddTicks(4172));

            migrationBuilder.UpdateData(
                table: "payments",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 8, 16, 22, 50, 52, 490, DateTimeKind.Local).AddTicks(2274));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 8, 16, 22, 50, 52, 487, DateTimeKind.Local).AddTicks(5607));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 8, 16, 22, 50, 52, 489, DateTimeKind.Local).AddTicks(167));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2021, 8, 16, 22, 50, 52, 489, DateTimeKind.Local).AddTicks(205));

            migrationBuilder.UpdateData(
                table: "states",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 8, 16, 22, 50, 52, 490, DateTimeKind.Local).AddTicks(7047));

            migrationBuilder.UpdateData(
                table: "states",
                keyColumn: "id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 8, 16, 22, 50, 52, 490, DateTimeKind.Local).AddTicks(7085));

            migrationBuilder.UpdateData(
                table: "telephones",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 8, 16, 22, 50, 52, 490, DateTimeKind.Local).AddTicks(5844));

            migrationBuilder.UpdateData(
                table: "telephones",
                keyColumn: "id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 8, 16, 22, 50, 52, 490, DateTimeKind.Local).AddTicks(5897));

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "CreatedDate", "LastModifiedDate", "password", "refreshToken", "refreshTokenExpireTime", "Role", "username" },
                values: new object[] { 1L, new DateTime(2021, 8, 16, 22, 50, 52, 489, DateTimeKind.Local).AddTicks(3358), null, "1234", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "gui123" });

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "UserId" },
                values: new object[] { new DateTime(2021, 8, 16, 22, 50, 52, 489, DateTimeKind.Local).AddTicks(6377), 1L });

            migrationBuilder.CreateIndex(
                name: "IX_customers_UserId",
                table: "customers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_customers_users_UserId",
                table: "customers",
                column: "UserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_customers_users_UserId",
                table: "customers");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropIndex(
                name: "IX_customers_UserId",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "customers");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "addresses",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 8, 11, 0, 20, 15, 293, DateTimeKind.Local).AddTicks(3994));

            migrationBuilder.UpdateData(
                table: "addresses",
                keyColumn: "id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 8, 11, 0, 20, 15, 293, DateTimeKind.Local).AddTicks(4137));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 8, 11, 0, 20, 15, 291, DateTimeKind.Local).AddTicks(4992));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 8, 11, 0, 20, 15, 291, DateTimeKind.Local).AddTicks(5034));

            migrationBuilder.UpdateData(
                table: "cities",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 8, 11, 0, 20, 15, 292, DateTimeKind.Local).AddTicks(9713));

            migrationBuilder.UpdateData(
                table: "cities",
                keyColumn: "id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 8, 11, 0, 20, 15, 292, DateTimeKind.Local).AddTicks(9774));

            migrationBuilder.UpdateData(
                table: "cities",
                keyColumn: "id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2021, 8, 11, 0, 20, 15, 292, DateTimeKind.Local).AddTicks(9778));

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 8, 11, 0, 20, 15, 291, DateTimeKind.Local).AddTicks(7766));

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 8, 11, 0, 20, 15, 292, DateTimeKind.Local).AddTicks(199));

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumn: "id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 8, 11, 0, 20, 15, 292, DateTimeKind.Local).AddTicks(302));

            migrationBuilder.UpdateData(
                table: "payments",
                keyColumn: "id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 8, 11, 0, 20, 15, 292, DateTimeKind.Local).AddTicks(5157));

            migrationBuilder.UpdateData(
                table: "payments",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 8, 11, 0, 20, 15, 292, DateTimeKind.Local).AddTicks(3296));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 8, 11, 0, 20, 15, 289, DateTimeKind.Local).AddTicks(9399));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 8, 11, 0, 20, 15, 291, DateTimeKind.Local).AddTicks(3762));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2021, 8, 11, 0, 20, 15, 291, DateTimeKind.Local).AddTicks(3796));

            migrationBuilder.UpdateData(
                table: "states",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 8, 11, 0, 20, 15, 292, DateTimeKind.Local).AddTicks(8007));

            migrationBuilder.UpdateData(
                table: "states",
                keyColumn: "id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 8, 11, 0, 20, 15, 292, DateTimeKind.Local).AddTicks(8042));

            migrationBuilder.UpdateData(
                table: "telephones",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 8, 11, 0, 20, 15, 292, DateTimeKind.Local).AddTicks(6868));

            migrationBuilder.UpdateData(
                table: "telephones",
                keyColumn: "id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 8, 11, 0, 20, 15, 292, DateTimeKind.Local).AddTicks(6919));
        }
    }
}
