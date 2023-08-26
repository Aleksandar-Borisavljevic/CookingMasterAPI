namespace CookingMasterAPI.Models.Response
{
    public record UserResponse
        (
            int UserId,
            string Username,
            string EmailAddress,
            IEnumerable<IngredientResponse> Ingredients,
            string UserUid
        );
}
