using System.ComponentModel.DataAnnotations.Schema;

namespace bob_api.Models
{
    public class Wishlist
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("user_id")]
        public Guid UserId { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set;} = DateTime.UtcNow;
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set;} = DateTime.UtcNow;

        //Navigational properties
        public User User { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}
