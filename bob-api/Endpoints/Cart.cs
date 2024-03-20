using bob_api.Models;
using bob_api.Payload;
using bob_api.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace bob_api.Endpoints
{
    public static class Cart
    {

        public static void CartEndpoint(this WebApplication app)
        {
            var cart = app.MapGroup("cart");
            //cart.MapGet("/{orderID}", GetOrderByID);
            cart.MapGet("/history/{userID}", GetOrderHistoryByUser);
            cart.MapPost("/order/{userID}", CreateOrder);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetOrderByID(IRepository<Order> repository)
        {
            Payload<List<OrderDTO>> output = new();
            output.data = new();

            foreach (Order order in await repository.Get())
            {
                output.data.Add(new OrderDTO(order));
            }

            return TypedResults.Ok(output);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetOrderHistoryByUser(IRepository<User> repository, Guid userID)
        {
            Payload<UserOrderHistoryDTO> output = new();
            IQueryable<User> user = repository.GetByCondition(o => o.Id == userID);
            var userObject = user.First();

            output.data = new UserOrderHistoryDTO(userObject);

            return TypedResults.Ok(output);

        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateOrder (IRepository<Order> repositoryOrder, IRepository<Product> repositoryProduct, IRepository<ProductsOrder> repositoryProductsOrder, Guid userID, PostOrder postOrder)
        {
            Payload<OrderWithProductOrderDTO> output = new();

            Order order = new Order(postOrder);
            order.UserId = userID;
            order.ProductOrders = [];

            
            //create new order
            output.data = new OrderWithProductOrderDTO(await repositoryOrder.Create(order));

            //create a list of ProductsOrder from the post request
            ICollection<ProductsOrder> postReqProductsOrder = [];
            foreach (PostProductsOrder postProductsOrder in postOrder.ProductOrders) 
            {
                if (await repositoryProduct.GetById(postProductsOrder.ProductId) != null)
                {
                    postReqProductsOrder.Add(new ProductsOrder(postProductsOrder) { OrderId = output.data.Id } );
                }
                else
                {
                    return TypedResults.BadRequest($"Couldn't find product with id: {postProductsOrder.ProductId}");
                }
            }

            //create new productOrders
            var productOrders = await repositoryProductsOrder.CreateMultiple(postReqProductsOrder);

            foreach (ProductsOrder productsOrder in productOrders)
            {
                output.data.ProductOrders.Add (new ProductsOrderDTOWithProduct(productsOrder));
            }

            return TypedResults.Created("", output);
        }

    }
}
