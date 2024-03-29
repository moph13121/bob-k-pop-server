﻿using bob_api.Models;
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
            storefront.MapGet("/category/{categoryName}", GetProductsByCategoryName);
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
        public static async Task<IResult> GetProductsByCategoryName(IRepository<Category> repository, string categoryName)
        {
            Payload<CategoryWithProductOrderDTO> output = new Payload<CategoryWithProductOrderDTO>();

            Category request = repository.GetByCondition(c => c.Name.ToLower() == categoryName.ToLower()).FirstOrDefault();

            if (request == null)
            {
                return TypedResults.BadRequest();
            }
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
            Payload<List<UserDTO>> output = new();
            output.data = new();

            foreach (User user in await repository.Get())
            {
                output.data.Add(new UserDTO(user));
            }

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
