using CookingMasterAPI.Data;
using CookingMasterAPI.Models.Entity;
using CookingMasterAPI.Models.Request.AuthRequests;
using CookingMasterAPI.Models.Response;
using Microsoft.EntityFrameworkCore;

namespace CookingMasterAPI.Services.Mappers
{
    public static class AuthMapper
    {
        public static UserResponse MapUserToResponse(User user, APIDbContext context)
        {
            var ingredients = context.Ingredients
                .Include(x => x.IngredientCategory)
                .Where(ingredient => context.UserIngredients
                .Any(ui => ui.User.UserId == user.UserId && ui.Ingredient.IngredientId == ingredient.IngredientId)).ToList();

            var ingredientResponse = IngredientMapper.MapIngredientToResponse(ingredients);
            return new UserResponse(user.UserId, user.Username, user.EmailAddress, ingredientResponse, user.Uid);
        }

        public static User MapRequestToUser(UserRegisterRequest request, byte[] passwordHash, byte[] passwordSalt)
        {
            return new User
            {
                Username = request.Username,
                EmailAddress = request.EmailAddress,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
        }

    }
}
