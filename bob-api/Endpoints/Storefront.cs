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
            storefront.MapGet("/category/{categoryId}", GetProductsByCategoryID);
            storefront.MapGet("/ratings", GetRatings);
            storefront.MapGet("/ratings/{productId}", GetProductRatings);
            storefront.MapGet("/users", GetUsers);
            storefront.MapPost("/addRating/{userId}/{productId}", AddRatingToProduct);

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
        
        [ProducesResponseType(StatusCodes.Status200OK)]

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

        [ProducesResponseType(StatusCodes.Status200OK)]

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

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetProductsByCategoryID(IRepository<Category> repository, Guid categoryId)
        {
            Payload<CategoryWithProductOrderDTO> output = new Payload<CategoryWithProductOrderDTO>();
            
            Category request = await repository.GetById(categoryId);
            CategoryWithProductOrderDTO result = new CategoryWithProductOrderDTO(request);

            output.data = result;

            return TypedResults.Ok(output);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]

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
            Payload<List<User>> output = new();
            output.data = [.. await repository.Get()];

            return TypedResults.Ok(output);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> AddRatingToProduct(IRepository<Rating> ratingRepo,
                                                             Guid productID,
                                                             Guid userID,
                                                             PostRating model)
        {
            Payload<RatingDTO> output = new Payload<RatingDTO>();

            var rating = new Rating()
            {
                Id = Guid.NewGuid(),
                Review = model.Review,
                RatingValue = model.RatingValue,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                UserId = userID,
                ProductId = productID,
            };

            var create = await ratingRepo.Create(rating);

            var result = new RatingDTO(create);

            output.data = result;

            return TypedResults.Created(output.status, output.data);

        }

    }
}
