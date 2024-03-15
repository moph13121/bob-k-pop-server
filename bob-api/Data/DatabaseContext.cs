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
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString")!;
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Set up keys for models
            modelBuilder.Entity<Category>()
                .HasKey(c => c.Id);
            
            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id);
            
            modelBuilder.Entity<Rating>()
                .HasKey(r => r.Id);
            
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            //Add foreign-key relations
            modelBuilder.Entity<Rating>()
                .HasOne<User>(r => r.User)
                .WithMany(u => u.Ratings)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Rating>()
                .HasOne<Product>(r => r.Product)
                .WithMany(p => p.Ratings)
                .HasForeignKey(r => r.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            //Join table for Product and Category
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Categories)
                .WithMany(c => c.Products)
                .UsingEntity(pc => pc.ToTable("product_categories"));

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
            optionsBuilder.LogTo(message => Debug.WriteLine(message)); //see the sql EF using in the console

        }

        public DbSet<Product> Product { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
