using System.ComponentModel.DataAnnotations.Schema;

namespace bob_api.Models
{
    public class Order
    {
        [Column("id")]
        public Guid Id { get; set; }
        [Column("status")]
        public string status { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [Column("user_id")]
        public int UserId { get; set; }

        //Navigational property

        public User User { get; set; }

        public ICollection<ProductsOrder> ProductOrders { get; set; }
    }
}
