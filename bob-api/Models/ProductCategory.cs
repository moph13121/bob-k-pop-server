namespace bob_api.Models
{
    public class ProductCategory
    {
        public Guid ProductId { get; set; }

        public Product Product { get; set; }
        public Guid CategoryId { get; set; }

        public Category Category { get; set; }
    }

    public class ProductsCategoryDTOWithProduct
    {
        public Guid CategoryId { get; set; }
        public Guid ProductId { get; set; }
        public ProductDTO Product { get; set; }

        public CategoryDTO Category { get; set; }  


        public ProductsCategoryDTOWithProduct(ProductCategory pCat)
        {
            CategoryId = pCat.CategoryId;
            ProductId = pCat.ProductId;
            Product = new ProductDTO(pCat.Product);

        }
    }
}
