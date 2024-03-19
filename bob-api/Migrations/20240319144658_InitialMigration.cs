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
                    { new Guid("15b0e60e-38b7-4ca8-9542-ed2b60480f32"), new DateTime(2024, 3, 19, 14, 46, 52, 855, DateTimeKind.Utc).AddTicks(2891), "BigBang", new DateTime(2024, 3, 19, 14, 46, 52, 855, DateTimeKind.Utc).AddTicks(2891) },
                    { new Guid("2044935b-97cb-4bc0-85f2-670ce09ea92f"), new DateTime(2024, 3, 19, 14, 46, 52, 855, DateTimeKind.Utc).AddTicks(2893), "Ateez", new DateTime(2024, 3, 19, 14, 46, 52, 855, DateTimeKind.Utc).AddTicks(2894) },
                    { new Guid("352d4b7b-a322-4d12-970d-ecfd45061101"), new DateTime(2024, 3, 19, 14, 46, 52, 855, DateTimeKind.Utc).AddTicks(2875), "StrayKids", new DateTime(2024, 3, 19, 14, 46, 52, 855, DateTimeKind.Utc).AddTicks(2875) },
                    { new Guid("3b54993a-489c-4fa3-bbd4-d300ab799c66"), new DateTime(2024, 3, 19, 14, 46, 52, 855, DateTimeKind.Utc).AddTicks(2902), "LightStick", new DateTime(2024, 3, 19, 14, 46, 52, 855, DateTimeKind.Utc).AddTicks(2903) },
                    { new Guid("44ffdd71-f5f0-4227-bbb4-4a797f297ed2"), new DateTime(2024, 3, 19, 14, 46, 52, 855, DateTimeKind.Utc).AddTicks(2873), "BTS", new DateTime(2024, 3, 19, 14, 46, 52, 855, DateTimeKind.Utc).AddTicks(2874) },
                    { new Guid("5665ddc6-e486-4cd8-8916-daaf06c613fd"), new DateTime(2024, 3, 19, 14, 46, 52, 855, DateTimeKind.Utc).AddTicks(2895), "Blackpink", new DateTime(2024, 3, 19, 14, 46, 52, 855, DateTimeKind.Utc).AddTicks(2895) },
                    { new Guid("5b752fb8-0a89-4be8-a518-c9c40eef301f"), new DateTime(2024, 3, 19, 14, 46, 52, 855, DateTimeKind.Utc).AddTicks(2899), "LE SSERAFIM.", new DateTime(2024, 3, 19, 14, 46, 52, 855, DateTimeKind.Utc).AddTicks(2899) },
                    { new Guid("7988338b-d869-43ed-8edd-879a6d82a623"), new DateTime(2024, 3, 19, 14, 46, 52, 855, DateTimeKind.Utc).AddTicks(2897), "Red Velvet", new DateTime(2024, 3, 19, 14, 46, 52, 855, DateTimeKind.Utc).AddTicks(2897) },
                    { new Guid("a693783d-0000-4470-a551-a9ffa6be5e99"), new DateTime(2024, 3, 19, 14, 46, 52, 855, DateTimeKind.Utc).AddTicks(2871), "Girl", new DateTime(2024, 3, 19, 14, 46, 52, 855, DateTimeKind.Utc).AddTicks(2871) },
                    { new Guid("c6a0b126-7e7b-4d44-8e5f-2db08faa0a94"), new DateTime(2024, 3, 19, 14, 46, 52, 855, DateTimeKind.Utc).AddTicks(2900), "(G)I-DLE.", new DateTime(2024, 3, 19, 14, 46, 52, 855, DateTimeKind.Utc).AddTicks(2901) },
                    { new Guid("c8ebb5f8-dbda-433d-9b64-0f94fbcc2bbc"), new DateTime(2024, 3, 19, 14, 46, 52, 855, DateTimeKind.Utc).AddTicks(2910), "Merch", new DateTime(2024, 3, 19, 14, 46, 52, 855, DateTimeKind.Utc).AddTicks(2911) },
                    { new Guid("d883bb8d-0565-4759-96e3-ecacaf6068dd"), new DateTime(2024, 3, 19, 14, 46, 52, 855, DateTimeKind.Utc).AddTicks(2810), "Boy", new DateTime(2024, 3, 19, 14, 46, 52, 855, DateTimeKind.Utc).AddTicks(2816) },
                    { new Guid("daea78a2-03da-4022-9ed4-4113cb4d9474"), new DateTime(2024, 3, 19, 14, 46, 52, 855, DateTimeKind.Utc).AddTicks(2904), "Jewelry", new DateTime(2024, 3, 19, 14, 46, 52, 855, DateTimeKind.Utc).AddTicks(2905) }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "id", "created_at", "updated_at", "user_id", "status" },
                values: new object[] { new Guid("a16a772b-e563-4937-ad23-807e5638e0d7"), new DateTime(2024, 3, 19, 14, 46, 52, 855, DateTimeKind.Utc).AddTicks(3021), new DateTime(2024, 3, 19, 14, 46, 52, 855, DateTimeKind.Utc).AddTicks(3022), new Guid("c117ebdf-0dbc-4d5a-a207-924a8d945dca"), "Unfinished" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "id", "created_at", "description", "image", "price", "stock", "title", "updated_at", "WishlistId" },
                values: new object[,]
                {
                    { new Guid("3cd66a3d-fe79-4827-b179-69f9693bf829"), new DateTime(2024, 3, 19, 14, 46, 52, 855, DateTimeKind.Utc).AddTicks(2942), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "", 11, 10, "Test3", new DateTime(2024, 3, 19, 14, 46, 52, 855, DateTimeKind.Utc).AddTicks(2943), null },
                    { new Guid("49c977db-60c4-4a30-bc1e-4e644fb5b951"), new DateTime(2024, 3, 19, 14, 46, 52, 855, DateTimeKind.Utc).AddTicks(2933), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "", 10, 10, "TestBoy", new DateTime(2024, 3, 19, 14, 46, 52, 855, DateTimeKind.Utc).AddTicks(2933), null },
                    { new Guid("e8153be0-8ca5-43b6-9e0a-3e8f72b12922"), new DateTime(2024, 3, 19, 14, 46, 52, 855, DateTimeKind.Utc).AddTicks(2945), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "", 10, 10, "Test4", new DateTime(2024, 3, 19, 14, 46, 52, 855, DateTimeKind.Utc).AddTicks(2945), null },
                    { new Guid("f776b7de-5bf6-4219-b695-3bda7220a334"), new DateTime(2024, 3, 19, 14, 46, 52, 855, DateTimeKind.Utc).AddTicks(2939), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "", 15, 10, "Test2", new DateTime(2024, 3, 19, 14, 46, 52, 855, DateTimeKind.Utc).AddTicks(2939), null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "AccessFailedCount", "ConcurrencyStamp", "created_at", "email", "EmailConfirmed", "first_name", "last_name", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "updated_at", "UserName" },
                values: new object[] { new Guid("c117ebdf-0dbc-4d5a-a207-924a8d945dca"), 0, "315c0a71-b5de-4319-ab9e-bfc66ad5254b", new DateTime(2024, 3, 19, 14, 46, 52, 855, DateTimeKind.Utc).AddTicks(2950), "test@test.no", false, "Test", "Test", false, null, null, null, "password", null, null, false, "7175224e-56c7-4597-b8ee-dd613da2711c", false, new DateTime(2024, 3, 19, 14, 46, 52, 855, DateTimeKind.Utc).AddTicks(2951), null });

            migrationBuilder.CreateIndex(
                name: "IX_Product_WishlistId",
                table: "Product",
                column: "WishlistId");

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
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ProductOrders");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "product_categories");

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
