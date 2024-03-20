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
        public ICollection<Order> Orders { get; set; }

    }

    public class UserDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public UserDTO(User user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            Password = user.Password;
            CreatedAt = user.CreatedAt;
            UpdatedAt = user.UpdatedAt;
        }
    }

    public class UserOrderHistoryDTO : UserDTO
    {
        public List<OrderWithProductOrderDTO> Orders { get; set; } = new();

        public UserOrderHistoryDTO(User user) : base(user)
        { 
            foreach(Order order in user.Orders)
            {
                Orders.Add(new OrderWithProductOrderDTO(order));
            }
        }

    }
}
