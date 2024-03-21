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
                    { new Guid("0d300379-5971-407d-8b5b-e140b9ebaf52"), new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8168), "Boy", new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8174) },
                    { new Guid("2bfdaed4-9fb4-4601-b374-9cd554802c46"), new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8224), "LightStick", new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8224) },
                    { new Guid("55989ef9-f470-4f66-944c-9ebb372f1921"), new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8220), "EXO", new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8220) },
                    { new Guid("601c05cd-5463-45d6-9f3b-348e67a6c9e2"), new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8229), "Music", new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8229) },
                    { new Guid("894339a2-7c42-471a-a25f-c53d3c8ae70e"), new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8205), "Ateez", new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8205) },
                    { new Guid("89a3a25e-e0d0-4f06-b0ef-7f142bb6c8df"), new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8216), "LE SSERAFIM.", new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8217) },
                    { new Guid("98e1e944-0fc9-4a6e-94c4-63d43f88bc48"), new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8207), "Red Velvet", new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8208) },
                    { new Guid("9d47178a-0e90-4b3b-9d7b-f2681a720881"), new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8206), "Blackpink", new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8206) },
                    { new Guid("9f272a33-74f9-40e7-a4c8-80c47b4ca218"), new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8202), "StrayKids", new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8203) },
                    { new Guid("a82477ee-2cab-4d15-ad26-437ddf4b81c0"), new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8221), "Twice", new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8221) },
                    { new Guid("abfa3cbd-3235-4155-ae4a-4b03e9396043"), new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8218), "(G)I-DLE.", new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8218) },
                    { new Guid("be10e29f-83f8-42a5-b981-fa5cb5c8c21d"), new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8204), "BigBang", new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8204) },
                    { new Guid("c4715a2c-2f63-44ae-a399-dd8afe0f9006"), new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8201), "BTS", new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8201) },
                    { new Guid("cafbd6d4-e906-4165-8b29-7d2b8430da86"), new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8199), "Girl", new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8200) },
                    { new Guid("d82d0f6a-8542-4387-83b8-6de2545b39f6"), new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8222), "Seventeen", new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8223) },
                    { new Guid("e4e97845-79ba-416b-a6e3-9492110b952c"), new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8219), "Girls Generation", new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8219) },
                    { new Guid("e7e92204-8adf-413c-8ea5-e5cb17071af6"), new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8225), "Jewelry", new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8225) },
                    { new Guid("fdce9381-faa9-471d-964d-9e572a836729"), new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8228), "Merch", new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8228) }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "id", "created_at", "description", "image", "price", "stock", "title", "updated_at", "WishlistId" },
                values: new object[,]
                {
                    { new Guid("0fef34ac-b431-463d-9579-aa358f9d8f18"), new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8273), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/Lightsticks_boys/BTS%20Official%20Light%20Stick%20Special%20Edition.png", 10, 10, "BTS Official Light Stick Special Edition", new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8274), null },
                    { new Guid("1010ee33-0b69-4e3e-a5f2-d1250800e1e6"), new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8282), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/Lightsticks_girls/GIDLE%20OFFICIAL%20LIGHTSTICK%20VER..png", 10, 10, "LE SSERAFIM Official Lightstick", new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8282), null },
                    { new Guid("12f94ffb-0fa4-4ce4-ab89-f1ccc5513680"), new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8243), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/Jewelry_boys/-bs110-bts-nesto-ring-removebg-preview.png", 15, 10, "BTS Nesto Ring", new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8244), null },
                    { new Guid("1fb98e0d-5809-4165-a3d6-f7e7880f470e"), new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8258), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/KpopMusic_boys/ATEEZ%20-%20THE%20WORLD%20EP%202%20%20OUTLAW.png", 10, 10, "Ateez - The World EP 2 OUTLAW", new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8258), null },
                    { new Guid("22f508d0-5f48-48c3-85f8-ca824e718c67"), new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8241), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/Jewelry_boys/-az05-ateez-range-piercing-earring-earcuff-removebg-preview.png", 10, 10, "Ateez Earcuff", new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8242), null },
                    { new Guid("47986d68-88eb-43c0-b81f-647bb54eed76"), new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8284), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/Lightsticks_girls/RED%20VELVET%20OFFICIAL%20LIGHTSTICK.png", 10, 10, "Red Velvet Official Lightstick", new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8284), null },
                    { new Guid("51b7e263-2128-41cf-88e3-58e5fb754618"), new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8253), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/Jewelry_girls/blackpink_Lisa_braclet-removebg-preview.png", 10, 10, "BlackPink Lisa Bracelet", new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8253), null },
                    { new Guid("6d4d84bc-e049-4a5c-94cb-c5a8de8ae0e3"), new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8238), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/Jewelry_boys/-az04-ateez-leak-earring-removebg-preview.png", 10, 10, "Ateez Leak Earring", new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8239), null },
                    { new Guid("6e9bc93c-03c1-419f-8b93-1c36df5e63de"), new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8260), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/KpopMusic_boys/BTS%20JHOPE%20ALBUM%20-%20JACK%20IN%20THE%20BOX.png", 10, 10, "JHope - JACK IN THE BOX", new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8260), null },
                    { new Guid("6f39d485-e42b-4a1c-a164-7d0f8c0c28a2"), new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8251), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/Jewelry_girls/Blackpink_Lisa_necklace-removebg-preview.png", 10, 10, "BlackPink Lisa Necklace", new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8251), null },
                    { new Guid("74aa1717-2b0d-4fde-b09b-f5da7a21fb52"), new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8270), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/KpopMusic_girls/BLACKPINK%20LISA%20ALBUM%20-%20LALISA.png", 10, 10, "BlackPink Lisa - LALISA", new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8271), null },
                    { new Guid("75918352-7770-42bc-ac7d-8465efeccdae"), new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8261), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/KpopMusic_boys/Stray%20Kids%20-%20MAXIDENT.png", 10, 10, "Stray Kids - MAXIDENT", new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8262), null },
                    { new Guid("76e349fe-6a9d-4f60-ace6-31719c54de95"), new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8247), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/Jewelry_boys/-ex234-exo-transformer-ring-removebg-preview.png", 11, 10, "Exo Transformer Ring", new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8247), null },
                    { new Guid("78349080-2425-4609-a7d5-7c5ec9c0e6ed"), new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8272), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/KpopMusic_girls/TWICE%20ALBUM%20-%20WITH%20YOU-TH.jpg", 10, 10, "Twice - With You", new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8272), null },
                    { new Guid("7ab14ead-c679-4bcd-b2ae-cba0e604d4be"), new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8245), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/Jewelry_boys/-bs114-bts-mao-earring-ear-cuff-piercing-removebg-preview.png", 11, 10, "BTS Mao Earring", new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8245), null },
                    { new Guid("9130f1c1-4af5-4464-93bf-735b8a3ce752"), new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8276), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/Lightsticks_boys/ATEEZ%20OFFICIAL%20LIGHTSTICK%20VER%202%20.png", 10, 10, "Ateez Official Light Ver.2", new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8277), null },
                    { new Guid("9de761ab-b856-4b43-9c7c-4d032674bb00"), new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8281), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://github.com/moph13121/bob-k-pop-server/blob/main/images/Lightsticks_girls/GIDLE%20OFFICIAL%20LIGHTSTICK%20VER..png", 10, 10, "(G)I-DLE.", new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8281), null },
                    { new Guid("a124d1a6-1d79-48d1-8b53-c5f9fb88c2c4"), new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8275), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/Lightsticks_boys/BIGBANG%20OFFICIAL%20LIGHT%20STICK%20VER%204.png", 10, 10, "BigBang Official Light Stick ", new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8275), null },
                    { new Guid("ad866782-e78b-40f7-8d2b-389a4ea5f585"), new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8263), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/KpopMusic_boys/SEVENTEEN%20-%20FML%2010th%20Mini%20Album.png", 10, 10, "SEVENTEEN - FML 10th Mini Album", new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8263), null },
                    { new Guid("bc290a7d-20fd-40c9-80f2-e824f42b9bf9"), new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8285), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/Lightsticks_girls/GIRLS_GENERATION_OFFICIAL_LIGHTSTICK.png", 10, 10, "Girls Generation Official Lightstick", new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8285), null },
                    { new Guid("d11e5c9f-9e39-4113-b589-0142024e3577"), new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8279), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/Lightsticks_girls/BLACKPINK%20OFFICIAL%20LIGHTSTICK%20VER%202%20%E2%80%93%20NEW%20MODEL.png", 10, 10, "Blackpink Official Lightstick Ver.2", new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8279), null },
                    { new Guid("e9c5c606-2ba7-4bda-ba6d-a5724f0fcf80"), new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8248), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/Jewelry_boys/-ex236-exo-new-emblem-necklace-removebg-preview.png", 11, 10, "Exo Emblem Necklace", new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8249), null },
                    { new Guid("efa2f173-a8ee-4d34-8de6-e211e8f6e4eb"), new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8256), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/Jewelry_girls/-sn13-girls-generation-cubic-ribbon-earrings-removebg-preview.png   ", 10, 10, "Girls Generation Ribbon Earring", new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8256), null },
                    { new Guid("f1f21a0a-ac50-4ae7-9dcf-4d4d40a07a6f"), new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8269), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/KpopMusic_girls/RED_VELVET%20ALBUM.png", 10, 10, "LE SSERAFIM - ANTIFRAGILE", new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8269), null },
                    { new Guid("f63128f8-3953-43eb-a328-cb790e7a0f7f"), new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8254), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/Jewelry_girls/-sn10-girls-generation-smile-earring-piercing-removebg-preview.png", 10, 10, "Girls Generation Smile Earring", new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8254), null },
                    { new Guid("f889e11a-bf29-4717-a958-089f67206daa"), new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8266), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/KpopMusic_girls/(G)I-DLE%20-%20I%20FEEL%206th%20Mini%20Album.png", 10, 10, "(G)I-DLE - I FEEL 6th Mini Album", new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8266), null },
                    { new Guid("fefb067a-6010-45fe-9106-62e247a0edad"), new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8267), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://raw.githubusercontent.com/moph13121/bob-k-pop-server/main/images/KpopMusic_girls/RED_VELVET%20ALBUM.png", 10, 10, "Red Velvet - Album", new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8268), null }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "id", "created_at", "product_id", "rating_value", "review", "updated_at", "user_id" },
                values: new object[,]
                {
                    { new Guid("3d55c936-988f-4c6f-8dd9-ed10867ba893"), new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8426), new Guid("76e349fe-6a9d-4f60-ace6-31719c54de95"), 2, "This product was straight garbage cuh", new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8427), new Guid("166e87c5-370c-43b7-add4-5f52348bb7b7") },
                    { new Guid("e09cc7d1-fa78-4391-8f86-95b17db307bc"), new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8430), new Guid("e9c5c606-2ba7-4bda-ba6d-a5724f0fcf80"), 5, "This product was straight fire blud", new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8430), new Guid("166e87c5-370c-43b7-add4-5f52348bb7b7") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "AccessFailedCount", "ConcurrencyStamp", "created_at", "email", "EmailConfirmed", "first_name", "last_name", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "updated_at", "UserName" },
                values: new object[] { new Guid("166e87c5-370c-43b7-add4-5f52348bb7b7"), 0, "e44a3117-f18d-4400-9d94-dd53fc729a55", new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8383), "test@test.no", false, "Test", "Test", false, null, null, null, "password", null, null, false, "e7afd98a-181d-4ba1-8fef-4507887ca73e", false, new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8384), null });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "id", "created_at", "updated_at", "user_id", "status" },
                values: new object[] { new Guid("5053a48d-1813-4379-a6e1-3560faa2c183"), new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8422), new DateTime(2024, 3, 21, 13, 31, 15, 556, DateTimeKind.Utc).AddTicks(8422), new Guid("166e87c5-370c-43b7-add4-5f52348bb7b7"), "Pending" });

            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { new Guid("0d300379-5971-407d-8b5b-e140b9ebaf52"), new Guid("0fef34ac-b431-463d-9579-aa358f9d8f18") },
                    { new Guid("2bfdaed4-9fb4-4601-b374-9cd554802c46"), new Guid("0fef34ac-b431-463d-9579-aa358f9d8f18") },
                    { new Guid("c4715a2c-2f63-44ae-a399-dd8afe0f9006"), new Guid("0fef34ac-b431-463d-9579-aa358f9d8f18") },
                    { new Guid("2bfdaed4-9fb4-4601-b374-9cd554802c46"), new Guid("1010ee33-0b69-4e3e-a5f2-d1250800e1e6") },
                    { new Guid("89a3a25e-e0d0-4f06-b0ef-7f142bb6c8df"), new Guid("1010ee33-0b69-4e3e-a5f2-d1250800e1e6") },
                    { new Guid("cafbd6d4-e906-4165-8b29-7d2b8430da86"), new Guid("1010ee33-0b69-4e3e-a5f2-d1250800e1e6") },
                    { new Guid("0d300379-5971-407d-8b5b-e140b9ebaf52"), new Guid("12f94ffb-0fa4-4ce4-ab89-f1ccc5513680") },
                    { new Guid("c4715a2c-2f63-44ae-a399-dd8afe0f9006"), new Guid("12f94ffb-0fa4-4ce4-ab89-f1ccc5513680") },
                    { new Guid("e7e92204-8adf-413c-8ea5-e5cb17071af6"), new Guid("12f94ffb-0fa4-4ce4-ab89-f1ccc5513680") },
                    { new Guid("0d300379-5971-407d-8b5b-e140b9ebaf52"), new Guid("1fb98e0d-5809-4165-a3d6-f7e7880f470e") },
                    { new Guid("601c05cd-5463-45d6-9f3b-348e67a6c9e2"), new Guid("1fb98e0d-5809-4165-a3d6-f7e7880f470e") },
                    { new Guid("894339a2-7c42-471a-a25f-c53d3c8ae70e"), new Guid("1fb98e0d-5809-4165-a3d6-f7e7880f470e") },
                    { new Guid("0d300379-5971-407d-8b5b-e140b9ebaf52"), new Guid("22f508d0-5f48-48c3-85f8-ca824e718c67") },
                    { new Guid("894339a2-7c42-471a-a25f-c53d3c8ae70e"), new Guid("22f508d0-5f48-48c3-85f8-ca824e718c67") },
                    { new Guid("e7e92204-8adf-413c-8ea5-e5cb17071af6"), new Guid("22f508d0-5f48-48c3-85f8-ca824e718c67") },
                    { new Guid("2bfdaed4-9fb4-4601-b374-9cd554802c46"), new Guid("47986d68-88eb-43c0-b81f-647bb54eed76") },
                    { new Guid("98e1e944-0fc9-4a6e-94c4-63d43f88bc48"), new Guid("47986d68-88eb-43c0-b81f-647bb54eed76") },
                    { new Guid("cafbd6d4-e906-4165-8b29-7d2b8430da86"), new Guid("47986d68-88eb-43c0-b81f-647bb54eed76") },
                    { new Guid("9d47178a-0e90-4b3b-9d7b-f2681a720881"), new Guid("51b7e263-2128-41cf-88e3-58e5fb754618") },
                    { new Guid("cafbd6d4-e906-4165-8b29-7d2b8430da86"), new Guid("51b7e263-2128-41cf-88e3-58e5fb754618") },
                    { new Guid("e7e92204-8adf-413c-8ea5-e5cb17071af6"), new Guid("51b7e263-2128-41cf-88e3-58e5fb754618") },
                    { new Guid("0d300379-5971-407d-8b5b-e140b9ebaf52"), new Guid("6d4d84bc-e049-4a5c-94cb-c5a8de8ae0e3") },
                    { new Guid("894339a2-7c42-471a-a25f-c53d3c8ae70e"), new Guid("6d4d84bc-e049-4a5c-94cb-c5a8de8ae0e3") },
                    { new Guid("e7e92204-8adf-413c-8ea5-e5cb17071af6"), new Guid("6d4d84bc-e049-4a5c-94cb-c5a8de8ae0e3") },
                    { new Guid("0d300379-5971-407d-8b5b-e140b9ebaf52"), new Guid("6e9bc93c-03c1-419f-8b93-1c36df5e63de") },
                    { new Guid("601c05cd-5463-45d6-9f3b-348e67a6c9e2"), new Guid("6e9bc93c-03c1-419f-8b93-1c36df5e63de") },
                    { new Guid("c4715a2c-2f63-44ae-a399-dd8afe0f9006"), new Guid("6e9bc93c-03c1-419f-8b93-1c36df5e63de") },
                    { new Guid("9d47178a-0e90-4b3b-9d7b-f2681a720881"), new Guid("6f39d485-e42b-4a1c-a164-7d0f8c0c28a2") },
                    { new Guid("cafbd6d4-e906-4165-8b29-7d2b8430da86"), new Guid("6f39d485-e42b-4a1c-a164-7d0f8c0c28a2") },
                    { new Guid("e7e92204-8adf-413c-8ea5-e5cb17071af6"), new Guid("6f39d485-e42b-4a1c-a164-7d0f8c0c28a2") },
                    { new Guid("601c05cd-5463-45d6-9f3b-348e67a6c9e2"), new Guid("74aa1717-2b0d-4fde-b09b-f5da7a21fb52") },
                    { new Guid("9d47178a-0e90-4b3b-9d7b-f2681a720881"), new Guid("74aa1717-2b0d-4fde-b09b-f5da7a21fb52") },
                    { new Guid("cafbd6d4-e906-4165-8b29-7d2b8430da86"), new Guid("74aa1717-2b0d-4fde-b09b-f5da7a21fb52") },
                    { new Guid("0d300379-5971-407d-8b5b-e140b9ebaf52"), new Guid("75918352-7770-42bc-ac7d-8465efeccdae") },
                    { new Guid("601c05cd-5463-45d6-9f3b-348e67a6c9e2"), new Guid("75918352-7770-42bc-ac7d-8465efeccdae") },
                    { new Guid("9f272a33-74f9-40e7-a4c8-80c47b4ca218"), new Guid("75918352-7770-42bc-ac7d-8465efeccdae") },
                    { new Guid("0d300379-5971-407d-8b5b-e140b9ebaf52"), new Guid("76e349fe-6a9d-4f60-ace6-31719c54de95") },
                    { new Guid("55989ef9-f470-4f66-944c-9ebb372f1921"), new Guid("76e349fe-6a9d-4f60-ace6-31719c54de95") },
                    { new Guid("e7e92204-8adf-413c-8ea5-e5cb17071af6"), new Guid("76e349fe-6a9d-4f60-ace6-31719c54de95") },
                    { new Guid("601c05cd-5463-45d6-9f3b-348e67a6c9e2"), new Guid("78349080-2425-4609-a7d5-7c5ec9c0e6ed") },
                    { new Guid("a82477ee-2cab-4d15-ad26-437ddf4b81c0"), new Guid("78349080-2425-4609-a7d5-7c5ec9c0e6ed") },
                    { new Guid("cafbd6d4-e906-4165-8b29-7d2b8430da86"), new Guid("78349080-2425-4609-a7d5-7c5ec9c0e6ed") },
                    { new Guid("0d300379-5971-407d-8b5b-e140b9ebaf52"), new Guid("7ab14ead-c679-4bcd-b2ae-cba0e604d4be") },
                    { new Guid("c4715a2c-2f63-44ae-a399-dd8afe0f9006"), new Guid("7ab14ead-c679-4bcd-b2ae-cba0e604d4be") },
                    { new Guid("e7e92204-8adf-413c-8ea5-e5cb17071af6"), new Guid("7ab14ead-c679-4bcd-b2ae-cba0e604d4be") },
                    { new Guid("0d300379-5971-407d-8b5b-e140b9ebaf52"), new Guid("9130f1c1-4af5-4464-93bf-735b8a3ce752") },
                    { new Guid("2bfdaed4-9fb4-4601-b374-9cd554802c46"), new Guid("9130f1c1-4af5-4464-93bf-735b8a3ce752") },
                    { new Guid("894339a2-7c42-471a-a25f-c53d3c8ae70e"), new Guid("9130f1c1-4af5-4464-93bf-735b8a3ce752") },
                    { new Guid("2bfdaed4-9fb4-4601-b374-9cd554802c46"), new Guid("9de761ab-b856-4b43-9c7c-4d032674bb00") },
                    { new Guid("abfa3cbd-3235-4155-ae4a-4b03e9396043"), new Guid("9de761ab-b856-4b43-9c7c-4d032674bb00") },
                    { new Guid("cafbd6d4-e906-4165-8b29-7d2b8430da86"), new Guid("9de761ab-b856-4b43-9c7c-4d032674bb00") },
                    { new Guid("0d300379-5971-407d-8b5b-e140b9ebaf52"), new Guid("a124d1a6-1d79-48d1-8b53-c5f9fb88c2c4") },
                    { new Guid("2bfdaed4-9fb4-4601-b374-9cd554802c46"), new Guid("a124d1a6-1d79-48d1-8b53-c5f9fb88c2c4") },
                    { new Guid("be10e29f-83f8-42a5-b981-fa5cb5c8c21d"), new Guid("a124d1a6-1d79-48d1-8b53-c5f9fb88c2c4") },
                    { new Guid("0d300379-5971-407d-8b5b-e140b9ebaf52"), new Guid("ad866782-e78b-40f7-8d2b-389a4ea5f585") },
                    { new Guid("601c05cd-5463-45d6-9f3b-348e67a6c9e2"), new Guid("ad866782-e78b-40f7-8d2b-389a4ea5f585") },
                    { new Guid("d82d0f6a-8542-4387-83b8-6de2545b39f6"), new Guid("ad866782-e78b-40f7-8d2b-389a4ea5f585") },
                    { new Guid("2bfdaed4-9fb4-4601-b374-9cd554802c46"), new Guid("bc290a7d-20fd-40c9-80f2-e824f42b9bf9") },
                    { new Guid("cafbd6d4-e906-4165-8b29-7d2b8430da86"), new Guid("bc290a7d-20fd-40c9-80f2-e824f42b9bf9") },
                    { new Guid("e4e97845-79ba-416b-a6e3-9492110b952c"), new Guid("bc290a7d-20fd-40c9-80f2-e824f42b9bf9") },
                    { new Guid("2bfdaed4-9fb4-4601-b374-9cd554802c46"), new Guid("d11e5c9f-9e39-4113-b589-0142024e3577") },
                    { new Guid("9d47178a-0e90-4b3b-9d7b-f2681a720881"), new Guid("d11e5c9f-9e39-4113-b589-0142024e3577") },
                    { new Guid("cafbd6d4-e906-4165-8b29-7d2b8430da86"), new Guid("d11e5c9f-9e39-4113-b589-0142024e3577") },
                    { new Guid("0d300379-5971-407d-8b5b-e140b9ebaf52"), new Guid("e9c5c606-2ba7-4bda-ba6d-a5724f0fcf80") },
                    { new Guid("55989ef9-f470-4f66-944c-9ebb372f1921"), new Guid("e9c5c606-2ba7-4bda-ba6d-a5724f0fcf80") },
                    { new Guid("e7e92204-8adf-413c-8ea5-e5cb17071af6"), new Guid("e9c5c606-2ba7-4bda-ba6d-a5724f0fcf80") },
                    { new Guid("cafbd6d4-e906-4165-8b29-7d2b8430da86"), new Guid("efa2f173-a8ee-4d34-8de6-e211e8f6e4eb") },
                    { new Guid("e4e97845-79ba-416b-a6e3-9492110b952c"), new Guid("efa2f173-a8ee-4d34-8de6-e211e8f6e4eb") },
                    { new Guid("e7e92204-8adf-413c-8ea5-e5cb17071af6"), new Guid("efa2f173-a8ee-4d34-8de6-e211e8f6e4eb") },
                    { new Guid("601c05cd-5463-45d6-9f3b-348e67a6c9e2"), new Guid("f1f21a0a-ac50-4ae7-9dcf-4d4d40a07a6f") },
                    { new Guid("89a3a25e-e0d0-4f06-b0ef-7f142bb6c8df"), new Guid("f1f21a0a-ac50-4ae7-9dcf-4d4d40a07a6f") },
                    { new Guid("cafbd6d4-e906-4165-8b29-7d2b8430da86"), new Guid("f1f21a0a-ac50-4ae7-9dcf-4d4d40a07a6f") },
                    { new Guid("cafbd6d4-e906-4165-8b29-7d2b8430da86"), new Guid("f63128f8-3953-43eb-a328-cb790e7a0f7f") },
                    { new Guid("e4e97845-79ba-416b-a6e3-9492110b952c"), new Guid("f63128f8-3953-43eb-a328-cb790e7a0f7f") },
                    { new Guid("e7e92204-8adf-413c-8ea5-e5cb17071af6"), new Guid("f63128f8-3953-43eb-a328-cb790e7a0f7f") },
                    { new Guid("601c05cd-5463-45d6-9f3b-348e67a6c9e2"), new Guid("f889e11a-bf29-4717-a958-089f67206daa") },
                    { new Guid("abfa3cbd-3235-4155-ae4a-4b03e9396043"), new Guid("f889e11a-bf29-4717-a958-089f67206daa") },
                    { new Guid("cafbd6d4-e906-4165-8b29-7d2b8430da86"), new Guid("f889e11a-bf29-4717-a958-089f67206daa") },
                    { new Guid("601c05cd-5463-45d6-9f3b-348e67a6c9e2"), new Guid("fefb067a-6010-45fe-9106-62e247a0edad") },
                    { new Guid("98e1e944-0fc9-4a6e-94c4-63d43f88bc48"), new Guid("fefb067a-6010-45fe-9106-62e247a0edad") },
                    { new Guid("cafbd6d4-e906-4165-8b29-7d2b8430da86"), new Guid("fefb067a-6010-45fe-9106-62e247a0edad") }
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
