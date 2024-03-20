using System.ComponentModel.DataAnnotations.Schema;

namespace bob_api.Models
{
    public class ProductsOrder
    {
        [Column("order_id")]
        public Guid OrderId { get; set; }
        [Column("product_id")]
        public Guid ProductId { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }

        //Navigational properties
        public Order Order { get; set; }

        public Product Product { get; set; }


        public ProductsOrder() { }
        public ProductsOrder(PostProductsOrder postProductsOrder)
        {
            ProductId = postProductsOrder.ProductId;
            Quantity = postProductsOrder.Quantity;
        }
    }

    public class ProductsOrderDTO
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        public ProductsOrderDTO(ProductsOrder pOrder)
        {
            OrderId = pOrder.OrderId;
            ProductId = pOrder.ProductId;
            Quantity = pOrder.Quantity;

        }
    }

    public class ProductsOrderDTOWithProduct
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public ProductDTO Product { get; set; }


        public ProductsOrderDTOWithProduct(ProductsOrder pOrder)
        {
            OrderId = pOrder.OrderId;
            ProductId = pOrder.ProductId;
            Quantity = pOrder.Quantity;
            Product = new ProductDTO(pOrder.Product);

        }
    }

    public class PostProductsOrder
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
