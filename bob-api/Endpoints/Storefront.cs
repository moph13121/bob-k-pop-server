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
    }
}
