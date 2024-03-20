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

        public ICollection<ProductCategory> ProductCategories { get; set; }

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

    public class CategoryWithProductOrderDTO : CategoryDTO
    {

        public List<ProductsCategoryDTOWithProduct> ProductCategories { get; set; } = new();

        public CategoryWithProductOrderDTO(Category category) : base(category) 
        {
            foreach (ProductCategory product in category.ProductCategories)
            {
                ProductsCategoryDTOWithProduct productDTO = new ProductsCategoryDTOWithProduct(product);
                ProductCategories.Add(productDTO);
            }
        }

    }

}
