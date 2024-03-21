using System.ComponentModel.DataAnnotations;
using System.Data;

namespace bob_api.Services
{
    public class Authentication
    {
        public string? email { get; set; }
        public string? Password { get; set; }

        public bool IsValid()
        {
            return true;
        }
    }

    public class AuthenticationResponse
    {
        public string? Email { get; set; }
        public string? Token { get; set; }

        public Guid? Id { get; set; }
    }

    public class Registration
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

    }
}
