using bob_api.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace bob_api.Data
{
    public class DatabaseContext : DbContext
    {
        private string _connectionString;

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) 
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build();
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString")!;
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
            optionsBuilder.LogTo(message => Debug.WriteLine(message)); //see the sql EF using in the console
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Seeder seeder = new Seeder();

            modelBuilder.Entity<Product>().HasData(seeder.Products);
            modelBuilder.Entity<Category>().HasData(seeder.Categories);
            modelBuilder.Entity<User>().HasData(seeder.Users);
            modelBuilder.Entity<Order>().HasData(seeder.Orders);
            modelBuilder.Entity<Rating>().HasData(seeder.Ratings);
            modelBuilder.Entity<ProductsOrder>().HasData(seeder.ProductsOrder);

            //Set up keys for models
            modelBuilder.Entity<Category>()
                .HasKey(c => c.Id);
            
            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id);
            
            modelBuilder.Entity<Rating>()
                .HasKey(r => r.Id);
            
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Order>()
                .HasKey(o => o.Id);

            modelBuilder.Entity<ProductsOrder>()
                .HasKey(po => new {po.OrderId, po.ProductId});

            modelBuilder.Entity<Wishlist>()
                .HasKey(w => w.Id);

            //Add foreign-key relations
            //modelBuilder.Entity<Rating>()
            //    .HasOne<User>(r => r.User)
            //    .WithMany(u => u.Ratings)
            //    .HasForeignKey(r => r.UserId);

            //modelBuilder.Entity<Rating>()
            //    .HasOne<Product>(r => r.Product)
            //    .WithMany(p => p.Ratings)
            //    .HasForeignKey(r => r.ProductId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Wishlist>()
            //    .HasOne<User>(w => w.User)
            //    .WithMany(u => u.Wishlists)
            //    .HasForeignKey(w => w.UserId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Order>()
            //    .HasOne<User>(o => o.User) 
            //    .WithMany(u => u.Orders)
            //    .HasForeignKey(o => o.UserId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //Join table for Product and Category
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Categories)
                .WithMany(c => c.Products)
                .UsingEntity(pc => pc.ToTable("product_categories"));

            //Join table for Product and Wishlist
            //modelBuilder.Entity<Wishlist>()
            //    .HasMany<Product>(w => w.Products)
            //    .WithMany(p => p.Wishlists)
            //    .UsingEntity(wp => wp.ToTable("product_wishlist"));

            //Relation for ProductsOrder
            modelBuilder.Entity<ProductsOrder>()
                .HasOne<Order>(po => po.Order)
                .WithMany(o => o.ProductOrders)
                .HasForeignKey(po => po.OrderId);

            modelBuilder.Entity<ProductsOrder>()
               .HasOne<Product>(po => po.Product)
                .WithMany(p => p.ProductsOrders)
                .HasForeignKey(po => po.ProductId);

            //Transitory modelBuilder.Entity<X>().Navigation(x => x.x).AutoInclude()

            //Product
            //modelBuilder.Entity<Product>().Navigation(p => p.Categories).AutoInclude();
            //modelBuilder.Entity<Product>().Navigation(p => p.Ratings).AutoInclude();
            //modelBuilder.Entity<Product>().Navigation(p => p.ProductsOrders).AutoInclude();


            //User
            //modelBuilder.Entity<User>().Navigation(u => u.Ratings).AutoInclude();
            //modelBuilder.Entity<User>().Navigation(u => u.Wishlists).AutoInclude();
            modelBuilder.Entity<User>().Navigation(u => u.Orders).AutoInclude();

            //Order
            //modelBuilder.Entity<Order>().Navigation(n => n.User).AutoInclude();
            modelBuilder.Entity<Order>().Navigation(n => n.ProductOrders).AutoInclude();

            //Category
            //modelBuilder.Entity<Category>().Navigation(c => c.Products).AutoInclude();

            //ProductsOrder
            modelBuilder.Entity<ProductsOrder>().Navigation(po => po.Product).AutoInclude();

            //Rating
            //modelBuilder.Entity<Rating>().Navigation(n => n.User).AutoInclude();
            //modelBuilder.Entity<Rating>().Navigation(n => n.Product).AutoInclude();

            //Wishlist
            modelBuilder.Entity<Wishlist>().Navigation(w => w.Products).AutoInclude();


        }

        public DbSet<Product> Product { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<ProductsOrder> ProductOrders { get; set; }

        public DbSet<Wishlist> Wishlist { get; set; }
    }
}
