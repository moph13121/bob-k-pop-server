using System.ComponentModel.DataAnnotations.Schema;

namespace bob_api.Models
{
    public class Order
    {
        [Column("id")]
        public Guid Id { get; set; }
        [Column("status")]
        public string status { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [Column("user_id")]
        public Guid UserId { get; set; }

        //Navigational property

        //public User User { get; set; }

        public ICollection<ProductsOrder> ProductOrders { get; set; }
    }

    public class OrderDTO
    {
        public Guid Id { get; set; }
        public string status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public Guid UserId { get; set; }



        public OrderDTO(Order order)
        {
            Id = order.Id;
            status = order.status;
            CreatedAt = order.CreatedAt;
            UpdatedAt = order.UpdatedAt;
            UserId = order.UserId;

        }

    }

    public class OrderWithProductOrderDTO : OrderDTO
    {

        public List<ProductsOrderDTOWithProduct> ProductOrders { get; set; } = new();



        public OrderWithProductOrderDTO(Order order) : base(order)
        {

            foreach (ProductsOrder productsOrder in order.ProductOrders)
            {
                ProductsOrderDTOWithProduct poWithProdDTO = new ProductsOrderDTOWithProduct(productsOrder);
                ProductOrders.Add(poWithProdDTO);
            }

        }
    }
}
