using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace bob_api.Models
{
    public class User : IdentityUser
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("email")]
        public string Email { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        //Navigational property
        //public ICollection<Rating> Ratings { get; set; }

        //public ICollection<Wishlist> Wishlists { get; set; }

        //public ICollection<Order> Orders { get; set; }

    }
}
