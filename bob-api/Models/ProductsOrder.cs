using System.ComponentModel.DataAnnotations.Schema;

namespace bob_api.Models
{
    public class ProductsOrder
    {
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("product_id")]
        public int ProductId { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }

        //Navigational properties
        public User User { get; set; }
        
        public Product Product { get; set; }
    }
}
