using bob_api.Models;
using bob_api.Payload;
using bob_api.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bob_api.Endpoints
{
    public static class Cart
    {

        public static void CartEndpoint(this WebApplication app)
        {
            var cart = app.MapGroup("cart");
            //cart.MapGet("/{orderID}", GetOrderByID);
            cart.MapGet("/history/{userID}", GetOrderHistoryByUser);
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

    }
}
