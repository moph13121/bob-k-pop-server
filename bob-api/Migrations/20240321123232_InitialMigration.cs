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
                    { new Guid("004e3454-0396-4400-af7b-eebf84c7ced6"), new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7482), "Girl", new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7482) },
                    { new Guid("05e6208b-0ffa-4ed5-9ad9-082b83670d68"), new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7485), "BigBang", new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7486) },
                    { new Guid("13ead0ac-aefb-42ec-87e0-f10d497edf58"), new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7489), "Red Velvet", new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7489) },
                    { new Guid("1cd6a495-e77c-48d2-b613-c20016cb0a55"), new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7490), "LE SSERAFIM.", new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7490) },
                    { new Guid("24a4b675-0ce9-48ac-a474-601e68bfefe3"), new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7501), "Merch", new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7501) },
                    { new Guid("3a622da7-f854-47e1-a80f-15afc419e925"), new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7499), "LightStick", new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7499) },
                    { new Guid("4478bd2e-4c1e-4b36-a9fb-cec34a274a9d"), new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7452), "Boy", new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7453) },
                    { new Guid("534128af-7a8f-40df-9580-102afdf11196"), new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7495), "EXO", new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7496) },
                    { new Guid("5707502c-c186-4f86-a891-c92ed97db82a"), new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7487), "Ateez", new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7487) },
                    { new Guid("698b502f-c255-4929-8be8-ce7045db418f"), new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7500), "Jewelry", new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7500) },
                    { new Guid("77ffaeb9-d322-42e5-b041-bbdfdb8c93c7"), new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7494), "Girls Generation", new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7494) },
                    { new Guid("9d698a70-4209-40a5-8064-93e005d60ede"), new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7503), "Music", new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7503) },
                    { new Guid("a87a41fb-9903-4900-938c-2d54ff9352da"), new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7496), "Twice", new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7497) },
                    { new Guid("a9a7bdd5-3c4b-4add-87dc-4e3e5b03b0d0"), new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7497), "Seventeen", new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7498) },
                    { new Guid("c8f4a413-bd0e-42e4-a775-fddf305e22f5"), new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7483), "BTS", new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7483) },
                    { new Guid("e204340b-de50-4cdd-b25e-1729e9c9d3d7"), new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7484), "StrayKids", new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7484) },
                    { new Guid("f6d7f069-e98c-4ae8-8527-541d7276ca88"), new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7488), "Blackpink", new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7488) },
                    { new Guid("fb41bb3d-4f49-4c2e-b5f2-b160121cfc90"), new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7493), "(G)I-DLE.", new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7493) }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "id", "created_at", "description", "image", "price", "stock", "title", "updated_at", "WishlistId" },
                values: new object[,]
                {
                    { new Guid("09b90a7e-3bb9-40ed-a0e6-28274f39cfb2"), new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7548), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/Lightsticks_boys/ATEEZ%20OFFICIAL%20LIGHTSTICK%20VER%202%20.png", 10, 10, "Ateez Official Light Ver.2", new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7548), null },
                    { new Guid("0aa0ee11-c7ad-4883-93a8-39a362e6b378"), new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7544), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/KpopMusic_girls/TWICE%20ALBUM%20-%20WITH%20YOU-TH.jpg", 10, 10, "Twice - With You", new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7544), null },
                    { new Guid("1ac2a2bf-3642-4e37-8a46-6a0512c6bcff"), new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7545), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/Lightsticks_boys/BTS%20Official%20Light%20Stick%20Special%20Edition.png", 10, 10, "BTS Official Light Stick Special Edition", new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7546), null },
                    { new Guid("1bba70b6-65b3-49c5-a420-4bc6006a9c2e"), new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7519), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/Jewelry_boys/-bs114-bts-mao-earring-ear-cuff-piercing-removebg-preview.png", 11, 10, "BTS Mao Earring", new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7519), null },
                    { new Guid("23121f70-0854-4c66-8166-912d14a038b9"), new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7550), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/Lightsticks_girls/BLACKPINK%20OFFICIAL%20LIGHTSTICK%20VER%202%20%E2%80%93%20NEW%20MODEL.png", 10, 10, "Blackpink Official Lightstick Ver.2", new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7550), null },
                    { new Guid("2f8fd89e-7adb-4620-83a4-c26eb20d7733"), new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7540), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://github.com/moph13121/bob-k-pop-server/blob/main/images/KpopMusic_girls/RED_VELVET%20ALBUM.png", 10, 10, "Red Velvet - Album", new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7540), null },
                    { new Guid("3607b543-ca35-488d-a33b-b8ecf834a55f"), new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7536), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/KpopMusic_boys/SEVENTEEN%20-%20FML%2010th%20Mini%20Album.png", 10, 10, "SEVENTEEN - FML 10th Mini Album", new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7536), null },
                    { new Guid("3c6c8dd5-a9ee-43d3-b3bf-3ec09bc4e829"), new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7523), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/Jewelry_girls/Blackpink_Lisa_necklace-removebg-preview.png", 10, 10, "BlackPink Lisa Necklace", new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7523), null },
                    { new Guid("3eec0fe1-41c7-4ad5-84b8-981d8ecf8dad"), new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7515), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/Jewelry_boys/-az05-ateez-range-piercing-earring-earcuff-removebg-preview.png", 10, 10, "Ateez Earcuff", new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7515), null },
                    { new Guid("45da42d4-4358-4017-9c0f-5e40cb25af23"), new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7537), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/KpopMusic_girls/(G)I-DLE%20-%20I%20FEEL%206th%20Mini%20Album.png", 10, 10, "(G)I-DLE - I FEEL 6th Mini Album", new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7537), null },
                    { new Guid("5d8a724f-8c39-452b-bd16-d999c98ab7bb"), new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7552), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://github.com/moph13121/bob-k-pop-server/blob/main/images/Lightsticks_girls/GIDLE%20OFFICIAL%20LIGHTSTICK%20VER..png", 10, 10, "(G)I-DLE.", new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7553), null },
                    { new Guid("622d2a0b-ca1b-4501-8922-7e4cec000d14"), new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7556), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/Lightsticks_girls/GIRLS_GENERATION_OFFICIAL_LIGHTSTICK.png", 10, 10, "Girls Generation Official Lightstick", new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7557), null },
                    { new Guid("6bb12109-c97c-42d5-9302-d5c046cedf09"), new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7528), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/Jewelry_girls/-sn10-girls-generation-smile-earring-piercing-removebg-preview.png", 10, 10, "Girls Generation Smile Earring", new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7528), null },
                    { new Guid("6f1a4a15-00b7-4ae4-a5d6-4be48183ce82"), new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7517), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/Jewelry_boys/-bs110-bts-nesto-ring-removebg-preview.png", 15, 10, "BTS Nesto Ring", new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7517), null },
                    { new Guid("727c0392-49ea-4ed9-b052-2e09b8c91303"), new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7541), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/KpopMusic_girls/RED_VELVET%20ALBUM.png", 10, 10, "LE SSERAFIM - ANTIFRAGILE", new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7541), null },
                    { new Guid("80f2dcf0-34fb-4d03-92b1-68829064bc9e"), new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7530), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/KpopMusic_boys/ATEEZ%20-%20THE%20WORLD%20EP%202%20%20OUTLAW.png", 10, 10, "Ateez - The World EP 2 OUTLAW", new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7531), null },
                    { new Guid("94682e19-fba2-419c-9982-039d61e9c6a8"), new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7533), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/KpopMusic_boys/Stray%20Kids%20-%20MAXIDENT.png", 10, 10, "Stray Kids - MAXIDENT", new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7534), null },
                    { new Guid("a27ab940-43af-4722-866b-fe2cb7b2f5a4"), new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7555), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/Lightsticks_girls/RED%20VELVET%20OFFICIAL%20LIGHTSTICK.png", 10, 10, "Red Velvet Official Lightstick", new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7555), null },
                    { new Guid("ab95dcbf-0428-417f-ac4e-8b9604000d56"), new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7529), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/Jewelry_girls/-sn13-girls-generation-cubic-ribbon-earrings-removebg-preview.png   ", 10, 10, "Girls Generation Ribbon Earring", new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7529), null },
                    { new Guid("afd5ca99-949b-42dd-9232-b749e0bc9d88"), new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7554), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/Lightsticks_girls/GIDLE%20OFFICIAL%20LIGHTSTICK%20VER..png", 10, 10, "LE SSERAFIM Official Lightstick", new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7554), null },
                    { new Guid("c2db1196-6021-4bdb-aa22-dd3909bf3f33"), new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7522), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/Jewelry_boys/-ex236-exo-new-emblem-necklace-removebg-preview.png", 11, 10, "Exo Emblem Necklace", new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7522), null },
                    { new Guid("c515ea48-187e-4a80-af4d-6f835c8a531d"), new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7520), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/Jewelry_boys/-ex234-exo-transformer-ring-removebg-preview.png", 11, 10, "Exo Transformer Ring", new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7520), null },
                    { new Guid("c96640a7-9aff-4e6a-875a-a8085554368d"), new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7526), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/Jewelry_girls/blackpink_Lisa_braclet-removebg-preview.png", 10, 10, "BlackPink Lisa Bracelet", new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7526), null },
                    { new Guid("d34afa39-7633-4916-8913-02e5ca9342eb"), new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7547), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/Lightsticks_boys/BIGBANG%20OFFICIAL%20LIGHT%20STICK%20VER%204.png", 10, 10, "BigBang Official Light Stick ", new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7547), null },
                    { new Guid("db62b370-b1bd-47c6-9b5b-07ef3c8698d8"), new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7543), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/KpopMusic_girls/BLACKPINK%20LISA%20ALBUM%20-%20LALISA.png", 10, 10, "BlackPink Lisa - LALISA", new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7543), null },
                    { new Guid("f2d059b9-c2bc-4836-8d19-8d50112aca14"), new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7512), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://github.com/moph13121/bob-k-pop-server/blob/main/images/Jewelry_boys/-az04-ateez-leak-earring-removebg-preview.png", 10, 10, "Ateez Leak Earring", new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7512), null },
                    { new Guid("f9eb4ef3-2d07-4f6b-babf-2caacf84b9da"), new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7532), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/KpopMusic_boys/BTS%20JHOPE%20ALBUM%20-%20JACK%20IN%20THE%20BOX.png", 10, 10, "JHope - JACK IN THE BOX", new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7532), null }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "id", "created_at", "product_id", "rating_value", "review", "updated_at", "user_id" },
                values: new object[,]
                {
                    { new Guid("5525c3a7-e1a4-4ef6-9ffb-ac93d5526030"), new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7683), new Guid("c515ea48-187e-4a80-af4d-6f835c8a531d"), 2, "This product was straight garbage cuh", new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7683), new Guid("cba31aa2-9b5e-4792-b9eb-dbca58edbdcc") },
                    { new Guid("63ebf039-26b5-444e-bb28-1c1e23bccb75"), new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7686), new Guid("c2db1196-6021-4bdb-aa22-dd3909bf3f33"), 5, "This product was straight fire blud", new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7686), new Guid("cba31aa2-9b5e-4792-b9eb-dbca58edbdcc") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "AccessFailedCount", "ConcurrencyStamp", "created_at", "email", "EmailConfirmed", "first_name", "last_name", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "updated_at", "UserName" },
                values: new object[] { new Guid("cba31aa2-9b5e-4792-b9eb-dbca58edbdcc"), 0, "bd86a37f-e940-4468-9803-6268a58bfb45", new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7643), "test@test.no", false, "Test", "Test", false, null, null, null, "password", null, null, false, "3647f050-4c51-46f5-992b-03babf7c6494", false, new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7644), null });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "id", "created_at", "updated_at", "user_id", "status" },
                values: new object[] { new Guid("99c9725b-aa33-4c5b-bebd-c47c67e94890"), new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7679), new DateTime(2024, 3, 21, 12, 32, 18, 353, DateTimeKind.Utc).AddTicks(7679), new Guid("cba31aa2-9b5e-4792-b9eb-dbca58edbdcc"), "Pending" });

            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { new Guid("3a622da7-f854-47e1-a80f-15afc419e925"), new Guid("09b90a7e-3bb9-40ed-a0e6-28274f39cfb2") },
                    { new Guid("4478bd2e-4c1e-4b36-a9fb-cec34a274a9d"), new Guid("09b90a7e-3bb9-40ed-a0e6-28274f39cfb2") },
                    { new Guid("5707502c-c186-4f86-a891-c92ed97db82a"), new Guid("09b90a7e-3bb9-40ed-a0e6-28274f39cfb2") },
                    { new Guid("004e3454-0396-4400-af7b-eebf84c7ced6"), new Guid("0aa0ee11-c7ad-4883-93a8-39a362e6b378") },
                    { new Guid("9d698a70-4209-40a5-8064-93e005d60ede"), new Guid("0aa0ee11-c7ad-4883-93a8-39a362e6b378") },
                    { new Guid("a87a41fb-9903-4900-938c-2d54ff9352da"), new Guid("0aa0ee11-c7ad-4883-93a8-39a362e6b378") },
                    { new Guid("3a622da7-f854-47e1-a80f-15afc419e925"), new Guid("1ac2a2bf-3642-4e37-8a46-6a0512c6bcff") },
                    { new Guid("4478bd2e-4c1e-4b36-a9fb-cec34a274a9d"), new Guid("1ac2a2bf-3642-4e37-8a46-6a0512c6bcff") },
                    { new Guid("c8f4a413-bd0e-42e4-a775-fddf305e22f5"), new Guid("1ac2a2bf-3642-4e37-8a46-6a0512c6bcff") },
                    { new Guid("4478bd2e-4c1e-4b36-a9fb-cec34a274a9d"), new Guid("1bba70b6-65b3-49c5-a420-4bc6006a9c2e") },
                    { new Guid("698b502f-c255-4929-8be8-ce7045db418f"), new Guid("1bba70b6-65b3-49c5-a420-4bc6006a9c2e") },
                    { new Guid("c8f4a413-bd0e-42e4-a775-fddf305e22f5"), new Guid("1bba70b6-65b3-49c5-a420-4bc6006a9c2e") },
                    { new Guid("004e3454-0396-4400-af7b-eebf84c7ced6"), new Guid("23121f70-0854-4c66-8166-912d14a038b9") },
                    { new Guid("3a622da7-f854-47e1-a80f-15afc419e925"), new Guid("23121f70-0854-4c66-8166-912d14a038b9") },
                    { new Guid("f6d7f069-e98c-4ae8-8527-541d7276ca88"), new Guid("23121f70-0854-4c66-8166-912d14a038b9") },
                    { new Guid("004e3454-0396-4400-af7b-eebf84c7ced6"), new Guid("2f8fd89e-7adb-4620-83a4-c26eb20d7733") },
                    { new Guid("13ead0ac-aefb-42ec-87e0-f10d497edf58"), new Guid("2f8fd89e-7adb-4620-83a4-c26eb20d7733") },
                    { new Guid("9d698a70-4209-40a5-8064-93e005d60ede"), new Guid("2f8fd89e-7adb-4620-83a4-c26eb20d7733") },
                    { new Guid("4478bd2e-4c1e-4b36-a9fb-cec34a274a9d"), new Guid("3607b543-ca35-488d-a33b-b8ecf834a55f") },
                    { new Guid("9d698a70-4209-40a5-8064-93e005d60ede"), new Guid("3607b543-ca35-488d-a33b-b8ecf834a55f") },
                    { new Guid("a9a7bdd5-3c4b-4add-87dc-4e3e5b03b0d0"), new Guid("3607b543-ca35-488d-a33b-b8ecf834a55f") },
                    { new Guid("004e3454-0396-4400-af7b-eebf84c7ced6"), new Guid("3c6c8dd5-a9ee-43d3-b3bf-3ec09bc4e829") },
                    { new Guid("698b502f-c255-4929-8be8-ce7045db418f"), new Guid("3c6c8dd5-a9ee-43d3-b3bf-3ec09bc4e829") },
                    { new Guid("f6d7f069-e98c-4ae8-8527-541d7276ca88"), new Guid("3c6c8dd5-a9ee-43d3-b3bf-3ec09bc4e829") },
                    { new Guid("4478bd2e-4c1e-4b36-a9fb-cec34a274a9d"), new Guid("3eec0fe1-41c7-4ad5-84b8-981d8ecf8dad") },
                    { new Guid("5707502c-c186-4f86-a891-c92ed97db82a"), new Guid("3eec0fe1-41c7-4ad5-84b8-981d8ecf8dad") },
                    { new Guid("698b502f-c255-4929-8be8-ce7045db418f"), new Guid("3eec0fe1-41c7-4ad5-84b8-981d8ecf8dad") },
                    { new Guid("004e3454-0396-4400-af7b-eebf84c7ced6"), new Guid("45da42d4-4358-4017-9c0f-5e40cb25af23") },
                    { new Guid("9d698a70-4209-40a5-8064-93e005d60ede"), new Guid("45da42d4-4358-4017-9c0f-5e40cb25af23") },
                    { new Guid("fb41bb3d-4f49-4c2e-b5f2-b160121cfc90"), new Guid("45da42d4-4358-4017-9c0f-5e40cb25af23") },
                    { new Guid("004e3454-0396-4400-af7b-eebf84c7ced6"), new Guid("5d8a724f-8c39-452b-bd16-d999c98ab7bb") },
                    { new Guid("3a622da7-f854-47e1-a80f-15afc419e925"), new Guid("5d8a724f-8c39-452b-bd16-d999c98ab7bb") },
                    { new Guid("fb41bb3d-4f49-4c2e-b5f2-b160121cfc90"), new Guid("5d8a724f-8c39-452b-bd16-d999c98ab7bb") },
                    { new Guid("004e3454-0396-4400-af7b-eebf84c7ced6"), new Guid("622d2a0b-ca1b-4501-8922-7e4cec000d14") },
                    { new Guid("3a622da7-f854-47e1-a80f-15afc419e925"), new Guid("622d2a0b-ca1b-4501-8922-7e4cec000d14") },
                    { new Guid("77ffaeb9-d322-42e5-b041-bbdfdb8c93c7"), new Guid("622d2a0b-ca1b-4501-8922-7e4cec000d14") },
                    { new Guid("004e3454-0396-4400-af7b-eebf84c7ced6"), new Guid("6bb12109-c97c-42d5-9302-d5c046cedf09") },
                    { new Guid("698b502f-c255-4929-8be8-ce7045db418f"), new Guid("6bb12109-c97c-42d5-9302-d5c046cedf09") },
                    { new Guid("77ffaeb9-d322-42e5-b041-bbdfdb8c93c7"), new Guid("6bb12109-c97c-42d5-9302-d5c046cedf09") },
                    { new Guid("4478bd2e-4c1e-4b36-a9fb-cec34a274a9d"), new Guid("6f1a4a15-00b7-4ae4-a5d6-4be48183ce82") },
                    { new Guid("698b502f-c255-4929-8be8-ce7045db418f"), new Guid("6f1a4a15-00b7-4ae4-a5d6-4be48183ce82") },
                    { new Guid("c8f4a413-bd0e-42e4-a775-fddf305e22f5"), new Guid("6f1a4a15-00b7-4ae4-a5d6-4be48183ce82") },
                    { new Guid("004e3454-0396-4400-af7b-eebf84c7ced6"), new Guid("727c0392-49ea-4ed9-b052-2e09b8c91303") },
                    { new Guid("1cd6a495-e77c-48d2-b613-c20016cb0a55"), new Guid("727c0392-49ea-4ed9-b052-2e09b8c91303") },
                    { new Guid("9d698a70-4209-40a5-8064-93e005d60ede"), new Guid("727c0392-49ea-4ed9-b052-2e09b8c91303") },
                    { new Guid("4478bd2e-4c1e-4b36-a9fb-cec34a274a9d"), new Guid("80f2dcf0-34fb-4d03-92b1-68829064bc9e") },
                    { new Guid("5707502c-c186-4f86-a891-c92ed97db82a"), new Guid("80f2dcf0-34fb-4d03-92b1-68829064bc9e") },
                    { new Guid("9d698a70-4209-40a5-8064-93e005d60ede"), new Guid("80f2dcf0-34fb-4d03-92b1-68829064bc9e") },
                    { new Guid("4478bd2e-4c1e-4b36-a9fb-cec34a274a9d"), new Guid("94682e19-fba2-419c-9982-039d61e9c6a8") },
                    { new Guid("9d698a70-4209-40a5-8064-93e005d60ede"), new Guid("94682e19-fba2-419c-9982-039d61e9c6a8") },
                    { new Guid("e204340b-de50-4cdd-b25e-1729e9c9d3d7"), new Guid("94682e19-fba2-419c-9982-039d61e9c6a8") },
                    { new Guid("004e3454-0396-4400-af7b-eebf84c7ced6"), new Guid("a27ab940-43af-4722-866b-fe2cb7b2f5a4") },
                    { new Guid("13ead0ac-aefb-42ec-87e0-f10d497edf58"), new Guid("a27ab940-43af-4722-866b-fe2cb7b2f5a4") },
                    { new Guid("3a622da7-f854-47e1-a80f-15afc419e925"), new Guid("a27ab940-43af-4722-866b-fe2cb7b2f5a4") },
                    { new Guid("004e3454-0396-4400-af7b-eebf84c7ced6"), new Guid("ab95dcbf-0428-417f-ac4e-8b9604000d56") },
                    { new Guid("698b502f-c255-4929-8be8-ce7045db418f"), new Guid("ab95dcbf-0428-417f-ac4e-8b9604000d56") },
                    { new Guid("77ffaeb9-d322-42e5-b041-bbdfdb8c93c7"), new Guid("ab95dcbf-0428-417f-ac4e-8b9604000d56") },
                    { new Guid("004e3454-0396-4400-af7b-eebf84c7ced6"), new Guid("afd5ca99-949b-42dd-9232-b749e0bc9d88") },
                    { new Guid("1cd6a495-e77c-48d2-b613-c20016cb0a55"), new Guid("afd5ca99-949b-42dd-9232-b749e0bc9d88") },
                    { new Guid("3a622da7-f854-47e1-a80f-15afc419e925"), new Guid("afd5ca99-949b-42dd-9232-b749e0bc9d88") },
                    { new Guid("4478bd2e-4c1e-4b36-a9fb-cec34a274a9d"), new Guid("c2db1196-6021-4bdb-aa22-dd3909bf3f33") },
                    { new Guid("534128af-7a8f-40df-9580-102afdf11196"), new Guid("c2db1196-6021-4bdb-aa22-dd3909bf3f33") },
                    { new Guid("698b502f-c255-4929-8be8-ce7045db418f"), new Guid("c2db1196-6021-4bdb-aa22-dd3909bf3f33") },
                    { new Guid("4478bd2e-4c1e-4b36-a9fb-cec34a274a9d"), new Guid("c515ea48-187e-4a80-af4d-6f835c8a531d") },
                    { new Guid("534128af-7a8f-40df-9580-102afdf11196"), new Guid("c515ea48-187e-4a80-af4d-6f835c8a531d") },
                    { new Guid("698b502f-c255-4929-8be8-ce7045db418f"), new Guid("c515ea48-187e-4a80-af4d-6f835c8a531d") },
                    { new Guid("004e3454-0396-4400-af7b-eebf84c7ced6"), new Guid("c96640a7-9aff-4e6a-875a-a8085554368d") },
                    { new Guid("698b502f-c255-4929-8be8-ce7045db418f"), new Guid("c96640a7-9aff-4e6a-875a-a8085554368d") },
                    { new Guid("f6d7f069-e98c-4ae8-8527-541d7276ca88"), new Guid("c96640a7-9aff-4e6a-875a-a8085554368d") },
                    { new Guid("05e6208b-0ffa-4ed5-9ad9-082b83670d68"), new Guid("d34afa39-7633-4916-8913-02e5ca9342eb") },
                    { new Guid("3a622da7-f854-47e1-a80f-15afc419e925"), new Guid("d34afa39-7633-4916-8913-02e5ca9342eb") },
                    { new Guid("4478bd2e-4c1e-4b36-a9fb-cec34a274a9d"), new Guid("d34afa39-7633-4916-8913-02e5ca9342eb") },
                    { new Guid("004e3454-0396-4400-af7b-eebf84c7ced6"), new Guid("db62b370-b1bd-47c6-9b5b-07ef3c8698d8") },
                    { new Guid("9d698a70-4209-40a5-8064-93e005d60ede"), new Guid("db62b370-b1bd-47c6-9b5b-07ef3c8698d8") },
                    { new Guid("f6d7f069-e98c-4ae8-8527-541d7276ca88"), new Guid("db62b370-b1bd-47c6-9b5b-07ef3c8698d8") },
                    { new Guid("4478bd2e-4c1e-4b36-a9fb-cec34a274a9d"), new Guid("f2d059b9-c2bc-4836-8d19-8d50112aca14") },
                    { new Guid("5707502c-c186-4f86-a891-c92ed97db82a"), new Guid("f2d059b9-c2bc-4836-8d19-8d50112aca14") },
                    { new Guid("698b502f-c255-4929-8be8-ce7045db418f"), new Guid("f2d059b9-c2bc-4836-8d19-8d50112aca14") },
                    { new Guid("4478bd2e-4c1e-4b36-a9fb-cec34a274a9d"), new Guid("f9eb4ef3-2d07-4f6b-babf-2caacf84b9da") },
                    { new Guid("9d698a70-4209-40a5-8064-93e005d60ede"), new Guid("f9eb4ef3-2d07-4f6b-babf-2caacf84b9da") },
                    { new Guid("c8f4a413-bd0e-42e4-a775-fddf305e22f5"), new Guid("f9eb4ef3-2d07-4f6b-babf-2caacf84b9da") }
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
