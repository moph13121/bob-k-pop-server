using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace bob_api.Migrations
{
    /// <inheritdoc />
    public partial class initMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    review = table.Column<string>(type: "text", nullable: false),
                    rating_value = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "text", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "text", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wishlist",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlist", x => x.id);
                    table.ForeignKey(
                        name: "FK_Wishlist_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<int>(type: "integer", nullable: false),
                    stock = table.Column<int>(type: "integer", nullable: false),
                    image = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    WishlistId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.id);
                    table.ForeignKey(
                        name: "FK_Product_Wishlist_WishlistId",
                        column: x => x.WishlistId,
                        principalTable: "Wishlist",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ProductOrders",
                columns: table => new
                {
                    order_id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOrders", x => new { x.order_id, x.product_id });
                    table.ForeignKey(
                        name: "FK_ProductOrders_Orders_order_id",
                        column: x => x.order_id,
                        principalTable: "Orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductOrders_Product_product_id",
                        column: x => x.product_id,
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_categories",
                columns: table => new
                {
                    CategoriesId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_categories", x => new { x.CategoriesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_product_categories_Category_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_categories_Product_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "id", "created_at", "name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("41d87680-71b4-4e33-b75e-0848249c347f"), new DateTime(2024, 3, 20, 12, 8, 50, 565, DateTimeKind.Utc).AddTicks(2535), "LightStick", new DateTime(2024, 3, 20, 12, 8, 50, 565, DateTimeKind.Utc).AddTicks(2535) },
                    { new Guid("58ab235a-6a2c-4256-b0a9-372a5e677f27"), new DateTime(2024, 3, 20, 12, 8, 50, 565, DateTimeKind.Utc).AddTicks(2525), "Blackpink", new DateTime(2024, 3, 20, 12, 8, 50, 565, DateTimeKind.Utc).AddTicks(2525) },
                    { new Guid("5c13feda-8634-47c0-9730-4b0931fda647"), new DateTime(2024, 3, 20, 12, 8, 50, 565, DateTimeKind.Utc).AddTicks(2522), "Ateez", new DateTime(2024, 3, 20, 12, 8, 50, 565, DateTimeKind.Utc).AddTicks(2523) },
                    { new Guid("787637d4-a174-4c39-8370-b811f7ea172e"), new DateTime(2024, 3, 20, 12, 8, 50, 565, DateTimeKind.Utc).AddTicks(2539), "Merch", new DateTime(2024, 3, 20, 12, 8, 50, 565, DateTimeKind.Utc).AddTicks(2539) },
                    { new Guid("7b8fd68a-7cf9-48d6-8834-e78ed35b9552"), new DateTime(2024, 3, 20, 12, 8, 50, 565, DateTimeKind.Utc).AddTicks(2519), "StrayKids", new DateTime(2024, 3, 20, 12, 8, 50, 565, DateTimeKind.Utc).AddTicks(2519) },
                    { new Guid("9eba0f71-6082-475b-bc4d-1b352e4d5045"), new DateTime(2024, 3, 20, 12, 8, 50, 565, DateTimeKind.Utc).AddTicks(2514), "Girl", new DateTime(2024, 3, 20, 12, 8, 50, 565, DateTimeKind.Utc).AddTicks(2515) },
                    { new Guid("a2e8b701-9f0b-4177-8a0e-8207bb800491"), new DateTime(2024, 3, 20, 12, 8, 50, 565, DateTimeKind.Utc).AddTicks(2473), "Boy", new DateTime(2024, 3, 20, 12, 8, 50, 565, DateTimeKind.Utc).AddTicks(2475) },
                    { new Guid("ae832498-682d-4ed0-b652-4c0ee7c52d0a"), new DateTime(2024, 3, 20, 12, 8, 50, 565, DateTimeKind.Utc).AddTicks(2537), "Jewelry", new DateTime(2024, 3, 20, 12, 8, 50, 565, DateTimeKind.Utc).AddTicks(2537) },
                    { new Guid("b2276c34-310b-4cc7-88bd-dfe3979f81ea"), new DateTime(2024, 3, 20, 12, 8, 50, 565, DateTimeKind.Utc).AddTicks(2526), "Red Velvet", new DateTime(2024, 3, 20, 12, 8, 50, 565, DateTimeKind.Utc).AddTicks(2527) },
                    { new Guid("d5b71eef-c3a6-405d-bc3c-1f75740c557f"), new DateTime(2024, 3, 20, 12, 8, 50, 565, DateTimeKind.Utc).AddTicks(2520), "BigBang", new DateTime(2024, 3, 20, 12, 8, 50, 565, DateTimeKind.Utc).AddTicks(2521) },
                    { new Guid("d8687c5c-22c6-4ecb-9e3c-1a56b77bbeaa"), new DateTime(2024, 3, 20, 12, 8, 50, 565, DateTimeKind.Utc).AddTicks(2528), "LE SSERAFIM.", new DateTime(2024, 3, 20, 12, 8, 50, 565, DateTimeKind.Utc).AddTicks(2529) },
                    { new Guid("e4302f11-3e56-4e30-9156-dd10fd0ef10e"), new DateTime(2024, 3, 20, 12, 8, 50, 565, DateTimeKind.Utc).AddTicks(2517), "BTS", new DateTime(2024, 3, 20, 12, 8, 50, 565, DateTimeKind.Utc).AddTicks(2517) },
                    { new Guid("fa8692c3-fd1b-44f5-af78-6ae8ddec070a"), new DateTime(2024, 3, 20, 12, 8, 50, 565, DateTimeKind.Utc).AddTicks(2533), "(G)I-DLE.", new DateTime(2024, 3, 20, 12, 8, 50, 565, DateTimeKind.Utc).AddTicks(2533) }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "id", "created_at", "description", "image", "price", "stock", "title", "updated_at", "WishlistId" },
                values: new object[,]
                {
                    { new Guid("3d4149d6-f21c-46b7-9c5f-cb02d3752cdc"), new DateTime(2024, 3, 20, 12, 8, 50, 565, DateTimeKind.Utc).AddTicks(2560), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "", 11, 10, "Test3", new DateTime(2024, 3, 20, 12, 8, 50, 565, DateTimeKind.Utc).AddTicks(2560), null },
                    { new Guid("c3ffdd68-55a0-42ae-b396-7b4a65248363"), new DateTime(2024, 3, 20, 12, 8, 50, 565, DateTimeKind.Utc).AddTicks(2551), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "", 10, 10, "TestBoy", new DateTime(2024, 3, 20, 12, 8, 50, 565, DateTimeKind.Utc).AddTicks(2551), null },
                    { new Guid("ef5f342e-e838-42a7-bfe0-803854e04aa1"), new DateTime(2024, 3, 20, 12, 8, 50, 565, DateTimeKind.Utc).AddTicks(2556), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "", 15, 10, "Test2", new DateTime(2024, 3, 20, 12, 8, 50, 565, DateTimeKind.Utc).AddTicks(2557), null },
                    { new Guid("f56f0b79-ba67-47c2-b4a7-2b605dba297a"), new DateTime(2024, 3, 20, 12, 8, 50, 565, DateTimeKind.Utc).AddTicks(2562), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "", 10, 10, "Test4", new DateTime(2024, 3, 20, 12, 8, 50, 565, DateTimeKind.Utc).AddTicks(2563), null }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "id", "created_at", "product_id", "rating_value", "review", "updated_at", "user_id" },
                values: new object[,]
                {
                    { new Guid("7872715f-42d3-4383-a088-022f3493834e"), new DateTime(2024, 3, 20, 12, 8, 50, 565, DateTimeKind.Utc).AddTicks(2634), new Guid("ef5f342e-e838-42a7-bfe0-803854e04aa1"), 5, "This product was straight fire blud", new DateTime(2024, 3, 20, 12, 8, 50, 565, DateTimeKind.Utc).AddTicks(2634), new Guid("4058a2c1-a40a-49ca-b6a0-896ea5af668c") },
                    { new Guid("d0e14d54-0a13-4f9b-a810-80f68804ba9d"), new DateTime(2024, 3, 20, 12, 8, 50, 565, DateTimeKind.Utc).AddTicks(2629), new Guid("c3ffdd68-55a0-42ae-b396-7b4a65248363"), 2, "This product was straight garbage cuh", new DateTime(2024, 3, 20, 12, 8, 50, 565, DateTimeKind.Utc).AddTicks(2629), new Guid("4058a2c1-a40a-49ca-b6a0-896ea5af668c") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "AccessFailedCount", "ConcurrencyStamp", "created_at", "email", "EmailConfirmed", "first_name", "last_name", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "updated_at", "UserName" },
                values: new object[] { new Guid("4058a2c1-a40a-49ca-b6a0-896ea5af668c"), 0, "1fe43c24-9021-418d-947a-419f36a9b8af", new DateTime(2024, 3, 20, 12, 8, 50, 565, DateTimeKind.Utc).AddTicks(2570), "test@test.no", false, "Test", "Test", false, null, null, null, "password", null, null, false, "fa497da1-e46c-411f-8446-415d236fc527", false, new DateTime(2024, 3, 20, 12, 8, 50, 565, DateTimeKind.Utc).AddTicks(2570), null });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "id", "created_at", "updated_at", "user_id", "status" },
                values: new object[] { new Guid("77ea01de-bb92-4496-bef3-e67ca4358d82"), new DateTime(2024, 3, 20, 12, 8, 50, 565, DateTimeKind.Utc).AddTicks(2624), new DateTime(2024, 3, 20, 12, 8, 50, 565, DateTimeKind.Utc).AddTicks(2624), new Guid("4058a2c1-a40a-49ca-b6a0-896ea5af668c"), "Pending" });

            migrationBuilder.InsertData(
                table: "ProductOrders",
                columns: new[] { "order_id", "product_id", "quantity" },
                values: new object[,]
                {
                    { new Guid("77ea01de-bb92-4496-bef3-e67ca4358d82"), new Guid("c3ffdd68-55a0-42ae-b396-7b4a65248363"), 1 },
                    { new Guid("77ea01de-bb92-4496-bef3-e67ca4358d82"), new Guid("ef5f342e-e838-42a7-bfe0-803854e04aa1"), 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_user_id",
                table: "Orders",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_WishlistId",
                table: "Product",
                column: "WishlistId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrders_product_id",
                table: "ProductOrders",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_user_id",
                table: "Wishlist",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_categories_ProductsId",
                table: "product_categories",
                column: "ProductsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductOrders");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "product_categories");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Wishlist");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
