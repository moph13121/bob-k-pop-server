using System.ComponentModel.DataAnnotations.Schema;

namespace bob_api.Models
{
    public class Category
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
