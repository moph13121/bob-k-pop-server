using bob_api.Models;

namespace bob_api.Data
{
    public class Seeder
    {
        private List<Product> _products = [];
        private List<Category> _categories = [];
        private List<Order> _orders = [];
        private List<ProductsOrder> _productsOrders = [];
        private List<ProductCategory> _productCategory = [];
        private List<Rating> _ratings = [];
        private List<User> _users = [];
        private List<Wishlist> _wishlists = [];

        public Seeder()
        {

            //Category
            Category Boy = new Category()
            {
                Id = Guid.NewGuid(),
                Name = "Boy",
            };
            Category Girl = new Category()
            {
                Id = Guid.NewGuid(),
                Name = "Girl"
            };
            Category BTS = new Category()
            {
                Id = Guid.NewGuid(),
                Name = "BTS",
            };
            Category StrayKids = new Category()
            {
                Id = Guid.NewGuid(),
                Name = "StrayKids",
            };
            Category BigBang = new Category()
            {
                Id = Guid.NewGuid(),
                Name = "BigBang",
            };
            Category Ateez = new Category()
            {
                Id = Guid.NewGuid(),
                Name = "Ateez",
            };
            Category Blackpink = new Category()
            {
                Id = Guid.NewGuid(),
                Name = "Blackpink",
            };
            Category RedVelvet = new Category()
            {
                Id = Guid.NewGuid(),
                Name = "Red Velvet",
            };
            Category LE_SSERAFIM = new Category()
            {
                Id = Guid.NewGuid(),
                Name = "LE SSERAFIM.",
            };
            Category GIDLE = new Category()
            {
                Id = Guid.NewGuid(),
                Name = "(G)I-DLE.",
            };

            Category GirlsGeneration = new Category()
            {
                Id = Guid.NewGuid(),
                Name = "Girls Generation",
            };

            Category EXO = new Category()
            {
                Id = Guid.NewGuid(),
                Name = "EXO",
            };

            Category Twice = new Category()
            {
                Id = Guid.NewGuid(),
                Name = "Twice",
            };

            Category Seventeen = new Category()
            {
                Id = Guid.NewGuid(),
                Name = "Seventeen",
            };

            Category LightStickProducts = new Category()
            {
                Id = Guid.NewGuid(),
                Name = "LightStick"
            };
            Category JewelryProducts = new Category()
            {
                Id = Guid.NewGuid(),
                Name = "Jewelry"
            };
            Category MerchProducts = new Category()
            {
                Id = Guid.NewGuid(),
                Name = "Merch",
            };
            Category MusicProducts = new Category()
            {
                Id = Guid.NewGuid(),
                Name = "Music",
            };

            _categories.Add(Girl);
            _categories.Add(Boy);
            _categories.Add(BTS);
            _categories.Add(StrayKids);
            _categories.Add(BigBang);
            _categories.Add(Ateez);
            _categories.Add(Blackpink);
            _categories.Add(RedVelvet);
            _categories.Add(LE_SSERAFIM);
            _categories.Add(GIDLE);
            _categories.Add(GirlsGeneration);
            _categories.Add(EXO);
            _categories.Add(Seventeen);
            _categories.Add(Twice);
            _categories.Add(LightStickProducts);
            _categories.Add(JewelryProducts);
            _categories.Add(MerchProducts);
            _categories.Add(MusicProducts);

            //Products

            Product AteezEaring1 = new Product()
            {
                Id = Guid.NewGuid(),
                Title = "Ateez Leak Earring",
                Price = 10,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Image = "https://github.com/moph13121/bob-k-pop-server/blob/main/images/Jewelry_boys/-az04-ateez-leak-earring-removebg-preview.png",
                Stock = 10,

            };

            Product AteezEaring2 = new Product()
            {
                Id = Guid.NewGuid(),
                Title = "Ateez Earcuff",
                Price = 10,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Image = "https://github.com/moph13121/bob-k-pop-server/blob/main/images/Jewelry_boys/-az05-ateez-range-piercing-earring-earcuff-removebg-preview.png",
                Stock = 10,

            };


            Product BtsEarring1 = new Product()
            {
                Id = Guid.NewGuid(),
                Price = 15,
                Title = "BTS Nesto Ring",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Image = "https://github.com/moph13121/bob-k-pop-server/blob/main/images/Jewelry_boys/-bs110-bts-nesto-ring-removebg-preview.png",
                Stock = 10,
            };


            Product BtsEarring2 = new Product()
            {
                Id = Guid.NewGuid(),
                Price = 11,
                Title = "BTS Mao Earring",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Image = "https://github.com/moph13121/bob-k-pop-server/blob/main/images/Jewelry_boys/-bs114-bts-mao-earring-ear-cuff-piercing-removebg-preview.png",
                Stock = 10,
            };

            Product ExoJewelry1 = new Product()
            {
                Id = Guid.NewGuid(),
                Price = 11,
                Title = "Exo Transformer Ring",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Image = "https://github.com/moph13121/bob-k-pop-server/blob/main/images/Jewelry_boys/-ex234-exo-transformer-ring-removebg-preview.png",
                Stock = 10,
            };

            Product ExoJewelry2 = new Product()
            {
                Id = Guid.NewGuid(),
                Price = 11,
                Title = "Exo Emblem Necklace",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Image = "https://github.com/moph13121/bob-k-pop-server/blob/main/images/Jewelry_boys/-ex236-exo-new-emblem-necklace-removebg-preview.png",
                Stock = 10,
            };

            Product BlackPinkJewelry1 = new Product()
            {
                Id = Guid.NewGuid(),
                Price = 10,
                Title = "BlackPink Lisa Necklace",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Image = "https://github.com/moph13121/bob-k-pop-server/blob/main/images/Jewelry_girls/Blackpink_Lisa_necklace-removebg-preview.png",
                Stock = 10,
            };
            Product BlackPinkJewelry2 = new Product()
            {
                Id = Guid.NewGuid(),
                Price = 10,
                Title = "BlackPink Lisa Bracelet",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Image = "https://github.com/moph13121/bob-k-pop-server/blob/main/images/Jewelry_girls/blackpink_Lisa_braclet-removebg-preview.png",
                Stock = 10,
            };

            Product GirlsGenerationJewelry1 = new Product()
            {
                Id = Guid.NewGuid(),
                Price = 10,
                Title = "Girls Generation Smile Earring",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Image = "https://github.com/moph13121/bob-k-pop-server/blob/main/images/Jewelry_girls/-sn10-girls-generation-smile-earring-piercing-removebg-preview.png",
                Stock = 10,
            };

            Product GirlsGenerationJewelry2 = new Product()
            {
                Id = Guid.NewGuid(),
                Price = 10,
                Title = "Girls Generation Ribbon Earring",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Image = "https://github.com/moph13121/bob-k-pop-server/blob/main/images/Jewelry_girls/-sn13-girls-generation-cubic-ribbon-earrings-removebg-preview.png",
                Stock = 10,
            };

            //KPOP Music
            Product AteezAlbum = new Product()
            {
                Id = Guid.NewGuid(),
                Price = 10,
                Title = "Ateez - The World EP 2 OUTLAW",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Image = "https://github.com/moph13121/bob-k-pop-server/blob/main/images/KpopMusic_boys/ATEEZ%20-%20THE%20WORLD%20EP%202%20%20OUTLAW.png",
                Stock = 10,
            };
            Product BTSJhopeAlbum = new Product()
            {
                Id = Guid.NewGuid(),
                Price = 10,
                Title = "JHope - JACK IN THE BOX",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Image = "https://github.com/moph13121/bob-k-pop-server/blob/main/images/KpopMusic_boys/BTS%20JHOPE%20ALBUM%20-%20JACK%20IN%20THE%20BOX.png",
                Stock = 10,
            };
            Product StrayKidsAlbum = new Product()
            {
                Id = Guid.NewGuid(),
                Price = 10,
                Title = "Stray Kids - MAXIDENT",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Image = "https://github.com/moph13121/bob-k-pop-server/blob/main/images/KpopMusic_boys/Stray%20Kids%20-%20MAXIDENT.png",
                Stock = 10,
            };
            Product SeventeenAlbum = new Product()
            {
                Id = Guid.NewGuid(),
                Price = 10,
                Title = "SEVENTEEN - FML 10th Mini Album",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Image = "https://github.com/moph13121/bob-k-pop-server/blob/main/images/KpopMusic_boys/SEVENTEEN%20-%20FML%2010th%20Mini%20Album.png",
                Stock = 10,
            };
            Product GIDLEAlbum = new Product()
            {
                Id = Guid.NewGuid(),
                Price = 10,
                Title = "(G)I-DLE - I FEEL 6th Mini Album",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Image = "https://github.com/moph13121/bob-k-pop-server/blob/main/images/KpopMusic_girls/(G)I-DLE%20-%20I%20FEEL%206th%20Mini%20Album.png",
                Stock = 10,
            };
            Product RedVelvetAlbum = new Product()
            {
                Id = Guid.NewGuid(),
                Price = 10,
                Title = "Red Velvet - Album",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Image = "https://github.com/moph13121/bob-k-pop-server/blob/main/images/KpopMusic_girls/RED_VELVET%20ALBUM.png",
                Stock = 10,
            };

            Product LE_SERRAFIMAlbum = new Product()
            {
                Id = Guid.NewGuid(),
                Price = 10,
                Title = "LE SSERAFIM - ANTIFRAGILE",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Image = "https://github.com/moph13121/bob-k-pop-server/blob/main/images/KpopMusic_girls/LE%20SSERAFIM%20ALBUM-%20ANTIFRAGILE.png",
                Stock = 10,
            };
            Product BlackPinkLisaAlbum = new Product()
            {
                Id = Guid.NewGuid(),
                Price = 10,
                Title = "BlackPink Lisa - LALISA",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Image = "https://github.com/moph13121/bob-k-pop-server/blob/main/images/KpopMusic_girls/BLACKPINK%20LISA%20ALBUM%20-%20LALISA.png",
                Stock = 10,
            };

            Product TwiceAlbum = new Product()
            {
                Id = Guid.NewGuid(),
                Price = 10,
                Title = "Twice - With You",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Image = "https://github.com/moph13121/bob-k-pop-server/blob/main/images/KpopMusic_girls/TWICE%20ALBUM%20-%20WITH%20YOU-TH.jpg",
                Stock = 10,
            };

            //Lightsticks
            Product BTSLightstick = new Product()
            {
                Id = Guid.NewGuid(),
                Price = 10,
                Title = "BTS Official Light Stick Special Edition",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Image = "https://github.com/moph13121/bob-k-pop-server/blob/main/images/Lightsticks_boys/BTS%20Official%20Light%20Stick%20Special%20Edition.png",
                Stock = 10,
            };

            Product BigBangLightstick = new Product()
            {
                Id = Guid.NewGuid(),
                Price = 10,
                Title = "BigBang Official Light Stick ",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Image = "https://github.com/moph13121/bob-k-pop-server/blob/main/images/Lightsticks_boys/BIGBANG%20OFFICIAL%20LIGHT%20STICK%20VER%204.png",
                Stock = 10,
            };

            Product AteezLightstick = new Product()
            {
                Id = Guid.NewGuid(),
                Price = 10,
                Title = "Ateez Official Light Ver.2",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Image = "https://github.com/moph13121/bob-k-pop-server/blob/main/images/Lightsticks_boys/ATEEZ%20OFFICIAL%20LIGHTSTICK%20VER%202%20.png",
                Stock = 10,
            };

            Product BlackpinkLightstick = new Product()
            {
                Id = Guid.NewGuid(),
                Price = 10,
                Title = "Blackpink Official Lightstick Ver.2",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Image = "https://github.com/moph13121/bob-k-pop-server/blob/main/images/Lightsticks_girls/BLACKPINK%20OFFICIAL%20LIGHTSTICK%20VER%202%20%E2%80%93%20NEW%20MODEL.png",
                Stock = 10,
            };

            Product GidleLightstick = new Product()
            {
                Id = Guid.NewGuid(),
                Price = 10,
                Title = "(G)I-DLE.",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Image = "https://github.com/moph13121/bob-k-pop-server/blob/main/images/Lightsticks_girls/GIDLE%20OFFICIAL%20LIGHTSTICK%20VER..png",
                Stock = 10,
            };

            Product LESSERAFIMLIGHTSTICK = new Product()
            {
                Id = Guid.NewGuid(),
                Price = 10,
                Title = "LE SSERAFIM Official Lightstick",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Image = "https://github.com/moph13121/bob-k-pop-server/blob/main/images/Lightsticks_girls/LE%20SSERAFIM%20OFFICIAL%20LIGHTSTICK.png",
                Stock = 10,
            };

            Product RedVelvetLightstick = new Product()
            {
                Id = Guid.NewGuid(),
                Price = 10,
                Title = "Red Velvet Official Lightstick",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Image = "https://github.com/moph13121/bob-k-pop-server/blob/main/images/Lightsticks_girls/RED%20VELVET%20OFFICIAL%20LIGHTSTICK.png",
                Stock = 10,
            };

            Product GGLightstick = new Product()
            {
                Id = Guid.NewGuid(),
                Price = 10,
                Title = "Girls Generation Official Lightstick",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Image = "https://github.com/moph13121/bob-k-pop-server/blob/main/images/Lightsticks_girls/GIRLS_GENERATION_OFFICIAL_LIGHTSTICK.png",
                Stock = 10,
            };
            _products.Add(AteezEaring1);
            _products.Add(AteezEaring2);
            _products.Add(BtsEarring1);
            _products.Add(BtsEarring2);
            _products.Add(ExoJewelry1);
            _products.Add(ExoJewelry2);
            _products.Add(BlackPinkJewelry1);
            _products.Add(BlackPinkJewelry2);
            _products.Add(GirlsGenerationJewelry1);
            _products.Add(GirlsGenerationJewelry2);

            //Music
            _products.Add(AteezAlbum);
            _products.Add(BTSJhopeAlbum);
            _products.Add(StrayKidsAlbum);
            _products.Add(SeventeenAlbum);
            _products.Add(GIDLEAlbum);
            _products.Add(RedVelvetAlbum);
            _products.Add(LE_SERRAFIMAlbum);
            _products.Add(BlackPinkLisaAlbum);
            _products.Add(TwiceAlbum);

            //Lightsticks
            _products.Add(BTSLightstick);
            _products.Add(BigBangLightstick);
            _products.Add(AteezLightstick);
            _products.Add(BlackpinkLightstick);
            _products.Add(GidleLightstick);
            _products.Add(LESSERAFIMLIGHTSTICK);
            _products.Add(RedVelvetLightstick);
            _products.Add(GGLightstick);


            ProductCategory productCategory1 = new ProductCategory()
            {
                ProductId = AteezEaring1.Id,
                CategoryId = JewelryProducts.Id,
            };
            ProductCategory productCategory2 = new ProductCategory()
            {
                ProductId = AteezEaring1.Id,
                CategoryId = Boy.Id,
            };
            ProductCategory productCategory3 = new ProductCategory()
            {
                ProductId = AteezEaring1.Id,
                CategoryId = Ateez.Id,
            };
            ProductCategory productCategory4 = new ProductCategory()
            {
                ProductId = AteezEaring2.Id,
                CategoryId = JewelryProducts.Id,
            };
            ProductCategory productCategory5 = new ProductCategory()
            {
                ProductId = AteezEaring2.Id,
                CategoryId = Boy.Id,
            };
            ProductCategory productCategory6 = new ProductCategory()
            {
                ProductId = AteezEaring2.Id,
                CategoryId = Ateez.Id,
            };

            //BTS Earring
            ProductCategory productCategory7 = new ProductCategory()
            {
                ProductId = BtsEarring1.Id,
                CategoryId = JewelryProducts.Id,
            };
            ProductCategory productCategory8 = new ProductCategory()
            {
                ProductId = BtsEarring1.Id,
                CategoryId = Boy.Id,
            };
            ProductCategory productCategory9 = new ProductCategory()
            {
                ProductId = BtsEarring1.Id,
                CategoryId = BTS.Id,
            };
            ProductCategory productCategory10 = new ProductCategory()
            {
                ProductId = BtsEarring2.Id,
                CategoryId = JewelryProducts.Id,
            };
            ProductCategory productCategory11 = new ProductCategory()
            {
                ProductId = BtsEarring2.Id,
                CategoryId = Boy.Id,
            };
            ProductCategory productCategory12 = new ProductCategory()
            {
                ProductId = BtsEarring2.Id,
                CategoryId = BTS.Id,
            };


            //BlackPink Jewelry

            ProductCategory productCategory13 = new ProductCategory()
            {
                ProductId = BlackPinkJewelry1.Id,
                CategoryId = JewelryProducts.Id,
            };
            ProductCategory productCategory14 = new ProductCategory()
            {
                ProductId = BlackPinkJewelry1.Id,
                CategoryId = Girl.Id,
            };
            ProductCategory productCategory15 = new ProductCategory()
            {
                ProductId = BlackPinkJewelry1.Id,
                CategoryId = Blackpink.Id,
            };
            ProductCategory productCategory16 = new ProductCategory()
            {
                ProductId = BlackPinkJewelry2.Id,
                CategoryId = JewelryProducts.Id,
            };
            ProductCategory productCategory17 = new ProductCategory()
            {
                ProductId = BlackPinkJewelry2.Id,
                CategoryId = Girl.Id,
            };
            ProductCategory productCategory18 = new ProductCategory()
            {
                ProductId = BlackPinkJewelry2.Id,
                CategoryId = Blackpink.Id,
            };

            //Girls Generation 
            ProductCategory productCategory19 = new ProductCategory()
            {
                ProductId = GirlsGenerationJewelry1.Id,
                CategoryId = JewelryProducts.Id,
            };
            ProductCategory productCategory20 = new ProductCategory()
            {
                ProductId = GirlsGenerationJewelry1.Id,
                CategoryId = Girl.Id,
            };
            ProductCategory productCategory21 = new ProductCategory()
            {
                ProductId = GirlsGenerationJewelry1.Id,
                CategoryId = GirlsGeneration.Id,
            };
            ProductCategory productCategory22 = new ProductCategory()
            {
                ProductId = GirlsGenerationJewelry2.Id,
                CategoryId = JewelryProducts.Id,
            };
            ProductCategory productCategory23 = new ProductCategory()
            {
                ProductId = GirlsGenerationJewelry2.Id,
                CategoryId = Girl.Id,
            };
            ProductCategory productCategory24 = new ProductCategory()
            {
                ProductId = GirlsGenerationJewelry2.Id,
                CategoryId = GirlsGeneration.Id,
            };

            ProductCategory productCategory25 = new ProductCategory()
            {
                ProductId = ExoJewelry1.Id,
                CategoryId = JewelryProducts.Id,
            };
            ProductCategory productCategory26 = new ProductCategory()
            {
                ProductId = ExoJewelry1.Id,
                CategoryId = Boy.Id,
            };
            ProductCategory productCategory27 = new ProductCategory()
            {
                ProductId = ExoJewelry1.Id,
                CategoryId = EXO.Id,
            };
            ProductCategory productCategory28 = new ProductCategory()
            {
                ProductId = ExoJewelry2.Id,
                CategoryId = JewelryProducts.Id,
            };
            ProductCategory productCategory29 = new ProductCategory()
            {
                ProductId = ExoJewelry2.Id,
                CategoryId = Boy.Id,
            };
            ProductCategory productCategory30 = new ProductCategory()
            {
                ProductId = ExoJewelry2.Id,
                CategoryId = EXO.Id,
            };


            //Albums
            ProductCategory productCategory31 = new ProductCategory()
            {
                ProductId = AteezAlbum.Id,
                CategoryId = MusicProducts.Id,
            };
            ProductCategory productCategory32 = new ProductCategory()
            {
                ProductId = AteezAlbum.Id,
                CategoryId = Boy.Id,
            };
            ProductCategory productCategory33 = new ProductCategory()
            {
                ProductId = AteezAlbum.Id,
                CategoryId = Ateez.Id,
            };

            ProductCategory productCategory34 = new ProductCategory()
            {
                ProductId = BTSJhopeAlbum.Id,
                CategoryId = MusicProducts.Id,
            };
            ProductCategory productCategory35 = new ProductCategory()
            {
                ProductId = BTSJhopeAlbum.Id,
                CategoryId = Boy.Id,
            };
            ProductCategory productCategory36 = new ProductCategory()
            {
                ProductId = BTSJhopeAlbum.Id,
                CategoryId = BTS.Id,
            };

            ProductCategory productCategory37 = new ProductCategory()
            {
                ProductId = StrayKidsAlbum.Id,
                CategoryId = MusicProducts.Id,
            };
            ProductCategory productCategory38 = new ProductCategory()
            {
                ProductId = StrayKidsAlbum.Id,
                CategoryId = Boy.Id,
            };
            ProductCategory productCategory39 = new ProductCategory()
            {
                ProductId = StrayKidsAlbum.Id,
                CategoryId = StrayKids.Id,
            };

            ProductCategory productCategory40 = new ProductCategory()
            {
                ProductId = SeventeenAlbum.Id,
                CategoryId = Seventeen.Id,
            };

            ProductCategory productCategory41 = new ProductCategory()
            {
                ProductId = SeventeenAlbum.Id,
                CategoryId = MusicProducts.Id,
            };
            ProductCategory productCategory42 = new ProductCategory()
            {
                ProductId = SeventeenAlbum.Id,
                CategoryId = Boy.Id,
            };
            ProductCategory productCategory43 = new ProductCategory()
            {
                ProductId = GIDLEAlbum.Id,
                CategoryId = MusicProducts.Id,
            };

            ProductCategory productCategory44 = new ProductCategory()
            {
                ProductId = GIDLEAlbum.Id,
                CategoryId = GIDLE.Id,
            };
            ProductCategory productCategory45 = new ProductCategory()
            {
                ProductId = GIDLEAlbum.Id,
                CategoryId = Girl.Id,
            };
            ProductCategory productCategory46 = new ProductCategory()
            {
                ProductId = RedVelvetAlbum.Id,
                CategoryId = Girl.Id,
            };
            ProductCategory productCategory47 = new ProductCategory()
            {
                ProductId = RedVelvetAlbum.Id,
                CategoryId = MusicProducts.Id,
            };
            ProductCategory productCategory48 = new ProductCategory()
            {
                ProductId = RedVelvetAlbum.Id,
                CategoryId = RedVelvet.Id,
            };

            //_products.Add(TwiceAlbum);

            ProductCategory productCategory49 = new ProductCategory()
            {
                ProductId = LE_SERRAFIMAlbum.Id,
                CategoryId = Girl.Id,
            };
            ProductCategory productCategory50 = new ProductCategory()
            {
                ProductId = LE_SERRAFIMAlbum.Id,
                CategoryId = MusicProducts.Id,
            };
            ProductCategory productCategory51 = new ProductCategory()
            {
                ProductId = LE_SERRAFIMAlbum.Id,
                CategoryId = LE_SSERAFIM.Id,
            };

            ProductCategory productCategory52 = new ProductCategory()
            {
                ProductId = BlackPinkLisaAlbum.Id,
                CategoryId = Girl.Id,
            };
            ProductCategory productCategory53 = new ProductCategory()
            {
                ProductId = BlackPinkLisaAlbum.Id,
                CategoryId = MusicProducts.Id,
            };
            ProductCategory productCategory54 = new ProductCategory()
            {
                ProductId = BlackPinkLisaAlbum.Id,
                CategoryId = Blackpink.Id,
            };

            ProductCategory productCategory55 = new ProductCategory()
            {
                ProductId = TwiceAlbum.Id,
                CategoryId = Girl.Id,
            };
            ProductCategory productCategory56 = new ProductCategory()
            {
                ProductId = TwiceAlbum.Id,
                CategoryId = MusicProducts.Id,
            };
            ProductCategory productCategory57 = new ProductCategory()
            {
                ProductId = TwiceAlbum.Id,
                CategoryId = Twice.Id,
            };

            //Lightsticks
            //_products.Add(GGLightstick);

            ProductCategory productCategory58 = new ProductCategory()
            {
                ProductId = BTSLightstick.Id,
                CategoryId = Boy.Id,
            };
            ProductCategory productCategory59 = new ProductCategory()
            {
                ProductId = BTSLightstick.Id,
                CategoryId = LightStickProducts.Id,
            };
            ProductCategory productCategory60 = new ProductCategory()
            {
                ProductId = BTSLightstick.Id,
                CategoryId = BTS.Id,
            };

            ProductCategory productCategory61 = new ProductCategory()
            {
                ProductId = BigBangLightstick.Id,
                CategoryId = Boy.Id,
            };
            ProductCategory productCategory62 = new ProductCategory()
            {
                ProductId = BigBangLightstick.Id,
                CategoryId = LightStickProducts.Id,
            };
            ProductCategory productCategory63 = new ProductCategory()
            {
                ProductId = BigBangLightstick.Id,
                CategoryId = BigBang.Id,
            };

            ProductCategory productCategory64 = new ProductCategory()
            {
                ProductId = AteezLightstick.Id,
                CategoryId = Boy.Id,
            };
            ProductCategory productCategory65 = new ProductCategory()
            {
                ProductId = AteezLightstick.Id,
                CategoryId = LightStickProducts.Id,
            };
            ProductCategory productCategory66 = new ProductCategory()
            {
                ProductId = AteezLightstick.Id,
                CategoryId = Ateez.Id,
            };

            ProductCategory productCategory67 = new ProductCategory()
            {
                ProductId = BlackpinkLightstick.Id,
                CategoryId = Girl.Id,
            };
            ProductCategory productCategory68 = new ProductCategory()
            {
                ProductId = BlackpinkLightstick.Id,
                CategoryId = LightStickProducts.Id,
            };
            ProductCategory productCategory69 = new ProductCategory()
            {
                ProductId = BlackpinkLightstick.Id,
                CategoryId = Blackpink.Id,
            };

            ProductCategory productCategory70 = new ProductCategory()
            {
                ProductId = GidleLightstick.Id,
                CategoryId = Girl.Id,
            };
            ProductCategory productCategory71 = new ProductCategory()
            {
                ProductId = GidleLightstick.Id,
                CategoryId = LightStickProducts.Id,
            };
            ProductCategory productCategory72 = new ProductCategory()
            {
                ProductId = GidleLightstick.Id,
                CategoryId = GIDLE.Id,
            };

            ProductCategory productCategory73 = new ProductCategory()
            {
                ProductId = LESSERAFIMLIGHTSTICK.Id,
                CategoryId = Girl.Id,
            };
            ProductCategory productCategory74 = new ProductCategory()
            {
                ProductId = LESSERAFIMLIGHTSTICK.Id,
                CategoryId = LightStickProducts.Id,
            };
            ProductCategory productCategory75 = new ProductCategory()
            {
                ProductId = LESSERAFIMLIGHTSTICK.Id,
                CategoryId = LE_SSERAFIM.Id,
            };

            ProductCategory productCategory76 = new ProductCategory()
            {
                ProductId = RedVelvetLightstick.Id,
                CategoryId = Girl.Id,
            };
            ProductCategory productCategory77 = new ProductCategory()
            {
                ProductId = RedVelvetLightstick.Id,
                CategoryId = LightStickProducts.Id,
            };
            ProductCategory productCategory78 = new ProductCategory()
            {
                ProductId = RedVelvetLightstick.Id,
                CategoryId = RedVelvet.Id,
            };

            ProductCategory productCategory79 = new ProductCategory()
            {
                ProductId = GGLightstick.Id,
                CategoryId = Girl.Id,
            };
            ProductCategory productCategory80 = new ProductCategory()
            {
                ProductId = GGLightstick.Id,
                CategoryId = LightStickProducts.Id,
            };
            ProductCategory productCategory81 = new ProductCategory()
            {
                ProductId = GGLightstick.Id,
                CategoryId = GirlsGeneration.Id,
            };

            _productCategory.Add(productCategory1);
            _productCategory.Add(productCategory2);
            _productCategory.Add(productCategory3);
            _productCategory.Add(productCategory4);
            _productCategory.Add(productCategory5);
            _productCategory.Add(productCategory6);
            _productCategory.Add(productCategory7);
            _productCategory.Add(productCategory8);
            _productCategory.Add(productCategory9);
            _productCategory.Add(productCategory10);
            _productCategory.Add(productCategory11);
            _productCategory.Add(productCategory12);
            _productCategory.Add(productCategory13);
            _productCategory.Add(productCategory14);
            _productCategory.Add(productCategory15);
            _productCategory.Add(productCategory16);
            _productCategory.Add(productCategory17);
            _productCategory.Add(productCategory18);
            _productCategory.Add(productCategory19);
            _productCategory.Add(productCategory20);
            _productCategory.Add(productCategory21);
            _productCategory.Add(productCategory22);
            _productCategory.Add(productCategory23);
            _productCategory.Add(productCategory24);
            _productCategory.Add(productCategory25);
            _productCategory.Add(productCategory26);
            _productCategory.Add(productCategory27);
            _productCategory.Add(productCategory28);
            _productCategory.Add(productCategory29);
            _productCategory.Add(productCategory30);
            _productCategory.Add(productCategory31);
            _productCategory.Add(productCategory32);
            _productCategory.Add(productCategory33);
            _productCategory.Add(productCategory34);
            _productCategory.Add(productCategory35);
            _productCategory.Add(productCategory36);
            _productCategory.Add(productCategory37);
            _productCategory.Add(productCategory38);
            _productCategory.Add(productCategory39);
            _productCategory.Add(productCategory40);
            _productCategory.Add(productCategory41);
            _productCategory.Add(productCategory42);
            _productCategory.Add(productCategory43);
            _productCategory.Add(productCategory44);
            _productCategory.Add(productCategory45);
            _productCategory.Add(productCategory46);
            _productCategory.Add(productCategory47);
            _productCategory.Add(productCategory48);
            _productCategory.Add(productCategory49);
            _productCategory.Add(productCategory50);
            _productCategory.Add(productCategory51);
            _productCategory.Add(productCategory52);
            _productCategory.Add(productCategory53);
            _productCategory.Add(productCategory54);
            _productCategory.Add(productCategory55);
            _productCategory.Add(productCategory56);
            _productCategory.Add(productCategory57);
            _productCategory.Add(productCategory58);
            _productCategory.Add(productCategory59);
            _productCategory.Add(productCategory60);
            _productCategory.Add(productCategory61);
            _productCategory.Add(productCategory62);
            _productCategory.Add(productCategory63);
            _productCategory.Add(productCategory64);
            _productCategory.Add(productCategory65);
            _productCategory.Add(productCategory66);
            _productCategory.Add(productCategory67);
            _productCategory.Add(productCategory68);
            _productCategory.Add(productCategory69);
            _productCategory.Add(productCategory70);
            _productCategory.Add(productCategory71);
            _productCategory.Add(productCategory72);
            _productCategory.Add(productCategory73);
            _productCategory.Add(productCategory74);
            _productCategory.Add(productCategory75);
            _productCategory.Add(productCategory76);
            _productCategory.Add(productCategory77);
            _productCategory.Add(productCategory78);
            _productCategory.Add(productCategory79);
            _productCategory.Add(productCategory80);
            _productCategory.Add(productCategory81);

            //User
            User user1 = new User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Test",
                LastName = "Test",
                Email = "test@test.no",
                Password = "password",
            };
            _users.Add(user1);

