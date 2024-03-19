using System.ComponentModel.DataAnnotations.Schema;

namespace bob_api.Models
{
    public class Rating
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("review")]
        public string Review { get; set; }

        [Column("rating_value")]
        public int RatingValue { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("product_id")]
        public int ProductId { get; set; }
        
        //Navigational properties
        public User User { get; set; }

        public Product Product { get; set; }

    }
}
