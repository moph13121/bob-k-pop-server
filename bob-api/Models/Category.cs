using System.ComponentModel.DataAnnotations.Schema;

namespace bob_api.Models
{
    public class Category
    {
        [Column("id")]
        public Guid Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Product> Products { get; set; }

    }

    public class CategoryDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public CategoryDTO(Category category) 
        { 
            Id = category.Id;
            Name = category.Name;
            CreatedAt = category.CreatedAt;
            UpdatedAt = category.UpdatedAt;
        }
    }
}