            //Order
            Order order = new Order()
            {
                Id = Guid.NewGuid(),
                UserId = user1.Id,
                status = "Pending"
            };
            _orders.Add(order);

            //Ratings

            Rating rating1 = new Rating()
            {
                Id = Guid.NewGuid(),
                Review = "This product was straight garbage cuh",
                RatingValue = 2,
                UserId = user1.Id,
                ProductId = ExoJewelry1.Id,

            };

            Rating rating2 = new Rating()
            {
                Id = Guid.NewGuid(),
                Review = "This product was straight fire blud",
                RatingValue = 5,
                UserId = user1.Id,
                ProductId = ExoJewelry2.Id,

            };
            _ratings.Add(rating1);
            _ratings.Add(rating2);
            //ProductsOrder

            //ProductsOrder productsOrder = new ProductsOrder()
            //{
            //    ProductId = product1.Id,
            //    OrderId = order.Id,
            //    Quantity = 1,
            //};

            //ProductsOrder productsOrder2 = new ProductsOrder()
            //{
            //    ProductId = product2.Id,
            //    OrderId = order.Id,
            //    Quantity = 3,
            //};

            //_productsOrders.Add(productsOrder);
            //_productsOrders.Add(productsOrder2);


        }



        public List<Product> Products { get { return _products; } }
        public List<Category> Categories { get { return _categories; } }
        public List<Order> Orders { get { return _orders; } }
        public List<ProductsOrder> ProductsOrder { get { return _productsOrders; } }
        public List<ProductCategory> ProductCategory { get { return _productCategory; } }
        public List<Rating> Ratings { get { return _ratings; } }
        public List<User> Users { get { return _users; } }
        public List<Wishlist> Wishlists { get { return _wishlists; } }
    }
}
