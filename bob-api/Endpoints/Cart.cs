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
            cart.MapGet("/{userID}", GetProductsByUserID);
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
        public static async Task<IResult> GetProductsByUserID(IRepository<Order> repository, Guid userID)
        {
            Payload<OrderWithProductOrderDTO> output = new();
            IQueryable<Order> order = repository.GetByCondition(o => o.UserId == userID);
            var orderObject = order.First();

            output.data = new OrderWithProductOrderDTO(orderObject);

            return TypedResults.Ok(output);

        }

    }
}
