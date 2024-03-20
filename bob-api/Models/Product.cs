using System.ComponentModel.DataAnnotations.Schema;

namespace bob_api.Models
{
    public class Product
    {
        [Column("id")]
        public Guid Id { get; set;}

        [Column("title")]
        public string Title { get; set;}

        [Column ("description")]
        public string Description { get; set;}

        [Column("price")]
        public int Price { get; set;}

        [Column("stock")]
        public int Stock { get; set;}

        [Column("image")] 
        public string Image { get; set;}

        [Column("created_at")]
        public DateTime CreatedAt { get; set;} = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        //Navigational properties
        //public ICollection<Category> Categories { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set;}

        //public ICollection<Rating> Ratings { get; set; }

        public ICollection<ProductsOrder> ProductsOrders { get; set; }

        //public ICollection<Wishlist> Wishlists { get; set; }
    }

    // Product without references to navigational properties
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Construct ProductDto using a Product
        public ProductDTO(Product product) 
        { 
            Id = product.Id;
            Title = product.Title;
            Description = product.Description;
            Price = product.Price;
            Stock = product.Stock;
            Image = product.Image;
            CreatedAt = product.CreatedAt;
            UpdatedAt = product.UpdatedAt;
        }
    }
}
