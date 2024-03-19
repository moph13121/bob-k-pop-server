using System.ComponentModel.DataAnnotations.Schema;

namespace bob_api.Models
{
    public class ProductsOrder
    {
        [Column("user_id")]
        public Guid OrderId { get; set; }
        [Column("product_id")]
        public Guid ProductId { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }

        //Navigational properties
        //public Order Order { get; set; }

        //public Product Product { get; set; }
    }
}
