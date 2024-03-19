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

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetProducts(IRepository<Product> repository)
        {
            Payload<List<ProductDto>> output = new();
            output.data = new();

            foreach (Product product in await repository.Get()) 
            {
                output.data.Add(new ProductDto(product));
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

    }
}
