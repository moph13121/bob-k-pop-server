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
        public Guid UserId { get; set; }

        [Column("product_id")]
        public Guid ProductId { get; set; }
        
        //Navigational properties
        //public User User { get; set; }

        //public Product Product { get; set; }

    }

    public class RatingDTO
    {
        public Guid Id { get; set; }

        public string Review { get; set; }

        public int RatingValue { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public Guid UserId { get; set; }

        public Guid ProductId { get; set; }

        public RatingDTO(Rating rating)
        {
            Id = rating.Id;
            Review = rating.Review;
            RatingValue = rating.RatingValue;
            CreatedAt = rating.CreatedAt;
            UpdatedAt = rating.UpdatedAt;
            UserId = rating.UserId;
            ProductId = rating.ProductId;
        }
    }
}
