using System.ComponentModel.DataAnnotations.Schema;

namespace bob_api.Models
{
    public class Product
    {
        [Column("id")]
        public int Id { get; set;}

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
        public ICollection<Category> Categories { get; set;}

        public ICollection<Rating> Ratings { get; set;}

        public ICollection<ProductsOrder> ProductsOrders { get; set; }

        public ICollection<Wishlist> Wishlists { get; set; }
    }
}
