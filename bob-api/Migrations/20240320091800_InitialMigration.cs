using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace bob_api.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
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
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOrders", x => new { x.user_id, x.product_id });
                    table.ForeignKey(
                        name: "FK_ProductOrders_Orders_user_id",
                        column: x => x.user_id,
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
                    { new Guid("084629ac-cf01-4f98-b6ed-d4c5cb56c00f"), new DateTime(2024, 3, 20, 9, 17, 54, 923, DateTimeKind.Utc).AddTicks(8129), "StrayKids", new DateTime(2024, 3, 20, 9, 17, 54, 923, DateTimeKind.Utc).AddTicks(8129) },
                    { new Guid("3dc941fe-38bb-4366-a44e-aeca8027ef5c"), new DateTime(2024, 3, 20, 9, 17, 54, 923, DateTimeKind.Utc).AddTicks(8141), "Merch", new DateTime(2024, 3, 20, 9, 17, 54, 923, DateTimeKind.Utc).AddTicks(8141) },
                    { new Guid("4700fdb8-e263-4453-9adc-d4683e05c1c3"), new DateTime(2024, 3, 20, 9, 17, 54, 923, DateTimeKind.Utc).AddTicks(8138), "LightStick", new DateTime(2024, 3, 20, 9, 17, 54, 923, DateTimeKind.Utc).AddTicks(8139) },
                    { new Guid("4bea4590-2f31-4457-857e-0191907f7c7b"), new DateTime(2024, 3, 20, 9, 17, 54, 923, DateTimeKind.Utc).AddTicks(8133), "Blackpink", new DateTime(2024, 3, 20, 9, 17, 54, 923, DateTimeKind.Utc).AddTicks(8133) },
                    { new Guid("535823a1-a387-4bac-ae86-d19bb6cc86c2"), new DateTime(2024, 3, 20, 9, 17, 54, 923, DateTimeKind.Utc).AddTicks(8134), "Red Velvet", new DateTime(2024, 3, 20, 9, 17, 54, 923, DateTimeKind.Utc).AddTicks(8134) },
                    { new Guid("62dc179f-73c1-4b51-a71a-38f51063d3e9"), new DateTime(2024, 3, 20, 9, 17, 54, 923, DateTimeKind.Utc).AddTicks(8135), "LE SSERAFIM.", new DateTime(2024, 3, 20, 9, 17, 54, 923, DateTimeKind.Utc).AddTicks(8135) },
                    { new Guid("79400b3c-26e9-4150-898a-2d6f881421b9"), new DateTime(2024, 3, 20, 9, 17, 54, 923, DateTimeKind.Utc).AddTicks(8126), "Girl", new DateTime(2024, 3, 20, 9, 17, 54, 923, DateTimeKind.Utc).AddTicks(8127) },
                    { new Guid("9aa924f8-6583-4197-a68a-4f5f166b67db"), new DateTime(2024, 3, 20, 9, 17, 54, 923, DateTimeKind.Utc).AddTicks(8140), "Jewelry", new DateTime(2024, 3, 20, 9, 17, 54, 923, DateTimeKind.Utc).AddTicks(8140) },
                    { new Guid("b1a5f6f5-d279-4c56-b03c-af1706dba170"), new DateTime(2024, 3, 20, 9, 17, 54, 923, DateTimeKind.Utc).AddTicks(8128), "BTS", new DateTime(2024, 3, 20, 9, 17, 54, 923, DateTimeKind.Utc).AddTicks(8128) },
                    { new Guid("c75bd07e-0c1f-4291-b622-017823f1868c"), new DateTime(2024, 3, 20, 9, 17, 54, 923, DateTimeKind.Utc).AddTicks(8093), "Boy", new DateTime(2024, 3, 20, 9, 17, 54, 923, DateTimeKind.Utc).AddTicks(8095) },
                    { new Guid("c998a3af-bc7a-4f3b-a3e2-56960edf62e8"), new DateTime(2024, 3, 20, 9, 17, 54, 923, DateTimeKind.Utc).AddTicks(8130), "BigBang", new DateTime(2024, 3, 20, 9, 17, 54, 923, DateTimeKind.Utc).AddTicks(8131) },
                    { new Guid("dc477ed9-43c9-4ede-82b4-b23892ada3d6"), new DateTime(2024, 3, 20, 9, 17, 54, 923, DateTimeKind.Utc).AddTicks(8137), "(G)I-DLE.", new DateTime(2024, 3, 20, 9, 17, 54, 923, DateTimeKind.Utc).AddTicks(8138) },
                    { new Guid("f2105153-8a61-48c0-aceb-a3ccf9a5ca4f"), new DateTime(2024, 3, 20, 9, 17, 54, 923, DateTimeKind.Utc).AddTicks(8132), "Ateez", new DateTime(2024, 3, 20, 9, 17, 54, 923, DateTimeKind.Utc).AddTicks(8132) }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "id", "created_at", "updated_at", "user_id", "status" },
                values: new object[] { new Guid("c4ddb064-2b37-4600-b680-12deb24a94db"), new DateTime(2024, 3, 20, 9, 17, 54, 923, DateTimeKind.Utc).AddTicks(8191), new DateTime(2024, 3, 20, 9, 17, 54, 923, DateTimeKind.Utc).AddTicks(8191), new Guid("bdbc33e0-2930-41fa-9f39-1552386d177f"), "Pending" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "id", "created_at", "description", "image", "price", "stock", "title", "updated_at", "WishlistId" },
                values: new object[,]
                {
                    { new Guid("4bbd137c-cd9c-41e7-bd66-9c885feaa1ab"), new DateTime(2024, 3, 20, 9, 17, 54, 923, DateTimeKind.Utc).AddTicks(8150), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "", 15, 10, "Test2", new DateTime(2024, 3, 20, 9, 17, 54, 923, DateTimeKind.Utc).AddTicks(8151), null },
                    { new Guid("ba58055b-4139-4b3c-9036-5fcbe77156d8"), new DateTime(2024, 3, 20, 9, 17, 54, 923, DateTimeKind.Utc).AddTicks(8154), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "", 10, 10, "Test4", new DateTime(2024, 3, 20, 9, 17, 54, 923, DateTimeKind.Utc).AddTicks(8154), null },
                    { new Guid("d32872fd-24b5-411b-bffb-1f22e71db681"), new DateTime(2024, 3, 20, 9, 17, 54, 923, DateTimeKind.Utc).AddTicks(8148), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "", 10, 10, "TestBoy", new DateTime(2024, 3, 20, 9, 17, 54, 923, DateTimeKind.Utc).AddTicks(8148), null },
                    { new Guid("e8f23f42-5279-4384-84ba-721279656442"), new DateTime(2024, 3, 20, 9, 17, 54, 923, DateTimeKind.Utc).AddTicks(8152), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "", 11, 10, "Test3", new DateTime(2024, 3, 20, 9, 17, 54, 923, DateTimeKind.Utc).AddTicks(8152), null }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "id", "created_at", "product_id", "rating_value", "review", "updated_at", "user_id" },
                values: new object[,]
                {
                    { new Guid("0c586465-aa64-456c-a39f-f428526bfc8f"), new DateTime(2024, 3, 20, 9, 17, 54, 923, DateTimeKind.Utc).AddTicks(8196), new Guid("d32872fd-24b5-411b-bffb-1f22e71db681"), 2, "This product was straight garbage cuh", new DateTime(2024, 3, 20, 9, 17, 54, 923, DateTimeKind.Utc).AddTicks(8196), new Guid("bdbc33e0-2930-41fa-9f39-1552386d177f") },
                    { new Guid("3bbc9779-5cb4-4163-b363-cb0edd6dc26a"), new DateTime(2024, 3, 20, 9, 17, 54, 923, DateTimeKind.Utc).AddTicks(8199), new Guid("4bbd137c-cd9c-41e7-bd66-9c885feaa1ab"), 5, "This product was straight fire blud", new DateTime(2024, 3, 20, 9, 17, 54, 923, DateTimeKind.Utc).AddTicks(8200), new Guid("bdbc33e0-2930-41fa-9f39-1552386d177f") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "AccessFailedCount", "ConcurrencyStamp", "created_at", "email", "EmailConfirmed", "first_name", "last_name", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "updated_at", "UserName" },
                values: new object[] { new Guid("bdbc33e0-2930-41fa-9f39-1552386d177f"), 0, "04a9a43c-0e64-4745-8948-b063498423fe", new DateTime(2024, 3, 20, 9, 17, 54, 923, DateTimeKind.Utc).AddTicks(8158), "test@test.no", false, "Test", "Test", false, null, null, null, "password", null, null, false, "415177c6-0b68-49cb-82c2-04d03dd1f6e5", false, new DateTime(2024, 3, 20, 9, 17, 54, 923, DateTimeKind.Utc).AddTicks(8158), null });

            migrationBuilder.InsertData(
                table: "ProductOrders",
                columns: new[] { "user_id", "product_id", "quantity" },
                values: new object[,]
                {
                    { new Guid("c4ddb064-2b37-4600-b680-12deb24a94db"), new Guid("4bbd137c-cd9c-41e7-bd66-9c885feaa1ab"), 3 },
                    { new Guid("c4ddb064-2b37-4600-b680-12deb24a94db"), new Guid("d32872fd-24b5-411b-bffb-1f22e71db681"), 1 }
                });

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
