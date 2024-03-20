using bob_api.Models;
using bob_api.Payload;
using bob_api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace bob_api.Endpoints
{
    public static class Storefront
    {

        public static void StorefrontEndpoint(this WebApplication app)
        {
            var storefront = app.MapGroup("storefront");
            storefront.MapGet("/", GetProducts);
            storefront.MapGet("/category", GetCategories);
            storefront.MapGet("/ratings", GetRatings);
            storefront.MapGet("/ratings/{productId}", GetProductRatings);
            storefront.MapGet("/users", GetUsers);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetProducts(IRepository<Product> repository)
        {
            Payload<List<ProductDTO>> output = new();
            output.data = new();

            foreach (Product product in await repository.Get()) 
            {
                output.data.Add(new ProductDTO(product));
            }

            return TypedResults.Ok(output);
        }

        public static async Task<IResult> GetCategories(IRepository<Category> repository)
        {
            Payload<List<CategoryDTO>> output = new();
            output.data = new();
            foreach (Category category in await repository.Get())
            {
                output.data.Add(new CategoryDTO(category));
            }
            return TypedResults.Ok(output);
        }
        public static async Task<IResult> GetRatings(IRepository<Rating> repository)
        {
            Payload<List<RatingDTO>> output = new();
            output.data = new();
            foreach (Rating rating in await repository.Get())
            {
                output.data.Add(new RatingDTO(rating));
            }
            return TypedResults.Ok(output);
        }

        public static async Task<IResult> GetProductRatings(IRepository<Rating> repository, Guid productID)
        {
            Payload<List<RatingDTO>> output = new();
            output.data = new();
            IQueryable<Rating> ratings = repository.GetByCondition(u => u.ProductId == productID);

            foreach (var rating in ratings.ToArray())
            {
                System.Diagnostics.Debug.WriteLine("This is the rating" + rating);
                output.data.Add(new RatingDTO(rating));
            }
            return TypedResults.Ok(output);

        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetUsers(IRepository<User> repository)
        {
            Payload<List<UserDTO>> output = new();
            output.data = new();

            foreach (User user in await repository.Get())
            {
                output.data.Add(new UserDTO(user));
            }

            return TypedResults.Ok(output);
        }

    }
}
