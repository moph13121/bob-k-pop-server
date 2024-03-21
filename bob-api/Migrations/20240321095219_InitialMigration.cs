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
                name: "ProductCategory",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "id", "created_at", "name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("082c44a8-5d8c-4b7d-b4aa-ef31cc202338"), new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(320), "Boy", new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(323) },
                    { new Guid("35db38c3-8949-4c43-bf66-2379c5f40d12"), new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(364), "Blackpink", new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(365) },
                    { new Guid("651ec71d-6595-4da6-9208-9ee50c3db5d3"), new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(363), "Ateez", new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(363) },
                    { new Guid("713af980-25c7-4527-b563-d20941644593"), new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(377), "Jewelry", new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(377) },
                    { new Guid("71b337d1-044b-4e1d-a006-c1ac44b390fd"), new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(366), "Red Velvet", new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(366) },
                    { new Guid("783a12af-a925-456a-82b1-8a6d999998dc"), new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(371), "Girls Generation", new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(371) },
                    { new Guid("79ffc79c-1203-45d7-a60d-522116a07589"), new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(359), "BTS", new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(359) },
                    { new Guid("7fc4d300-3c0a-4a94-ac2d-2c1572270799"), new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(374), "Seventeen", new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(375) },
                    { new Guid("8d7b666b-d420-49fc-921e-507fb60f0c56"), new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(360), "StrayKids", new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(361) },
                    { new Guid("a1190251-f42d-4e04-849e-7e8c743ceabf"), new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(380), "Music", new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(381) },
                    { new Guid("b064dda5-3ae4-43f4-a265-604ee6b8bda6"), new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(373), "Twice", new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(373) },
                    { new Guid("c0a87bf6-0057-48c8-a0a3-5a1548e7e827"), new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(362), "BigBang", new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(362) },
                    { new Guid("c2999434-3a40-4773-9874-3480b407b468"), new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(370), "(G)I-DLE.", new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(370) },
                    { new Guid("c468a87b-5cbc-4d7a-bce1-ac38424a6b1b"), new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(357), "Girl", new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(357) },
                    { new Guid("cb2b831f-9fd1-43d8-867b-f03067414658"), new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(375), "LightStick", new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(376) },
                    { new Guid("ebe643e6-9dae-4c28-b85d-95e5b7737167"), new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(378), "Merch", new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(378) },
                    { new Guid("f4ccb7fe-4090-4e30-8ade-1a3be7c8c266"), new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(372), "EXO", new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(372) },
                    { new Guid("fb06df6e-5c03-40a0-a393-36046864dd38"), new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(367), "LE SSERAFIM.", new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(367) }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "id", "created_at", "description", "image", "price", "stock", "title", "updated_at", "WishlistId" },
                values: new object[,]
                {
                    { new Guid("0068505e-4925-4b61-9cdc-4173e8946e9e"), new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(396), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://github.com/moph13121/bob-k-pop-server/blob/main/images/Jewelry_boys/-bs114-bts-mao-earring-ear-cuff-piercing-removebg-preview.png", 11, 10, "BTS Mao Earring", new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(397), null },
                    { new Guid("1328f1e4-0b59-4fe0-847a-3a151e5bdcfb"), new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(469), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://github.com/moph13121/bob-k-pop-server/blob/main/images/Lightsticks_boys/BIGBANG%20OFFICIAL%20LIGHT%20STICK%20VER%204.png", 10, 10, "BigBang Official Light Stick ", new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(469), null },
                    { new Guid("1d7d0e0a-a2fa-460d-b15f-9d9d92fe4b83"), new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(393), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://github.com/moph13121/bob-k-pop-server/blob/main/images/Jewelry_boys/-az05-ateez-range-piercing-earring-earcuff-removebg-preview.png", 10, 10, "Ateez Earcuff", new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(393), null },
                    { new Guid("22b43960-2b8d-4d5e-a20c-0817cf26ceae"), new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(409), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://github.com/moph13121/bob-k-pop-server/blob/main/images/KpopMusic_boys/ATEEZ%20-%20THE%20WORLD%20EP%202%20%20OUTLAW.png", 10, 10, "Ateez - The World EP 2 OUTLAW", new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(410), null },
                    { new Guid("2720e32e-96e3-446c-a331-9b2bfe75d9b6"), new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(395), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://github.com/moph13121/bob-k-pop-server/blob/main/images/Jewelry_boys/-bs110-bts-nesto-ring-removebg-preview.png", 15, 10, "BTS Nesto Ring", new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(395), null },
                    { new Guid("345175da-d1be-48b4-93e5-bd559957eeca"), new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(389), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://github.com/moph13121/bob-k-pop-server/blob/main/images/Jewelry_boys/-az04-ateez-leak-earring-removebg-preview.png", 10, 10, "Ateez Leak Earring", new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(389), null },
                    { new Guid("347390ce-54f8-416b-8c91-8872f42f0623"), new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(400), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://github.com/moph13121/bob-k-pop-server/blob/main/images/Jewelry_boys/-ex236-exo-new-emblem-necklace-removebg-preview.png", 11, 10, "Exo Emblem Necklace", new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(400), null },
                    { new Guid("4bd80771-b963-40de-91c4-6306fe54e26c"), new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(415), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://github.com/moph13121/bob-k-pop-server/blob/main/images/KpopMusic_boys/SEVENTEEN%20-%20FML%2010th%20Mini%20Album.png", 10, 10, "SEVENTEEN - FML 10th Mini Album", new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(415), null },
                    { new Guid("5497fb11-da6a-4ba2-b09f-0cff76b57c78"), new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(480), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://github.com/moph13121/bob-k-pop-server/blob/main/images/Lightsticks_girls/GIRLS_GENERATION_OFFICIAL_LIGHTSTICK.png", 10, 10, "Girls Generation Official Lightstick", new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(480), null },
                    { new Guid("5524939f-695e-4de0-8c11-e0a31dbdd126"), new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(401), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://github.com/moph13121/bob-k-pop-server/blob/main/images/Jewelry_girls/Blackpink_Lisa_necklace-removebg-preview.png", 10, 10, "BlackPink Lisa Necklace", new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(402), null },
                    { new Guid("716ba239-89ce-470d-ba4e-a455171d98f0"), new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(398), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://github.com/moph13121/bob-k-pop-server/blob/main/images/Jewelry_boys/-ex234-exo-transformer-ring-removebg-preview.png", 11, 10, "Exo Transformer Ring", new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(398), null },
                    { new Guid("7adf4645-d242-4cd5-9348-1d0249817e82"), new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(417), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://github.com/moph13121/bob-k-pop-server/blob/main/images/KpopMusic_girls/(G)I-DLE%20-%20I%20FEEL%206th%20Mini%20Album.png", 10, 10, "(G)I-DLE - I FEEL 6th Mini Album", new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(417), null },
                    { new Guid("855b187b-90e0-440b-af95-f201d7abf426"), new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(472), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://github.com/moph13121/bob-k-pop-server/blob/main/images/Lightsticks_girls/BLACKPINK%20OFFICIAL%20LIGHTSTICK%20VER%202%20%E2%80%93%20NEW%20MODEL.png", 10, 10, "Blackpink Official Lightstick Ver.2", new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(473), null },
                    { new Guid("9dc7ce12-5b6d-41c2-991b-adaeb9757abc"), new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(466), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://github.com/moph13121/bob-k-pop-server/blob/main/images/KpopMusic_girls/TWICE%20ALBUM%20-%20WITH%20YOU-TH.jpg", 10, 10, "Twice - With You", new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(466), null },
                    { new Guid("a4109235-5ca1-41e2-b536-dc38cb73816e"), new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(405), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://github.com/moph13121/bob-k-pop-server/blob/main/images/Jewelry_girls/blackpink_Lisa_braclet-removebg-preview.png", 10, 10, "BlackPink Lisa Bracelet", new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(405), null },
                    { new Guid("a44475aa-636c-45b1-b018-426d5d5d3a59"), new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(467), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://github.com/moph13121/bob-k-pop-server/blob/main/images/Lightsticks_boys/BTS%20Official%20Light%20Stick%20Special%20Edition.png", 10, 10, "BTS Official Light Stick Special Edition", new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(468), null },
                    { new Guid("a9a6354a-b307-4e2f-a3ff-08ac4e774dd4"), new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(477), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://github.com/moph13121/bob-k-pop-server/blob/main/images/Lightsticks_girls/LE%20SSERAFIM%20OFFICIAL%20LIGHTSTICK.png", 10, 10, "LE SSERAFIM Official Lightstick", new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(477), null },
                    { new Guid("ad6db8dc-79e3-494d-9c3e-3a57418ddbe9"), new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(479), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://github.com/moph13121/bob-k-pop-server/blob/main/images/Lightsticks_girls/RED%20VELVET%20OFFICIAL%20LIGHTSTICK.png", 10, 10, "Red Velvet Official Lightstick", new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(479), null },
                    { new Guid("b599059f-1fef-435b-8e4b-b186f58f8530"), new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(475), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://github.com/moph13121/bob-k-pop-server/blob/main/images/Lightsticks_girls/GIDLE%20OFFICIAL%20LIGHTSTICK%20VER..png", 10, 10, "(G)I-DLE.", new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(476), null },
                    { new Guid("bd6db80f-3fe0-4bcc-82c4-b936a3cfe519"), new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(462), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://github.com/moph13121/bob-k-pop-server/blob/main/images/KpopMusic_girls/LE%20SSERAFIM%20ALBUM-%20ANTIFRAGILE.png", 10, 10, "LE SSERAFIM - ANTIFRAGILE", new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(462), null },
                    { new Guid("d559032c-dc8b-4998-bf91-4c70c8bb67b4"), new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(460), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://github.com/moph13121/bob-k-pop-server/blob/main/images/KpopMusic_girls/RED_VELVET%20ALBUM.png", 10, 10, "Red Velvet - Album", new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(460), null },
                    { new Guid("d8168f2f-1fd2-4a42-9966-96dd0212108b"), new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(412), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://github.com/moph13121/bob-k-pop-server/blob/main/images/KpopMusic_boys/BTS%20JHOPE%20ALBUM%20-%20JACK%20IN%20THE%20BOX.png", 10, 10, "JHope - JACK IN THE BOX", new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(412), null },
                    { new Guid("dc5c2184-4b59-4961-a245-bf15f16aa871"), new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(464), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://github.com/moph13121/bob-k-pop-server/blob/main/images/KpopMusic_girls/BLACKPINK%20LISA%20ALBUM%20-%20LALISA.png", 10, 10, "BlackPink Lisa - LALISA", new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(464), null },
                    { new Guid("e6a11740-db8b-4f1f-bd6c-328af93aae04"), new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(414), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://github.com/moph13121/bob-k-pop-server/blob/main/images/KpopMusic_boys/Stray%20Kids%20-%20MAXIDENT.png", 10, 10, "Stray Kids - MAXIDENT", new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(414), null },
                    { new Guid("ee123577-64d1-45c6-bf8f-6142f059c928"), new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(406), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://github.com/moph13121/bob-k-pop-server/blob/main/images/Jewelry_girls/-sn10-girls-generation-smile-earring-piercing-removebg-preview.png", 10, 10, "Girls Generation Smile Earring", new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(406), null },
                    { new Guid("f6e6bb73-bd82-4c07-99f6-1fbc278e8263"), new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(408), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://github.com/moph13121/bob-k-pop-server/blob/main/images/Jewelry_girls/-sn13-girls-generation-cubic-ribbon-earrings-removebg-preview.png", 10, 10, "Girls Generation Ribbon Earring", new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(408), null },
                    { new Guid("faa81faf-2da6-4432-91dc-e7ff40804916"), new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(471), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://github.com/moph13121/bob-k-pop-server/blob/main/images/Lightsticks_boys/ATEEZ%20OFFICIAL%20LIGHTSTICK%20VER%202%20.png", 10, 10, "Ateez Official Light Ver.2", new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(471), null }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "id", "created_at", "product_id", "rating_value", "review", "updated_at", "user_id" },
                values: new object[,]
                {
                    { new Guid("251b15e5-9976-4f45-be29-b4ddde1e13a4"), new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(637), new Guid("347390ce-54f8-416b-8c91-8872f42f0623"), 5, "This product was straight fire blud", new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(637), new Guid("3a221282-4db5-491d-a990-0c08df2ee9e7") },
                    { new Guid("8cb0166d-61a5-463e-b51f-3d35bca7df6f"), new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(633), new Guid("716ba239-89ce-470d-ba4e-a455171d98f0"), 2, "This product was straight garbage cuh", new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(633), new Guid("3a221282-4db5-491d-a990-0c08df2ee9e7") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "AccessFailedCount", "ConcurrencyStamp", "created_at", "email", "EmailConfirmed", "first_name", "last_name", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "updated_at", "UserName" },
                values: new object[] { new Guid("3a221282-4db5-491d-a990-0c08df2ee9e7"), 0, "334cd930-a05d-4cc0-9478-fdc0a55a4bfb", new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(583), "test@test.no", false, "Test", "Test", false, null, null, null, "password", null, null, false, "e80350ea-5cc9-40b8-ac45-1e863a3ef89f", false, new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(584), null });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "id", "created_at", "updated_at", "user_id", "status" },
                values: new object[] { new Guid("3b8b397e-ac12-4c33-82a9-b830a207a079"), new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(628), new DateTime(2024, 3, 21, 9, 52, 6, 312, DateTimeKind.Utc).AddTicks(628), new Guid("3a221282-4db5-491d-a990-0c08df2ee9e7"), "Pending" });

            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { new Guid("082c44a8-5d8c-4b7d-b4aa-ef31cc202338"), new Guid("0068505e-4925-4b61-9cdc-4173e8946e9e") },
                    { new Guid("713af980-25c7-4527-b563-d20941644593"), new Guid("0068505e-4925-4b61-9cdc-4173e8946e9e") },
                    { new Guid("79ffc79c-1203-45d7-a60d-522116a07589"), new Guid("0068505e-4925-4b61-9cdc-4173e8946e9e") },
                    { new Guid("082c44a8-5d8c-4b7d-b4aa-ef31cc202338"), new Guid("1328f1e4-0b59-4fe0-847a-3a151e5bdcfb") },
                    { new Guid("c0a87bf6-0057-48c8-a0a3-5a1548e7e827"), new Guid("1328f1e4-0b59-4fe0-847a-3a151e5bdcfb") },
                    { new Guid("cb2b831f-9fd1-43d8-867b-f03067414658"), new Guid("1328f1e4-0b59-4fe0-847a-3a151e5bdcfb") },
                    { new Guid("082c44a8-5d8c-4b7d-b4aa-ef31cc202338"), new Guid("1d7d0e0a-a2fa-460d-b15f-9d9d92fe4b83") },
                    { new Guid("651ec71d-6595-4da6-9208-9ee50c3db5d3"), new Guid("1d7d0e0a-a2fa-460d-b15f-9d9d92fe4b83") },
                    { new Guid("713af980-25c7-4527-b563-d20941644593"), new Guid("1d7d0e0a-a2fa-460d-b15f-9d9d92fe4b83") },
                    { new Guid("082c44a8-5d8c-4b7d-b4aa-ef31cc202338"), new Guid("22b43960-2b8d-4d5e-a20c-0817cf26ceae") },
                    { new Guid("651ec71d-6595-4da6-9208-9ee50c3db5d3"), new Guid("22b43960-2b8d-4d5e-a20c-0817cf26ceae") },
                    { new Guid("a1190251-f42d-4e04-849e-7e8c743ceabf"), new Guid("22b43960-2b8d-4d5e-a20c-0817cf26ceae") },
                    { new Guid("082c44a8-5d8c-4b7d-b4aa-ef31cc202338"), new Guid("2720e32e-96e3-446c-a331-9b2bfe75d9b6") },
                    { new Guid("713af980-25c7-4527-b563-d20941644593"), new Guid("2720e32e-96e3-446c-a331-9b2bfe75d9b6") },
                    { new Guid("79ffc79c-1203-45d7-a60d-522116a07589"), new Guid("2720e32e-96e3-446c-a331-9b2bfe75d9b6") },
                    { new Guid("082c44a8-5d8c-4b7d-b4aa-ef31cc202338"), new Guid("345175da-d1be-48b4-93e5-bd559957eeca") },
                    { new Guid("651ec71d-6595-4da6-9208-9ee50c3db5d3"), new Guid("345175da-d1be-48b4-93e5-bd559957eeca") },
                    { new Guid("713af980-25c7-4527-b563-d20941644593"), new Guid("345175da-d1be-48b4-93e5-bd559957eeca") },
                    { new Guid("082c44a8-5d8c-4b7d-b4aa-ef31cc202338"), new Guid("347390ce-54f8-416b-8c91-8872f42f0623") },
                    { new Guid("713af980-25c7-4527-b563-d20941644593"), new Guid("347390ce-54f8-416b-8c91-8872f42f0623") },
                    { new Guid("f4ccb7fe-4090-4e30-8ade-1a3be7c8c266"), new Guid("347390ce-54f8-416b-8c91-8872f42f0623") },
                    { new Guid("082c44a8-5d8c-4b7d-b4aa-ef31cc202338"), new Guid("4bd80771-b963-40de-91c4-6306fe54e26c") },
                    { new Guid("7fc4d300-3c0a-4a94-ac2d-2c1572270799"), new Guid("4bd80771-b963-40de-91c4-6306fe54e26c") },
                    { new Guid("a1190251-f42d-4e04-849e-7e8c743ceabf"), new Guid("4bd80771-b963-40de-91c4-6306fe54e26c") },
                    { new Guid("783a12af-a925-456a-82b1-8a6d999998dc"), new Guid("5497fb11-da6a-4ba2-b09f-0cff76b57c78") },
                    { new Guid("c468a87b-5cbc-4d7a-bce1-ac38424a6b1b"), new Guid("5497fb11-da6a-4ba2-b09f-0cff76b57c78") },
                    { new Guid("cb2b831f-9fd1-43d8-867b-f03067414658"), new Guid("5497fb11-da6a-4ba2-b09f-0cff76b57c78") },
                    { new Guid("35db38c3-8949-4c43-bf66-2379c5f40d12"), new Guid("5524939f-695e-4de0-8c11-e0a31dbdd126") },
                    { new Guid("713af980-25c7-4527-b563-d20941644593"), new Guid("5524939f-695e-4de0-8c11-e0a31dbdd126") },
                    { new Guid("c468a87b-5cbc-4d7a-bce1-ac38424a6b1b"), new Guid("5524939f-695e-4de0-8c11-e0a31dbdd126") },
                    { new Guid("082c44a8-5d8c-4b7d-b4aa-ef31cc202338"), new Guid("716ba239-89ce-470d-ba4e-a455171d98f0") },
                    { new Guid("713af980-25c7-4527-b563-d20941644593"), new Guid("716ba239-89ce-470d-ba4e-a455171d98f0") },
                    { new Guid("f4ccb7fe-4090-4e30-8ade-1a3be7c8c266"), new Guid("716ba239-89ce-470d-ba4e-a455171d98f0") },
                    { new Guid("a1190251-f42d-4e04-849e-7e8c743ceabf"), new Guid("7adf4645-d242-4cd5-9348-1d0249817e82") },
                    { new Guid("c2999434-3a40-4773-9874-3480b407b468"), new Guid("7adf4645-d242-4cd5-9348-1d0249817e82") },
                    { new Guid("c468a87b-5cbc-4d7a-bce1-ac38424a6b1b"), new Guid("7adf4645-d242-4cd5-9348-1d0249817e82") },
                    { new Guid("35db38c3-8949-4c43-bf66-2379c5f40d12"), new Guid("855b187b-90e0-440b-af95-f201d7abf426") },
                    { new Guid("c468a87b-5cbc-4d7a-bce1-ac38424a6b1b"), new Guid("855b187b-90e0-440b-af95-f201d7abf426") },
                    { new Guid("cb2b831f-9fd1-43d8-867b-f03067414658"), new Guid("855b187b-90e0-440b-af95-f201d7abf426") },
                    { new Guid("a1190251-f42d-4e04-849e-7e8c743ceabf"), new Guid("9dc7ce12-5b6d-41c2-991b-adaeb9757abc") },
                    { new Guid("b064dda5-3ae4-43f4-a265-604ee6b8bda6"), new Guid("9dc7ce12-5b6d-41c2-991b-adaeb9757abc") },
                    { new Guid("c468a87b-5cbc-4d7a-bce1-ac38424a6b1b"), new Guid("9dc7ce12-5b6d-41c2-991b-adaeb9757abc") },
                    { new Guid("35db38c3-8949-4c43-bf66-2379c5f40d12"), new Guid("a4109235-5ca1-41e2-b536-dc38cb73816e") },
                    { new Guid("713af980-25c7-4527-b563-d20941644593"), new Guid("a4109235-5ca1-41e2-b536-dc38cb73816e") },
                    { new Guid("c468a87b-5cbc-4d7a-bce1-ac38424a6b1b"), new Guid("a4109235-5ca1-41e2-b536-dc38cb73816e") },
                    { new Guid("082c44a8-5d8c-4b7d-b4aa-ef31cc202338"), new Guid("a44475aa-636c-45b1-b018-426d5d5d3a59") },
                    { new Guid("79ffc79c-1203-45d7-a60d-522116a07589"), new Guid("a44475aa-636c-45b1-b018-426d5d5d3a59") },
                    { new Guid("cb2b831f-9fd1-43d8-867b-f03067414658"), new Guid("a44475aa-636c-45b1-b018-426d5d5d3a59") },
                    { new Guid("c468a87b-5cbc-4d7a-bce1-ac38424a6b1b"), new Guid("a9a6354a-b307-4e2f-a3ff-08ac4e774dd4") },
                    { new Guid("cb2b831f-9fd1-43d8-867b-f03067414658"), new Guid("a9a6354a-b307-4e2f-a3ff-08ac4e774dd4") },
                    { new Guid("fb06df6e-5c03-40a0-a393-36046864dd38"), new Guid("a9a6354a-b307-4e2f-a3ff-08ac4e774dd4") },
                    { new Guid("71b337d1-044b-4e1d-a006-c1ac44b390fd"), new Guid("ad6db8dc-79e3-494d-9c3e-3a57418ddbe9") },
                    { new Guid("c468a87b-5cbc-4d7a-bce1-ac38424a6b1b"), new Guid("ad6db8dc-79e3-494d-9c3e-3a57418ddbe9") },
                    { new Guid("cb2b831f-9fd1-43d8-867b-f03067414658"), new Guid("ad6db8dc-79e3-494d-9c3e-3a57418ddbe9") },
                    { new Guid("c2999434-3a40-4773-9874-3480b407b468"), new Guid("b599059f-1fef-435b-8e4b-b186f58f8530") },
                    { new Guid("c468a87b-5cbc-4d7a-bce1-ac38424a6b1b"), new Guid("b599059f-1fef-435b-8e4b-b186f58f8530") },
                    { new Guid("cb2b831f-9fd1-43d8-867b-f03067414658"), new Guid("b599059f-1fef-435b-8e4b-b186f58f8530") },
                    { new Guid("a1190251-f42d-4e04-849e-7e8c743ceabf"), new Guid("bd6db80f-3fe0-4bcc-82c4-b936a3cfe519") },
                    { new Guid("c468a87b-5cbc-4d7a-bce1-ac38424a6b1b"), new Guid("bd6db80f-3fe0-4bcc-82c4-b936a3cfe519") },
                    { new Guid("fb06df6e-5c03-40a0-a393-36046864dd38"), new Guid("bd6db80f-3fe0-4bcc-82c4-b936a3cfe519") },
                    { new Guid("71b337d1-044b-4e1d-a006-c1ac44b390fd"), new Guid("d559032c-dc8b-4998-bf91-4c70c8bb67b4") },
                    { new Guid("a1190251-f42d-4e04-849e-7e8c743ceabf"), new Guid("d559032c-dc8b-4998-bf91-4c70c8bb67b4") },
                    { new Guid("c468a87b-5cbc-4d7a-bce1-ac38424a6b1b"), new Guid("d559032c-dc8b-4998-bf91-4c70c8bb67b4") },
                    { new Guid("082c44a8-5d8c-4b7d-b4aa-ef31cc202338"), new Guid("d8168f2f-1fd2-4a42-9966-96dd0212108b") },
                    { new Guid("79ffc79c-1203-45d7-a60d-522116a07589"), new Guid("d8168f2f-1fd2-4a42-9966-96dd0212108b") },
                    { new Guid("a1190251-f42d-4e04-849e-7e8c743ceabf"), new Guid("d8168f2f-1fd2-4a42-9966-96dd0212108b") },
                    { new Guid("35db38c3-8949-4c43-bf66-2379c5f40d12"), new Guid("dc5c2184-4b59-4961-a245-bf15f16aa871") },
                    { new Guid("a1190251-f42d-4e04-849e-7e8c743ceabf"), new Guid("dc5c2184-4b59-4961-a245-bf15f16aa871") },
                    { new Guid("c468a87b-5cbc-4d7a-bce1-ac38424a6b1b"), new Guid("dc5c2184-4b59-4961-a245-bf15f16aa871") },
                    { new Guid("082c44a8-5d8c-4b7d-b4aa-ef31cc202338"), new Guid("e6a11740-db8b-4f1f-bd6c-328af93aae04") },
                    { new Guid("8d7b666b-d420-49fc-921e-507fb60f0c56"), new Guid("e6a11740-db8b-4f1f-bd6c-328af93aae04") },
                    { new Guid("a1190251-f42d-4e04-849e-7e8c743ceabf"), new Guid("e6a11740-db8b-4f1f-bd6c-328af93aae04") },
                    { new Guid("713af980-25c7-4527-b563-d20941644593"), new Guid("ee123577-64d1-45c6-bf8f-6142f059c928") },
                    { new Guid("783a12af-a925-456a-82b1-8a6d999998dc"), new Guid("ee123577-64d1-45c6-bf8f-6142f059c928") },
                    { new Guid("c468a87b-5cbc-4d7a-bce1-ac38424a6b1b"), new Guid("ee123577-64d1-45c6-bf8f-6142f059c928") },
                    { new Guid("713af980-25c7-4527-b563-d20941644593"), new Guid("f6e6bb73-bd82-4c07-99f6-1fbc278e8263") },
                    { new Guid("783a12af-a925-456a-82b1-8a6d999998dc"), new Guid("f6e6bb73-bd82-4c07-99f6-1fbc278e8263") },
                    { new Guid("c468a87b-5cbc-4d7a-bce1-ac38424a6b1b"), new Guid("f6e6bb73-bd82-4c07-99f6-1fbc278e8263") },
                    { new Guid("082c44a8-5d8c-4b7d-b4aa-ef31cc202338"), new Guid("faa81faf-2da6-4432-91dc-e7ff40804916") },
                    { new Guid("651ec71d-6595-4da6-9208-9ee50c3db5d3"), new Guid("faa81faf-2da6-4432-91dc-e7ff40804916") },
                    { new Guid("cb2b831f-9fd1-43d8-867b-f03067414658"), new Guid("faa81faf-2da6-4432-91dc-e7ff40804916") }
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
                name: "IX_ProductCategory_CategoryId",
                table: "ProductCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrders_product_id",
                table: "ProductOrders",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_user_id",
                table: "Wishlist",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropTable(
                name: "ProductOrders");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Wishlist");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
